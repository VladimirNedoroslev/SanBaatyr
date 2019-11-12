﻿using Prefabs.Player;
using UnityEngine;

namespace Camera
{
    public class CameraController : MonoBehaviour
    {
        private Vector3 _offset;
        private Prefabs.Player.PlayerController _playerController;

        // Start is called before the first frame update
        void Start()
        {
            _offset = transform.position - Prefabs.Player.PlayerController.Instance.transform.position;
            _playerController = Prefabs.Player.PlayerController.Instance;
        }

        // Update is called once per frame
        void Update()
        {
            transform.position = _playerController.transform.position + _offset;
        }
    }
}