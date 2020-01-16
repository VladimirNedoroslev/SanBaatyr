using Core.Attack;
using Core.Health;
using Prefabs.MetaObjects.GUIManager;
using UnityEngine;

namespace Core.Player
{
    public class PlayerController : Singleton<PlayerController>
    {
        //public int maxHealth = 100;
        public float speed = 20;
        //public int currentHealth = 100;

        public SpriteRenderer[] spriteGroup;

        private Animator _playerAnimator;


        public void Start()
        {
            gameObject.GetComponent<BaseHealthBehavior>().Restore();
            _playerAnimator = Instance.transform.GetComponentInChildren<Animator>();
            spriteGroup = gameObject.transform.GetComponentsInChildren<SpriteRenderer>(true);
            InitializeAnimClipTimes();
        }

        private void InitializeAnimClipTimes()
        {
            var clips = _playerAnimator.runtimeAnimatorController.animationClips;
            foreach (var clip in clips)
            {
                switch (clip.name)
                {
                    case "Attack1":
                        break;
                    case "Attack2":
                        break;
                }
            }
        }

        public void Update()
        {
            _playerAnimator.SetFloat("MoveSpeed", speed * 0.1f);
        }


        public int sortingOrder;
        public int sortingOrderOrigin;

        private float _updateTic;

        private void spriteOrder_Controller()
        {
            _updateTic += Time.deltaTime;

            if (_updateTic > 0.1f)
            {
                sortingOrder = Mathf.RoundToInt(gameObject.transform.position.y * 100);
                for (int i = 0; i < spriteGroup.Length; i++)
                {
                    spriteGroup[i].sortingOrder = sortingOrderOrigin - sortingOrder;
                }

                _updateTic = 0;
            }
        }

        public void Die()
        {
            gameObject.GetComponent<MeleeAutoAttack>().enabled = false;
            Time.timeScale = 0f;
            GUIManager.Instance.ShowGameOverScreen();
            _playerAnimator.SetTrigger("Die");
        }

        public void GetDamage()
        {
            _playerAnimator.SetTrigger("Hit");
        }
    }
}