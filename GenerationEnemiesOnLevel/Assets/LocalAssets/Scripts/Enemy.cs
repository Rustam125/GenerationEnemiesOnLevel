using UnityEngine;

namespace LocalAssets.Scripts
{
    [RequireComponent(typeof(Rigidbody), typeof(TargetFollower))]
    public class Enemy : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        private TargetFollower _targetFollower;
        
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _targetFollower = GetComponent<TargetFollower>();
        }

        public void Init(Vector3 position, Transform target)
        {
            _rigidbody.velocity = Vector3.zero;

            transform.position = position;
            gameObject.SetActive(true);
            _targetFollower.Init(target);
        }
    }
}
