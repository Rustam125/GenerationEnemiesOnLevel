using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace LocalAssets.Scripts
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private List<Transform> _spawns;
        [SerializeField] private Enemy _enemyPrefab;
        
        private const float MinMovementDirection = 0.005f;
        private const float MaxMovementDirection = 0.009f;
        private const float RepeatRate = 2f;
        
        private ObjectPool<Enemy> _enemiesPool;
        private Coroutine _coroutine;

        private void Awake()
        {
            _enemiesPool = new ObjectPool<Enemy>(
                createFunc: () => Instantiate(_enemyPrefab, transform),
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
            enemy.Init(GetRandomSpawnPosition(), GetRandomMovementDirection());
        }
        
        private Vector3 GetRandomSpawnPosition() =>
            _spawns[Random.Range(0, _spawns.Count)].transform.position;
        
        private Vector3 GetRandomMovementDirection() =>
            new(Random.Range(MinMovementDirection, MaxMovementDirection),
                0f,
                Random.Range(MinMovementDirection, MaxMovementDirection));
        
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
