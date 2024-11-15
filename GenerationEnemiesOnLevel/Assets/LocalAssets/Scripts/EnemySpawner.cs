using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace LocalAssets.Scripts
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private List<SpawnPoint> _spawns;
        
        private const float RepeatRate = 2f;
        
        private ObjectPool<Enemy> _enemiesPool;
        private Coroutine _coroutine;
        private SpawnPoint _currentSpawn;

        private void Awake()
        {
            _currentSpawn = GetRandomSpawnPoint();
            _enemiesPool = new ObjectPool<Enemy>(
                createFunc: () => Instantiate(_currentSpawn.EnemyPrefab, transform),
                actionOnGet: InitEnemy,
                actionOnDestroy: Destroy);
        }
        
        private void Start()
        {
            _coroutine = StartCoroutine(Spawn(RepeatRate));
        }
        
        private void OnDestroy()
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);
        }
        
        private void InitEnemy(Enemy enemy)
        {
            enemy.Init(_currentSpawn.Position, _currentSpawn.Target);
            _currentSpawn = GetRandomSpawnPoint();
        }
        
        private SpawnPoint GetRandomSpawnPoint() =>
            _spawns[Random.Range(0, _spawns.Count)];

        private IEnumerator Spawn(float delay)
        {
            var wait = new WaitForSeconds(delay);
            
            while (enabled)
            {
                _enemiesPool.Get();
                yield return wait;
            }
        }
    }
}
