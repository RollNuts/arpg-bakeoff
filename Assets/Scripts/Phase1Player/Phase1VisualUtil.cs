using UnityEngine;

namespace ArpgBakeoff.Phase1
{
    public static class Phase1VisualUtil
    {
        public static Material CreateMaterial(string name, Color color, float metallic = 0f, float smoothness = 0.45f, Color? emission = null, bool transparent = false)
        {
            var shader = Shader.Find("Universal Render Pipeline/Lit");
            if (shader == null)
            {
                shader = Shader.Find("Standard");
            }

            var material = new Material(shader)
            {
                name = name
            };

            SetColor(material, color);
            if (material.HasProperty("_Metallic"))
            {
                material.SetFloat("_Metallic", metallic);
            }

            if (material.HasProperty("_Smoothness"))
            {
                material.SetFloat("_Smoothness", smoothness);
            }

            if (emission.HasValue)
            {
                material.EnableKeyword("_EMISSION");
                if (material.HasProperty("_EmissionColor"))
                {
                    material.SetColor("_EmissionColor", emission.Value);
                }
            }

            if (transparent)
            {
                material.renderQueue = 3000;
                if (material.HasProperty("_Surface"))
                {
                    material.SetFloat("_Surface", 1f);
                }

                if (material.HasProperty("_Mode"))
                {
                    material.SetFloat("_Mode", 3f);
                }

                material.EnableKeyword("_ALPHABLEND_ON");
                material.SetOverrideTag("RenderType", "Transparent");
                material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
                material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                material.SetInt("_ZWrite", 0);
            }

            return material;
        }

        public static void SetColor(Material material, Color color)
        {
            if (material.HasProperty("_BaseColor"))
            {
                material.SetColor("_BaseColor", color);
            }

            if (material.HasProperty("_Color"))
            {
                material.SetColor("_Color", color);
            }
        }

        public static Mesh TaperedCylinder(string name, int sides, float height, float bottomRadius, float topRadius)
        {
            sides = Mathf.Max(5, sides);
            var vertices = new Vector3[(sides * 2) + 2];
            var triangles = new int[sides * 12];
            float half = height * 0.5f;

            for (int i = 0; i < sides; i++)
            {
                float angle = (Mathf.PI * 2f * i) / sides;
                float x = Mathf.Cos(angle);
                float z = Mathf.Sin(angle);
                vertices[i] = new Vector3(x * bottomRadius, -half, z * bottomRadius);
                vertices[i + sides] = new Vector3(x * topRadius, half, z * topRadius);
            }

            vertices[sides * 2] = new Vector3(0f, -half, 0f);
            vertices[(sides * 2) + 1] = new Vector3(0f, half, 0f);

            int t = 0;
            int bottomCenter = sides * 2;
            int topCenter = bottomCenter + 1;
            for (int i = 0; i < sides; i++)
            {
                int next = (i + 1) % sides;
                triangles[t++] = i;
                triangles[t++] = i + sides;
                triangles[t++] = next + sides;
                triangles[t++] = i;
                triangles[t++] = next + sides;
                triangles[t++] = next;

                triangles[t++] = bottomCenter;
                triangles[t++] = next;
                triangles[t++] = i;

                triangles[t++] = topCenter;
                triangles[t++] = i + sides;
                triangles[t++] = next + sides;
            }

            return FinishMesh(name, vertices, triangles);
        }

        public static Mesh BeveledBox(string name, Vector3 size, float bevel = 0.08f)
        {
            bevel = Mathf.Clamp(bevel, 0f, Mathf.Min(size.x, size.y, size.z) * 0.22f);
            float x = size.x * 0.5f;
            float y = size.y * 0.5f;
            float z = size.z * 0.5f;
            float bx = Mathf.Max(0.01f, x - bevel);
            float by = Mathf.Max(0.01f, y - bevel);
            float bz = Mathf.Max(0.01f, z - bevel);

            var vertices = new[]
            {
                new Vector3(-bx, -y, -bz), new Vector3(bx, -y, -bz), new Vector3(bx, -y, bz), new Vector3(-bx, -y, bz),
                new Vector3(-x, -by, -bz), new Vector3(x, -by, -bz), new Vector3(x, -by, bz), new Vector3(-x, -by, bz),
                new Vector3(-x, by, -bz), new Vector3(x, by, -bz), new Vector3(x, by, bz), new Vector3(-x, by, bz),
                new Vector3(-bx, y, -bz), new Vector3(bx, y, -bz), new Vector3(bx, y, bz), new Vector3(-bx, y, bz),
                new Vector3(-bx, -by, -z), new Vector3(bx, -by, -z), new Vector3(bx, by, -z), new Vector3(-bx, by, -z),
                new Vector3(-bx, -by, z), new Vector3(bx, -by, z), new Vector3(bx, by, z), new Vector3(-bx, by, z)
            };

            var triangles = new[]
            {
                0,1,2, 0,2,3,
                12,15,14, 12,14,13,
                16,17,18, 16,18,19,
                20,23,22, 20,22,21,
                4,8,11, 4,11,7,
                5,6,10, 5,10,9,
                0,4,5, 0,5,1,
                3,2,6, 3,6,7,
                8,12,13, 8,13,9,
                11,10,14, 11,14,15,
                16,19,8, 16,8,4,
                17,5,9, 17,9,18,
                20,7,11, 20,11,23,
                21,22,10, 21,10,6,
                16,0,1, 16,1,17,
                19,18,13, 19,13,12,
                20,21,2, 20,2,3,
                23,15,14, 23,14,22
            };

            return FinishMesh(name, vertices, triangles);
        }

