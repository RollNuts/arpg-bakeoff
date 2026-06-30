using UnityEngine;

namespace NightwatchFortress.Cameras
{
    public class ThirdPersonFollowCamera : MonoBehaviour
    {
        [SerializeField] private Transform target;
        [SerializeField] private Vector3 offset = new Vector3(0f, 5.8f, -7.4f);
        [SerializeField] private float followSharpness = 8.5f;
        [SerializeField] private float lookHeight = 1.15f;

        public void SetTarget(Transform targetTransform)
        {
            target = targetTransform;
            SnapToTarget();
        }

        private void LateUpdate()
        {
            if (target == null)
            {
                return;
            }

            Vector3 desired = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, desired, 1f - Mathf.Exp(-followSharpness * Time.deltaTime));
            transform.rotation = Quaternion.LookRotation((target.position + Vector3.up * lookHeight) - transform.position, Vector3.up);
        }

        private void SnapToTarget()
        {
            if (target == null)
            {
                return;
            }

            transform.position = target.position + offset;
            transform.rotation = Quaternion.LookRotation((target.position + Vector3.up * lookHeight) - transform.position, Vector3.up);
        }
    }
}
