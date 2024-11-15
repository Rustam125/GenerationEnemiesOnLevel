using UnityEngine;

namespace LocalAssets.Scripts
{
    public class TargetFollower : MonoBehaviour
    {
        [SerializeField] private float _speed = 1.5f;

        private Transform _target;

        private void Update()
        {
            transform.position = Vector3.MoveTowards(
                transform.position, _target.position, _speed * Time.deltaTime);
            transform.LookAt(_target);
        }

        public void Init(Transform target)
        {
            _target = target;
        }
    }
}