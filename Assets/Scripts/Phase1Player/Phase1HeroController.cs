using UnityEngine;

namespace ArpgBakeoff.Phase1
{
    [RequireComponent(typeof(CharacterController))]
    [RequireComponent(typeof(Phase1HeroRig))]
    public class Phase1HeroController : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 5.3f;
        [SerializeField] private float dodgeSpeed = 11.5f;
        [SerializeField] private float dodgeDuration = 0.22f;
        [SerializeField] private float attackDuration = 0.42f;
        [SerializeField] private float hitDuration = 0.24f;
        [SerializeField] private int maxHp = 100;

        private CharacterController characterController;
        private Phase1HeroRig rig;
        private Phase1HeroPose pose;
        private Vector3 moveInput;
        private Vector3 facing = Vector3.forward;
        private Vector3 dodgeDirection;
        private float stateTimer;
        private float poseTimer;
        private float hitStopTimer;
        private float invulnerableTimer;
        private bool attackHitChecked;
        private int hp;

        public int Hp => hp;

        public int MaxHp => maxHp;

        public bool IsDead => pose == Phase1HeroPose.Dead;

        private void Awake()
        {
            characterController = GetComponent<CharacterController>();
            rig = GetComponent<Phase1HeroRig>();
            characterController.radius = 0.38f;
            characterController.height = 1.9f;
            characterController.center = new Vector3(0f, 0.95f, 0f);
            characterController.stepOffset = 0.35f;
            hp = maxHp;
            rig.EnsureBuilt();
        }

