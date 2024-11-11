using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace LocalAssets.Scripts
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private List<Spawn> _spawns;
        [SerializeField] private Enemy _enemyPrefab;
        
        private const float MinMovementDirection = 0.005f;
        private const float MaxMovementDirection = 0.009f;
        
        private const float RepeatRate = 2f;
        private ObjectPool<Enemy> _enemiesPool;
        
        private void Awake()
        {
            _enemiesPool = new ObjectPool<Enemy>(
                createFunc: () => Instantiate(_enemyPrefab, transform),
                actionOnGet: GetEnemy,
                actionOnDestroy: Destroy);
        }
        
        private void Start()
        {
            InvokeRepeating(nameof(Spawn), 0f, RepeatRate);
        }
        
        private void Spawn()
        {
            _enemiesPool.Get();
        }
        
        private void GetEnemy(Enemy enemy)
        {
            enemy.Init(GetRandomSpawnPosition(), GetRandomMovementDirection());
        }
        
        private Vector3 GetRandomSpawnPosition() => _spawns[Random.Range(0, _spawns.Count)].transform.position;
        
        private static Vector3 GetRandomMovementDirection() => new(
            Random.Range(MinMovementDirection, MaxMovementDirection),
            0f,
            Random.Range(MinMovementDirection, MaxMovementDirection));

    }
}
