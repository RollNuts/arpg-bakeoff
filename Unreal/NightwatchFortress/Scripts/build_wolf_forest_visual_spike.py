"""
Builds a first visual spike map for Nightwatch Fortress.

Run from the project root with:

"/Users/murakaminaoya/Epic Games/UE_5.8/Engine/Binaries/Mac/UnrealEditor-Cmd" \
  "/Users/murakaminaoya/Products/arpg-bakeoff/Unreal/NightwatchFortress/NightwatchFortress.uproject" \
  -run=pythonscript -script="/Users/murakaminaoya/Products/arpg-bakeoff/Unreal/NightwatchFortress/Scripts/build_wolf_forest_visual_spike.py" \
  -unattended -nop4 -nosplash

The script intentionally uses built-in engine meshes only. Its job is not final
art; it is to prove whether Unreal can deliver a stronger night-forest read
than the Unity primitive scene before paid/API asset spend.
"""

import math
import unreal


MAP_PATH = "/Game/Maps/WolfForestVisualSpike"


def load_asset(path):
    asset = unreal.EditorAssetLibrary.load_asset(path)
    if asset is None:
        raise RuntimeError(f"Missing engine asset: {path}")
    return asset


CUBE = load_asset("/Engine/BasicShapes/Cube.Cube")
SPHERE = load_asset("/Engine/BasicShapes/Sphere.Sphere")
CYLINDER = load_asset("/Engine/BasicShapes/Cylinder.Cylinder")
CONE = load_asset("/Engine/BasicShapes/Cone.Cone")


def make_material(name, color, emissive=None, roughness=0.65, metallic=0.0):
    package_path = "/Game/Nightwatch/Materials"
    unreal.EditorAssetLibrary.make_directory(package_path)
    asset_path = f"{package_path}/{name}"
    existing = unreal.EditorAssetLibrary.load_asset(asset_path)
    if existing:
        return existing

    tools = unreal.AssetToolsHelpers.get_asset_tools()
    material = tools.create_asset(name, package_path, unreal.Material, unreal.MaterialFactoryNew())
    material.set_editor_property("two_sided", True)

    base = unreal.MaterialEditingLibrary.create_material_expression(material, unreal.MaterialExpressionConstant4Vector, -420, -80)
    base.constant = color
    unreal.MaterialEditingLibrary.connect_material_property(base, "", unreal.MaterialProperty.MP_BASE_COLOR)

    rough = unreal.MaterialEditingLibrary.create_material_expression(material, unreal.MaterialExpressionConstant, -420, 120)
    rough.r = roughness
    unreal.MaterialEditingLibrary.connect_material_property(rough, "", unreal.MaterialProperty.MP_ROUGHNESS)

    metal = unreal.MaterialEditingLibrary.create_material_expression(material, unreal.MaterialExpressionConstant, -420, 220)
    metal.r = metallic
    unreal.MaterialEditingLibrary.connect_material_property(metal, "", unreal.MaterialProperty.MP_METALLIC)

    if emissive is not None:
        emission = unreal.MaterialEditingLibrary.create_material_expression(material, unreal.MaterialExpressionConstant4Vector, -420, 20)
        emission.constant = emissive
        unreal.MaterialEditingLibrary.connect_material_property(emission, "", unreal.MaterialProperty.MP_EMISSIVE_COLOR)

    unreal.MaterialEditingLibrary.recompile_material(material)
    unreal.EditorAssetLibrary.save_asset(asset_path)
    return material


MAT = {
    "ground": make_material("M_WetForestGround", unreal.LinearColor(0.025, 0.034, 0.025, 1.0), roughness=0.28),
    "water": make_material("M_ColdStreamWater", unreal.LinearColor(0.02, 0.12, 0.18, 0.72), unreal.LinearColor(0.0, 0.05, 0.08, 1.0), roughness=0.18),
    "bark": make_material("M_MoonlitBark", unreal.LinearColor(0.12, 0.07, 0.04, 1.0), roughness=0.7),
    "leaves": make_material("M_DeepForestLeaves", unreal.LinearColor(0.015, 0.12, 0.045, 1.0), roughness=0.8),
    "wood": make_material("M_BrokenHunterWood", unreal.LinearColor(0.21, 0.12, 0.055, 1.0), roughness=0.72),
    "iron": make_material("M_WornIronEdge", unreal.LinearColor(0.62, 0.60, 0.55, 1.0), roughness=0.28, metallic=0.65),
    "amber": make_material("M_AmberPickupAndFire", unreal.LinearColor(1.0, 0.38, 0.08, 1.0), unreal.LinearColor(3.2, 0.8, 0.08, 1.0), roughness=0.2),
    "moon": make_material("M_ColdMoonGlow", unreal.LinearColor(0.48, 0.58, 0.85, 1.0), unreal.LinearColor(1.0, 1.25, 2.4, 1.0), roughness=0.12),
    "leather": make_material("M_NightwatchLeather", unreal.LinearColor(0.115, 0.065, 0.038, 1.0), roughness=0.44),
    "cloak": make_material("M_DarkCloak", unreal.LinearColor(0.018, 0.023, 0.032, 1.0), roughness=0.74),
    "wolf": make_material("M_GarmDarkHide", unreal.LinearColor(0.025, 0.03, 0.032, 1.0), roughness=0.68),
    "scar": make_material("M_GarmRedScar", unreal.LinearColor(0.72, 0.025, 0.015, 1.0), unreal.LinearColor(0.85, 0.02, 0.01, 1.0), roughness=0.38),
    "eye": make_material("M_GarmAmberEye", unreal.LinearColor(1.0, 0.42, 0.04, 1.0), unreal.LinearColor(3.0, 0.7, 0.08, 1.0), roughness=0.18),
}


