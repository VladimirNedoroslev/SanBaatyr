using UnityEngine;

public class PickUpAntiVirus : MonoBehaviour
{
    public GameObject AntiVirusButton;

    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("triggered");
        if (other.tag == "Player")
        {
            Debug.Log("PickUp");
            AntiVirusButton.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