        private void Update()
        {
            float deltaTime = Time.deltaTime;
            if (hitStopTimer > 0f)
            {
                hitStopTimer -= deltaTime;
                rig.ApplyPose(pose, poseTimer, facing, 0.45f);
                return;
            }

            poseTimer += deltaTime;
            invulnerableTimer = Mathf.Max(0f, invulnerableTimer - deltaTime);
            ReadInput();

            if (pose == Phase1HeroPose.Dead)
            {
                rig.ApplyPose(Phase1HeroPose.Dead, poseTimer, facing, 0f);
                return;
            }

            if (Input.GetKeyDown(KeyCode.K))
            {
                TakeDamage(999, -facing);
                return;
            }

            if (Input.GetKeyDown(KeyCode.H))
            {
                TakeDamage(18, -facing);
            }

            if (pose == Phase1HeroPose.Hit)
            {
                stateTimer -= deltaTime;
                if (stateTimer <= 0f)
                {
                    pose = Phase1HeroPose.Idle;
                    poseTimer = 0f;
                }

                rig.ApplyPose(Phase1HeroPose.Hit, 1f - (stateTimer / hitDuration), facing, 0.5f);
                return;
            }

            if (pose == Phase1HeroPose.Attack)
            {
                stateTimer -= deltaTime;
                float normalized = 1f - Mathf.Clamp01(stateTimer / attackDuration);
                if (!attackHitChecked && normalized > 0.32f)
                {
                    attackHitChecked = true;
                    ResolveAttack();
                }

                if (stateTimer <= 0f)
                {
                    pose = Phase1HeroPose.Idle;
                    poseTimer = 0f;
                }

                rig.ApplyPose(Phase1HeroPose.Attack, normalized, facing, 0f);
                return;
            }

            if (pose == Phase1HeroPose.Dodge)
            {
                stateTimer -= deltaTime;
                characterController.Move(dodgeDirection * (dodgeSpeed * deltaTime));
                if (stateTimer <= 0f)
                {
                    pose = Phase1HeroPose.Idle;
                    poseTimer = 0f;
                }

                rig.ApplyPose(Phase1HeroPose.Dodge, 1f - (stateTimer / dodgeDuration), facing, 0f);
                return;
            }

            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.J))
            {
                StartAttack();
                return;
            }

            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.LeftShift))
            {
                StartDodge();
                return;
            }

            Move(deltaTime);
            pose = moveInput.sqrMagnitude > 0.02f ? Phase1HeroPose.Run : Phase1HeroPose.Idle;
            rig.ApplyPose(pose, poseTimer, facing, 0f);
        }

        public void TakeDamage(int damage, Vector3 sourceDirection)
        {
            if (pose == Phase1HeroPose.Dead || invulnerableTimer > 0f)
            {
                return;
            }

            hp = Mathf.Max(0, hp - damage);
            if (hp <= 0)
            {
                pose = Phase1HeroPose.Dead;
                poseTimer = 0f;
                Phase1VfxFactory.CreateDeathEmbers(transform.position + Vector3.up * 0.7f);
                rig.ApplyPose(Phase1HeroPose.Dead, 0f, facing, 0f);
                return;
            }

            pose = Phase1HeroPose.Hit;
            poseTimer = 0f;
            stateTimer = hitDuration;
            invulnerableTimer = 0.35f;
            characterController.Move(sourceDirection.normalized * 0.28f);
            Phase1VfxFactory.CreateHitBurst(transform.position + Vector3.up * 1.0f + facing * 0.2f, -facing, new Color(1f, 0.24f, 0.18f, 1f));
        }

        private void ReadInput()
        {
            float horizontal = 0f;
            float vertical = 0f;

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                horizontal -= 1f;
            }

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                horizontal += 1f;
            }

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                vertical += 1f;
            }

            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                vertical -= 1f;
            }

            moveInput = new Vector3(horizontal, 0f, vertical);
            if (moveInput.sqrMagnitude > 1f)
            {
                moveInput.Normalize();
            }
        }

        private void Move(float deltaTime)
        {
            if (moveInput.sqrMagnitude > 0.02f)
            {
                facing = Vector3.Slerp(facing, moveInput.normalized, 18f * deltaTime).normalized;
                transform.rotation = Quaternion.LookRotation(facing, Vector3.up);
            }

            characterController.Move(moveInput * (moveSpeed * deltaTime));
            if (!characterController.isGrounded)
            {
                characterController.Move(Physics.gravity * deltaTime);
            }
        }

        private void StartAttack()
        {
            pose = Phase1HeroPose.Attack;
            poseTimer = 0f;
            stateTimer = attackDuration;
            attackHitChecked = false;
            transform.rotation = Quaternion.LookRotation(facing, Vector3.up);
            Phase1VfxFactory.CreateSlashArc(transform.position + (facing * 0.82f) + Vector3.up * 0.18f, Quaternion.LookRotation(facing, Vector3.up));
        }

        private void StartDodge()
        {
            pose = Phase1HeroPose.Dodge;
            poseTimer = 0f;
            stateTimer = dodgeDuration;
            invulnerableTimer = dodgeDuration + 0.08f;
            dodgeDirection = moveInput.sqrMagnitude > 0.02f ? moveInput.normalized : facing;
            facing = dodgeDirection;
            transform.rotation = Quaternion.LookRotation(facing, Vector3.up);
            Phase1VfxFactory.CreateDodgeTrail(transform.position + Vector3.up * 0.16f, transform.rotation);
        }

        private void ResolveAttack()
        {
            var hits = Physics.OverlapSphere(transform.position + facing * 1.05f + Vector3.up * 0.75f, 0.92f);
            bool connected = false;
            foreach (var hit in hits)
            {
                if (hit.transform == transform)
                {
                    continue;
                }

                var dummy = hit.GetComponentInParent<Phase1CombatDummy>();
                if (dummy != null)
                {
                    dummy.ReceiveHit(28, transform.position, facing);
                    connected = true;
                }
            }

            if (connected)
            {
                hitStopTimer = 0.055f;
                Phase1VfxFactory.CreateHitBurst(transform.position + facing * 1.15f + Vector3.up * 0.95f, facing, new Color(0.8f, 1f, 1f, 1f));
            }
        }
    }
}