def actor(name, mesh, loc, scale, mat, rot=(0, 0, 0)):
    # Avoid spawn_actor_from_object here. In UE 5.8 commandlet/nullrhi runs it
    # routes through the placement subsystem and can crash without a viewport.
    spawned = unreal.EditorLevelLibrary.spawn_actor_from_class(unreal.StaticMeshActor, unreal.Vector(*loc), unreal.Rotator(*rot))
    spawned.set_actor_label(name)
    spawned.set_actor_scale3d(unreal.Vector(*scale))
    comp = spawned.get_component_by_class(unreal.StaticMeshComponent)
    if comp:
        comp.set_static_mesh(mesh)
        if mat:
            comp.set_material(0, mat)
    return spawned


def point_light(name, loc, color, intensity, radius):
    light = unreal.EditorLevelLibrary.spawn_actor_from_class(unreal.PointLight, unreal.Vector(*loc))
    light.set_actor_label(name)
    comp = light.get_component_by_class(unreal.PointLightComponent)
    comp.set_editor_property("light_color", color)
    comp.set_editor_property("intensity", intensity)
    comp.set_editor_property("attenuation_radius", radius)
    comp.set_editor_property("cast_shadows", True)
    return light


def get_editor_world():
    editor_subsystem = unreal.get_editor_subsystem(unreal.UnrealEditorSubsystem)
    return editor_subsystem.get_editor_world()


