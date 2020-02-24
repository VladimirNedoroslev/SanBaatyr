using Core.Player;
using UnityEngine;

namespace Core.Camera
{
    public class CameraController : MonoBehaviour
    {
        private Vector3 _offset;
        public PlayerController player;

        private Transform _playerTransform;

        private void Start()
        {
            _playerTransform = player.transform;
            _offset = transform.position - _playerTransform.position;
        }

        private void Update()
        {
            transform.position = _playerTransform.position + _offset;
        }
    }
}