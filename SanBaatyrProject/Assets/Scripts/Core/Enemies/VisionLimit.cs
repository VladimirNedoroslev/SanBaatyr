using Pathfinding;
using UnityEngine;

namespace Core.Enemies
{
    public class VisionLimit : MonoBehaviour
    {
        public float visionRadius = 1;

        private BaseVirusController _virus;
        private Transform _playerTransform;
        private AIDestinationSetter _aiDestinationSetter;

        private void Start()
        {
            _virus = GetComponent<BaseVirusController>();
            _playerTransform = _virus.player.transform;
            _aiDestinationSetter = gameObject.GetComponent<AIDestinationSetter>();

            visionRadius = _virus.enemyData.visionDistance;
        }


        void Update()
        {
            var distanceToPlayer = Vector2.Distance(_playerTransform.position, transform.position);
            _aiDestinationSetter.enabled = distanceToPlayer <= visionRadius;
        }
    }
}