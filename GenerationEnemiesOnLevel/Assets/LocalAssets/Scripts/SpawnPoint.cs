using UnityEngine;

namespace LocalAssets.Scripts
{
    public class SpawnPoint : MonoBehaviour
    {
        [SerializeField] private Enemy _enemyPrefab;
        
        [SerializeField] private Transform _target;
        
        public Enemy EnemyPrefab => _enemyPrefab;
        public Transform Target => _target;
        public Vector3 Position => transform.position;
    }
}
