using Core.Attack;
using Core.Player;
using UnityEngine;

namespace Core.UI
{
    public class PlayerUiController : MonoBehaviour
    {
        [SerializeField] private PlayerController playerController;

        private PlayerMeleeAutoAttackBehavior _playerMeleeAutoAttackBehavior;
        private Transform playerTransform;

        private void Start()
        {
            playerTransform = playerController.transform;
            _playerMeleeAutoAttackBehavior = playerController.GetComponentInChildren<PlayerMeleeAutoAttackBehavior>();
            _playerMeleeAutoAttackBehavior.EnemyAttack += ShowDamageFloatingText;
        }

        private void ShowDamageFloatingText(int damage)
        {
            FloatingText.InitializePopUpText(playerTransform, damage.ToString(), Color.red);
        }
    }
}