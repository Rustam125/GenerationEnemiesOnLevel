using UnityEngine;

namespace LocalAssets.Scripts
{
    [RequireComponent(typeof(Rigidbody))]
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        
        private static readonly int IsRunning = Animator.StringToHash("IsRunning");

        private Rigidbody _rigidbody;
        private Vector3 _movementDirection;
        
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            SetRunningAnimation();
        }

        private void Update()
        {
            RotateToMovementDirection();
            Move();
        }
        
        public void Init(Vector3 position, Vector3 movementDirection)
        {
            _movementDirection = movementDirection;
            _rigidbody.velocity = Vector3.zero;

            transform.position = position;
            gameObject.SetActive(true);
        }

        private void Move()
        {
            transform.Translate(_movementDirection);
        }

        private void RotateToMovementDirection()
        {
            if (_movementDirection != Vector3.zero)
            {
                transform.forward = _movementDirection;
            }
        }

        private void SetRunningAnimation()
        {
            _animator.SetBool(IsRunning, true);
        }
    }
}
