using UnityEngine;

namespace Core.Utilities
{
    public static class ComponentExtensions
    {
        public static bool IsPlayer(this Behaviour behaviour) => behaviour.CompareTag("Player");
    }
}