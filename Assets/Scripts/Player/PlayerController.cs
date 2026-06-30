using UnityEngine;

namespace NightwatchFortress.Player
{
    [RequireComponent(typeof(CharacterController))]
    [RequireComponent(typeof(PlayerVitals))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private Transform cameraTransform;
        [SerializeField] private float moveSpeed = 5.5f;
        [SerializeField] private float rotationSpeed = 15f;
        [SerializeField] private float jumpSpeed = 5.8f;
        [SerializeField] private float gravity = -22f;
        [SerializeField] private float dodgeSpeed = 12.5f;
        [SerializeField] private float dodgeDuration = 0.22f;
        [SerializeField] private float dodgeStaminaCost = 18f;

        private CharacterController characterController;
        private PlayerVitals vitals;
        private Vector3 velocity;
        private Vector3 moveInput;
        private Vector3 facing = Vector3.forward;
        private Vector3 dodgeDirection;
        private float dodgeTimer;

        public Vector3 Facing => facing;
        public bool IsDodging => dodgeTimer > 0f;

        private void Awake()
        {
            characterController = GetComponent<CharacterController>();
            vitals = GetComponent<PlayerVitals>();
            characterController.radius = 0.36f;
            characterController.height = 1.82f;
            characterController.center = new Vector3(0f, 0.91f, 0f);

            if (cameraTransform == null && UnityEngine.Camera.main != null)
            {
                cameraTransform = UnityEngine.Camera.main.transform;
            }
        }

        private void Update()
        {
            float deltaTime = Time.deltaTime;
            ReadMoveInput();

            if (dodgeTimer > 0f)
            {
                dodgeTimer -= deltaTime;
                characterController.Move(dodgeDirection * (dodgeSpeed * deltaTime));
                ApplyGravity(deltaTime);
                return;
            }

            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.LeftShift)) && vitals.SpendStamina(dodgeStaminaCost))
            {
                StartDodge();
            }

            Move(deltaTime);
            ApplyGravity(deltaTime);
        }

        public void SetCamera(Transform followCamera)
        {
            cameraTransform = followCamera;
        }

        private void ReadMoveInput()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            moveInput = new Vector3(horizontal, 0f, vertical);
            if (moveInput.sqrMagnitude > 1f)
            {
                moveInput.Normalize();
            }
        }

        private void Move(float deltaTime)
        {
            Vector3 worldMove = CameraRelative(moveInput);
            if (worldMove.sqrMagnitude > 0.01f)
            {
                facing = Vector3.Slerp(facing, worldMove.normalized, rotationSpeed * deltaTime).normalized;
                transform.rotation = Quaternion.LookRotation(facing, Vector3.up);
                characterController.Move(worldMove * (moveSpeed * deltaTime));
            }

            if (characterController.isGrounded && velocity.y < 0f)
            {
                velocity.y = -1f;
            }

            if (Input.GetKeyDown(KeyCode.C) && characterController.isGrounded)
            {
                velocity.y = jumpSpeed;
            }
        }

        private void StartDodge()
        {
            Vector3 worldMove = CameraRelative(moveInput);
            dodgeDirection = worldMove.sqrMagnitude > 0.01f ? worldMove.normalized : facing;
            facing = dodgeDirection;
            transform.rotation = Quaternion.LookRotation(facing, Vector3.up);
            dodgeTimer = dodgeDuration;
        }

        private void ApplyGravity(float deltaTime)
        {
            velocity.y += gravity * deltaTime;
            characterController.Move(velocity * deltaTime);
        }

        private Vector3 CameraRelative(Vector3 input)
        {
            if (cameraTransform == null || input.sqrMagnitude < 0.001f)
            {
                return input;
            }

            Vector3 forward = cameraTransform.forward;
            forward.y = 0f;
            forward.Normalize();
            Vector3 right = cameraTransform.right;
            right.y = 0f;
            right.Normalize();
            return (right * input.x) + (forward * input.z);
        }
    }
}
