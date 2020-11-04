using UnityEngine;

public class LightScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            bool isOn = GetComponent<Light>().enabled;
            GetComponent<Light>().enabled = !isOn;
        }
    }
}
