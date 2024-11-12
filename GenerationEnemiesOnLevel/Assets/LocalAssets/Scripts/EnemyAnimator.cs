using UnityEngine;

namespace LocalAssets.Scripts
{
    public class EnemyAnimator : MonoBehaviour
    {
        private static readonly int s_IsRunning = Animator.StringToHash("IsRunning");
        
        private Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            Setup();
        }

        private void Setup()
        {
            _animator.SetBool(s_IsRunning, true);
        }
    }
}
