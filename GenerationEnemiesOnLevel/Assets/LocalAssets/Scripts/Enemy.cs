using UnityEngine;

namespace LocalAssets.Scripts
{
    [RequireComponent(typeof(Rigidbody))]
    public class Enemy : MonoBehaviour
    {
        private const float Speed = 3;

        private Rigidbody _rigidbody;
        private Vector3 _movementDirection;
        
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
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
            transform.Translate(_movementDirection.normalized * Speed * Time.deltaTime,Space.World);
        }

        private void RotateToMovementDirection()
        {
            var rotation = Quaternion.LookRotation(_movementDirection, Vector3.up);
            transform.rotation = rotation;
        }
    }
}
