using System.Collections.Generic;
using UnityEngine;

namespace LocalAssets.Scripts
{
    public class Destination : MonoBehaviour
    {
        [SerializeField] private List<Vector3> _points;
        
        public List<Vector3> Points => _points;
    }
}
