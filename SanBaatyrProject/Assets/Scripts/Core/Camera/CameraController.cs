using Core.Player;
using UnityEngine;

namespace Core.Camera
{
    public class CameraController : MonoBehaviour
    {
        private Vector3 _offset;
        private PlayerController _playerController;

        // Start is called before the first frame update
        void Start()
        {
            _offset = transform.position - PlayerController.Instance.transform.position;
            _playerController = PlayerController.Instance;
        }

        // Update is called once per frame
        void Update()
        {
            transform.position = _playerController.transform.position + _offset;
        }
    }
}