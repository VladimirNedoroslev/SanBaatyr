using UnityEngine;

namespace Core.Utilities
{
    public static class Animations
    {
        public static readonly int Attack = Animator.StringToHash("Attack");
        public static readonly int IsMoving = Animator.StringToHash("IsMoving");
    
        public static readonly int StartWave = Animator.StringToHash("StartWave");
        public static readonly int GetHit = Animator.StringToHash("GetHit");
    }
}