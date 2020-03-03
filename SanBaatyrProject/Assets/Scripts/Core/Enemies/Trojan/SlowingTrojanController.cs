using System.Collections;
using Core.Utilities;
using UnityEngine;

namespace Core.Enemies.Trojan
{
    public class SlowingTrojanController : MonoBehaviour
    {
        public float moveSpeedDecrease;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.IsPlayer())
            {
            }
        }


        private IEnumerable SlowPlayer()
        {
            yield return null;
        }
    }
}