using Core.Health;
using UnityEngine;

namespace Core.UI
{
    public class FirstAidKitUiController : MonoBehaviour
    {
        [SerializeField] private Transform playerTransform;


        private void Start()
        {
            FirstAidKitController.PlayerHealed += ShowHealFloatingText;
        }

        private void ShowHealFloatingText(int healPoints)
        {
            FloatingText.InitializePopUpText(playerTransform, healPoints.ToString(), Color.green);
        }
    }
}