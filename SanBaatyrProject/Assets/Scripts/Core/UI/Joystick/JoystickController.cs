using Prefabs.Player;
using UnityEngine;

namespace General_UI.Joystick
{
    public class JoystickController : MonoBehaviour
    {
        private float _speed;
        private Rigidbody2D _rigidBody2D;
        private Animator _animator;
        private Transform _transform;
        public VariableJoystick variableJoystick;

        //Used for appropriate move speed
        private float _speedMultiplier = 10000;

        private Vector3 _facingRightLocale;
        private Vector3 _facingLeftLocale;

        public void Start()
        {
            _rigidBody2D = gameObject.GetComponent<Rigidbody2D>();
            _animator = gameObject.GetComponentInChildren<Animator>();
            _transform = gameObject.transform;
            _facingRightLocale = _transform.localScale;
            _facingLeftLocale = _facingRightLocale;
            _facingLeftLocale.x = -1 * _facingRightLocale.x;
        }

        public void Update()
        {
            _speed = PlayerController.Instance.speed;
        }

        public void FixedUpdate()
        {
            Vector2 direction = Vector2.up * variableJoystick.Vertical + Vector2.right * variableJoystick.Horizontal;

            if (direction.x == 0 && direction.y == 0)
            {
                _animator.SetBool("IsMoving", false);
            }
            else if (direction.x > 0)
            {
                _animator.SetBool("IsMoving", true);
                _transform.localScale = _facingRightLocale;
            }
            else if (direction.x < 0)
            {
                _animator.SetBool("IsMoving", true);
                _transform.localScale = _facingLeftLocale;
            }

            _rigidBody2D.AddForce(_speed * _speedMultiplier * Time.fixedDeltaTime * direction, ForceMode2D.Force);
        }
    }
}