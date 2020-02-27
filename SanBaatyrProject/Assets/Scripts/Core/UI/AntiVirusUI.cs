using System;
using System.Collections;
using Core.Items.AntiVirus;
using Core.Player;
using Core.Utilities;
using UnityEngine;
using UnityEngine.UI;

namespace Core.UI
{
    public class AntiVirusUI : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private PlayerController player;
        [SerializeField] private CooldownEffect cooldownEffect;
        [SerializeField] private Button button;

        private void Start()
        {
            cooldownEffect = GetComponentInChildren<CooldownEffect>();
            button = GetComponent<Button>();
        }

        public void ActivateAntivirus()
        {
            var antiVirus = ObjectPooler.Instance.SpawnFromPool("AntiVirus", player.transform.position, Quaternion.identity);
            var cooldownTime = antiVirus.GetComponent<AntiVirusWave>().cooldownTime;
            cooldownEffect.StartCooldownAnimation(cooldownTime);
            StartCoroutine(DeactivateButtonDuringCooldown(cooldownTime));
        }

        IEnumerator DeactivateButtonDuringCooldown(float cooldownTime)
        {
            button.interactable = false;
            yield return new WaitForSeconds(cooldownTime);
            button.interactable = true;
        }
    }
}