        public static Mesh DiamondBlade(string name, float length, float width, float thickness)
        {
            var vertices = new[]
            {
                new Vector3(0f, 0f, -thickness),
                new Vector3(-width, length * 0.12f, 0f),
                new Vector3(0f, length, 0f),
                new Vector3(width, length * 0.12f, 0f),
                new Vector3(0f, 0f, thickness),
                new Vector3(0f, length * 0.52f, -thickness * 0.55f),
                new Vector3(0f, length * 0.52f, thickness * 0.55f)
            };

            var triangles = new[]
            {
                0,1,5, 1,2,5, 2,3,5, 3,0,5,
                4,6,1, 1,6,2, 2,6,3, 3,6,4,
                0,4,1, 0,3,4
            };

            return FinishMesh(name, vertices, triangles);
        }

        public static Mesh Cape(string name, float width, float height, float flare)
        {
            var vertices = new[]
            {
                new Vector3(-width * 0.42f, 0f, 0f),
                new Vector3(width * 0.42f, 0f, 0f),
                new Vector3(width * 0.5f + flare, -height * 0.55f, -0.12f),
                new Vector3(width * 0.25f, -height, -0.2f),
                new Vector3(0f, -height * 0.9f, -0.34f),
                new Vector3(-width * 0.25f, -height, -0.2f),
                new Vector3(-width * 0.5f - flare, -height * 0.55f, -0.12f)
            };

            var triangles = new[]
            {
                0,1,4,
                0,4,6,
                1,2,4,
                6,4,5,
                2,3,4
            };

            return FinishMesh(name, vertices, triangles);
        }

        public static Mesh Quad(string name, float width, float height)
        {
            var vertices = new[]
            {
                new Vector3(-width * 0.5f, -height * 0.5f, 0f),
                new Vector3(width * 0.5f, -height * 0.5f, 0f),
                new Vector3(width * 0.5f, height * 0.5f, 0f),
                new Vector3(-width * 0.5f, height * 0.5f, 0f)
            };
            var triangles = new[] { 0, 1, 2, 0, 2, 3 };
            return FinishMesh(name, vertices, triangles);
        }

        public static Mesh RingSector(string name, float innerRadius, float outerRadius, float degrees, int segments)
        {
            segments = Mathf.Max(4, segments);
            var vertices = new Vector3[(segments + 1) * 2];
            var triangles = new int[segments * 6];
            float start = -degrees * 0.5f * Mathf.Deg2Rad;
            float step = degrees * Mathf.Deg2Rad / segments;

            for (int i = 0; i <= segments; i++)
            {
                float angle = start + (step * i);
                float x = Mathf.Sin(angle);
                float z = Mathf.Cos(angle);
                vertices[i * 2] = new Vector3(x * innerRadius, 0f, z * innerRadius);
                vertices[(i * 2) + 1] = new Vector3(x * outerRadius, 0f, z * outerRadius);
            }

            int t = 0;
            for (int i = 0; i < segments; i++)
            {
                int a = i * 2;
                triangles[t++] = a;
                triangles[t++] = a + 1;
                triangles[t++] = a + 3;
                triangles[t++] = a;
                triangles[t++] = a + 3;
                triangles[t++] = a + 2;
            }

            return FinishMesh(name, vertices, triangles);
        }

        public static Mesh Ellipse(string name, float radiusX, float radiusZ, int segments)
        {
            segments = Mathf.Max(12, segments);
            var vertices = new Vector3[segments + 1];
            var triangles = new int[segments * 3];
            vertices[0] = Vector3.zero;

            for (int i = 0; i < segments; i++)
            {
                float angle = Mathf.PI * 2f * i / segments;
                vertices[i + 1] = new Vector3(Mathf.Cos(angle) * radiusX, 0f, Mathf.Sin(angle) * radiusZ);
            }

            int t = 0;
            for (int i = 0; i < segments; i++)
            {
                triangles[t++] = 0;
                triangles[t++] = i + 1;
                triangles[t++] = ((i + 1) % segments) + 1;
            }

            return FinishMesh(name, vertices, triangles);
        }

        public static GameObject MeshObject(string name, Mesh mesh, Material material, Transform parent, Vector3 localPosition, Quaternion localRotation, Vector3 localScale)
        {
            var child = new GameObject(name);
            child.transform.SetParent(parent, false);
            child.transform.localPosition = localPosition;
            child.transform.localRotation = localRotation;
            child.transform.localScale = localScale;
            child.AddComponent<MeshFilter>().sharedMesh = mesh;
            child.AddComponent<MeshRenderer>().sharedMaterial = material;
            return child;
        }

        private static Mesh FinishMesh(string name, Vector3[] vertices, int[] triangles)
        {
            var mesh = new Mesh
            {
                name = name
            };
            mesh.vertices = vertices;
            mesh.triangles = triangles;
            mesh.RecalculateNormals();
            mesh.RecalculateBounds();
            return mesh;
        }
    }
}