def build_level():
    unreal.EditorLoadingAndSavingUtils.new_blank_map(False)

    actor("wet black forest floor", CUBE, (0, 0, -8), (18, 16, 0.12), MAT["ground"])
    actor("cold stream crossing", CUBE, (-330, 40, -2), (1.35, 9.8, 0.04), MAT["water"])
    actor("full moon disc", SPHERE, (-520, 560, 420), (0.95, 0.08, 0.95), MAT["moon"], rot=(0, 0, 0))
    actor("fallen tree shortcut", CYLINDER, (300, 100, 58), (0.42, 0.42, 3.25), MAT["wood"], rot=(0, 82, 0))

    # Hunter shack silhouette.
    actor("hunter shack dark body", CUBE, (520, 380, 95), (2.5, 2.1, 1.85), MAT["wood"])
    actor("hunter shack broken roof", CUBE, (520, 380, 222), (3.0, 2.55, 0.32), MAT["cloak"])
    actor("hunter shack broken rafter left", CYLINDER, (450, 350, 285), (0.08, 0.08, 1.35), MAT["wood"], rot=(54, -42, 0))
    actor("hunter shack broken rafter right", CYLINDER, (595, 350, 275), (0.08, 0.08, 1.15), MAT["wood"], rot=(50, 38, 0))
    point_light("hunter shack warm interior", (500, 280, 105), unreal.Color(255, 94, 18), 1700, 430)

    # Forest framing and treeline.
    for i in range(34):
        x = math.sin(i * 1.73) * 760
        y = math.cos(i * 2.19) * 690
        if abs(x) < 180 and y < -260:
            x += 280
        height = 1.2 + (i % 4) * 0.26
        actor(f"tree trunk {i:02d}", CYLINDER, (x, y, 92 * height), (0.32, 0.32, height), MAT["bark"])
        actor(f"dark pine mass {i:02d}", CONE, (x, y, 250 + (i % 2) * 34), (1.0, 1.0, 1.4), MAT["leaves"])

    # Wet path stones and stream banks.
    for i in range(13):
        y = -565 + i * 78
        x = math.sin(i * 1.4) * 36
        actor(f"wet stepping stone {i:02d}", CYLINDER, (x, y, 5), (0.42 + (i % 3) * 0.08, 0.28, 0.035), MAT["iron"], rot=(0, i * 17, 0))

    # Player silhouette.
    actor("PLAYER leather torso", SPHERE, (0, -575, 95), (0.45, 0.32, 0.9), MAT["leather"])
    actor("PLAYER dark split cloak", CUBE, (0, -610, 72), (0.72, 0.12, 1.18), MAT["cloak"])
    actor("PLAYER head and hood", SPHERE, (0, -575, 178), (0.34, 0.32, 0.38), MAT["cloak"])
    actor("PLAYER right sword arm", CYLINDER, (48, -535, 108), (0.12, 0.12, 0.62), MAT["leather"], rot=(42, 22, 0))
    actor("PLAYER shoulder lantern", CUBE, (-46, -538, 142), (0.18, 0.18, 0.24), MAT["amber"])
    point_light("player shoulder lantern light", (-54, -535, 150), unreal.Color(255, 126, 25), 1150, 360)

    # Weapon rack and immediate pickup.
    actor("right weapon rack beam", CUBE, (330, -455, 86), (1.9, 0.14, 0.12), MAT["wood"])
    actor("right weapon rack left leg", CUBE, (246, -455, 42), (0.13, 0.13, 0.9), MAT["wood"])
    actor("right weapon rack right leg", CUBE, (414, -455, 42), (0.13, 0.13, 0.9), MAT["wood"])
    actor("pickup amber floor marker", CYLINDER, (-92, -505, 3), (0.55, 0.55, 0.012), MAT["amber"])
    actor("pickup spear shaft", CYLINDER, (-86, -505, 48), (0.045, 0.045, 1.55), MAT["wood"], rot=(90, -8, 0))
    actor("pickup spear head", CONE, (-124, -505, 91), (0.18, 0.18, 0.32), MAT["iron"], rot=(90, -8, 0))
    actor("rack great hammer head", CUBE, (332, -455, 132), (0.78, 0.32, 0.42), MAT["iron"])
    actor("rack shield face", CYLINDER, (414, -455, 70), (0.58, 0.58, 0.11), MAT["wood"], rot=(90, 0, 0))
    point_light("pickup weapon warm read", (-90, -505, 68), unreal.Color(255, 150, 35), 650, 220)

    # Enemies and Garm.
    actor("small wolf pressure enemy", SPHERE, (180, -60, 48), (0.45, 0.32, 0.36), MAT["wolf"])
    actor("weapon goblin silhouette", SPHERE, (-150, -110, 72), (0.34, 0.28, 0.65), MAT["leather"])
    actor("goblin visible carried spear", CYLINDER, (-122, -110, 118), (0.035, 0.035, 1.15), MAT["wood"], rot=(62, -20, 0))

    actor("GARM massive body", SPHERE, (0, 278, 138), (1.55, 2.4, 1.1), MAT["wolf"])
    actor("GARM long muzzle head", SPHERE, (0, 150, 156), (0.72, 0.58, 0.52), MAT["wolf"])
    actor("GARM muzzle block", CUBE, (0, 92, 136), (0.44, 0.42, 0.22), MAT["wolf"])
    for x in (-54, 54):
        actor(f"GARM amber eye {x}", SPHERE, (x, 88, 168), (0.08, 0.08, 0.08), MAT["eye"])
    for x, y in [(-54, 212), (54, 212), (-58, 340), (58, 340)]:
        actor(f"GARM readable leg {x} {y}", CYLINDER, (x, y, 58), (0.22, 0.22, 0.7), MAT["wolf"])
    actor("GARM spear target red wound", SPHERE, (-58, 210, 82), (0.24, 0.24, 0.24), MAT["scar"])
    actor("GARM embedded spear silhouette", CYLINDER, (-72, 205, 110), (0.035, 0.035, 0.9), MAT["iron"], rot=(62, -18, 0))
    actor("GARM red muzzle scar", CUBE, (0, 84, 175), (0.62, 0.035, 0.035), MAT["scar"], rot=(0, 0, -16))
    for i, y in enumerate((210, 270, 335)):
        actor(f"GARM back fur ridge {i}", CONE, (0, y, 235), (0.18, 0.18, 0.44), MAT["wolf"], rot=(-10 + i * 8, 0, 0))
    point_light("Garm cold moon rim", (0, 460, 250), unreal.Color(88, 126, 255), 2600, 620)

    # Lighting and camera.
    sun = unreal.EditorLevelLibrary.spawn_actor_from_class(unreal.DirectionalLight, unreal.Vector(0, 0, 600))
    sun.set_actor_label("cold blue moon directional")
    sun_comp = sun.get_component_by_class(unreal.DirectionalLightComponent)
    sun_comp.set_editor_property("light_color", unreal.Color(120, 150, 255))
    sun_comp.set_editor_property("intensity", 2.2)
    sun.set_actor_rotation(unreal.Rotator(-48, -24, 0), False)
    point_light("left torch pool", (-190, -520, 145), unreal.Color(255, 92, 16), 1800, 420)
    point_light("right torch pool", (485, -420, 150), unreal.Color(255, 92, 16), 1900, 460)

    camera = unreal.EditorLevelLibrary.spawn_actor_from_class(unreal.CineCameraActor, unreal.Vector(0, -980, 360))
    camera.set_actor_label("CineCamera visual target third person")
    direction = unreal.Vector(0, -45, 104) - camera.get_actor_location()
    camera.set_actor_rotation(direction.rotator(), False)
    cam_comp = camera.get_cine_camera_component()
    cam_comp.set_editor_property("current_focal_length", 26.0)
    # Keep the camera as a scene actor. Do not call viewport camera APIs here;
    # commandlet runs do not have a level viewport.

    unreal.EditorAssetLibrary.make_directory("/Game/Maps")
    unreal.EditorLoadingAndSavingUtils.save_map(get_editor_world(), MAP_PATH)
    unreal.log(f"Built {MAP_PATH}")


build_level()
