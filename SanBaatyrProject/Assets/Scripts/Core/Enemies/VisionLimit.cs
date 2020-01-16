﻿using Core.Player;
using Pathfinding;
using UnityEngine;

namespace Core.Enemies
{
    public class VisionLimit : MonoBehaviour
    {
        private float _visionRadius = 1;
        private Transform _playerTransform;
        private AIDestinationSetter _aiDestinationSetter;

        private void Start()
        {
            _aiDestinationSetter = gameObject.GetComponent<AIDestinationSetter>();
            _playerTransform = PlayerController.Instance.transform;
            _visionRadius = gameObject.GetComponent<BaseVirus>().enemyData.visionDistance;
        }


        void Update()
        {
            var distance = Vector2.Distance(_playerTransform.position, transform.position);

            if (distance > _visionRadius)
            {
                _aiDestinationSetter.enabled = false;
            }
            else if (!_aiDestinationSetter.enabled)
            {
                _aiDestinationSetter.enabled = true;
            }
        }
    }
}