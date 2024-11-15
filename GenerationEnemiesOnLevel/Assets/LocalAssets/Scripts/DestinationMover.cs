using System.Linq;
using UnityEngine;

namespace LocalAssets.Scripts
{
    [RequireComponent(typeof(Destination))]
    public class DestinationMover : MonoBehaviour
    {
        [SerializeField] private float _speed = 2f;

        private const float MinDistanceToPoint = 0.05f;
        
        private Destination _destination;
        private Vector3 _destinationPoint;
        private int _destinationIndex;
        
        private void Awake()
        {
            _destination = GetComponent<Destination>();
            Init();
        }

        private void Update()
        {
            RotateToMovementDirection();
            Move();
        }

        private void Init()
        {
            _destinationPoint = _destination.Points.FirstOrDefault();
            _destinationIndex = 0;
            transform.position = _destinationPoint;
        }
        
        private void Move()
        {
            var newPosition = Vector3.MoveTowards(
                transform.position, _destinationPoint, _speed * Time.deltaTime);
            transform.position = newPosition;
            
            var distance = Vector3.Distance(transform.position, _destinationPoint);

            if (distance <= MinDistanceToPoint == false)
            {
                return;
            }

            SetNextDestinationPoint();
        }

        private void SetNextDestinationPoint()
        {
            _destinationIndex = _destinationIndex < _destination.Points.Count - 1 ? 
                _destinationIndex + 1 : 0;

            _destinationPoint = _destination.Points[_destinationIndex];
        }

        private void RotateToMovementDirection()
        {
            transform.LookAt(_destinationPoint);
        }
    }
}
