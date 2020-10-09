using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dotyk : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Light>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // spusti sa pri dotyku
    private void OnTriggerEnter(Collider other)
    {
        // ak sa dotkol hrac
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("dotyk");
            // zistim si stav componentu svetlo
            bool stav = GetComponent<Light>().enabled;
            // nastavim opacny stav
            GetComponent<Light>().enabled = !stav;
        }
    }
}