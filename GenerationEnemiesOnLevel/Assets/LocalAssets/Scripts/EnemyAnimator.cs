using UnityEngine;

namespace LocalAssets.Scripts
{
    [RequireComponent(typeof(Animator))]
    public class EnemyAnimator : MonoBehaviour
    {
        private static readonly int s_IsRunning = Animator.StringToHash("IsRunning");
        
        private Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>();
            SetupRunningAnimation();
        }

        private void SetupRunningAnimation()
        {
            _animator.SetBool(s_IsRunning, true);
        }
    }
}
