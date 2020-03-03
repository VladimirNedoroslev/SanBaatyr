using Core.Player;
using Core.Utilities;
using UnityEngine;

namespace Core.UI.Joystick
{
    public class MovementController : MonoBehaviour
    {
        public PlayerController player;
        public VariableJoystick variableJoystick;
        private float _speed;
        private Rigidbody2D _rigidBody2D;
        private Animator _animator;

        //Used for appropriate move speed
        public float speedMultiplier = 10000;


        private Vector3 _facingRightLocale;
        private Vector3 _facingLeftLocale;

        public void Start()
        {
            _rigidBody2D = GetComponent<Rigidbody2D>();
            _animator = GetComponentInChildren<Animator>();
            _facingRightLocale = transform.localScale;
            _facingLeftLocale = _facingRightLocale;
            _facingLeftLocale.x = -1 * _facingRightLocale.x;
        }

        public void Update()
        {
            _speed = player.speed;
        }

        public void FixedUpdate()
        {
            Vector2 direction = Vector2.up * variableJoystick.Vertical + Vector2.right * variableJoystick.Horizontal;

            if (direction.x == 0 && direction.y == 0)
            {
                _animator.SetBool(Animations.IsMoving, false);
            }
            else if (direction.x > 0)
            {
                _animator.SetBool(Animations.IsMoving, true);
                transform.localScale = _facingRightLocale;
            }
            else if (direction.x < 0)
            {
                _animator.SetBool(Animations.IsMoving, true);
                transform.localScale = _facingLeftLocale;
            }

            _rigidBody2D.AddForce(_speed * speedMultiplier * Time.fixedDeltaTime * direction, ForceMode2D.Force);
        }
    }
}