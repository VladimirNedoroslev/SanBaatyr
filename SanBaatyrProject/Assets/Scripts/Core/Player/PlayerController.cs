using System;
using Core.Attack;
using Core.Delegates;
using Core.Health;
using Core.Managers;
using UnityEngine;

namespace Core.Player
{
    public class PlayerController : MonoBehaviour
    {
        public float speed = 20;
        public BaseHealthBehavior health;
        
        private SpriteRenderer[] _spriteGroup;
        private Animator _playerAnimator;

        public static event NoParameterDelegate OnPlayerDeath;
        
        public void Awake()
        {
            _playerAnimator = GetComponentInChildren<Animator>();
            _spriteGroup = GetComponentsInChildren<SpriteRenderer>(true);
            health = new BaseHealthBehavior(10,10);
        }

        private void OnEnable()
        {
            OnPlayerDeath += GUIManager.Instance.ShowGameOverScreen;
        }

        private void OnDisable()
        {
            OnPlayerDeath -= GUIManager.Instance.ShowGameOverScreen;
        }


        public void Update()
        {
            _playerAnimator.SetFloat("MoveSpeed", speed * 0.1f);
            if (health.IsDead())
            {
                OnPlayerDeath?.Invoke();
            }
        }
        
    }
}