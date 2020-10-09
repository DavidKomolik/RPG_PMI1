using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Hrac : MonoBehaviour
{
    public float rychlost = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // dolava
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Vector3 l = new Vector3(-1.0f, 0.0f);
            transform.Translate(l * rychlost);
        }
        // doprava
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Vector3 l = new Vector3(1.0f, 0.0f);
            transform.Translate(l * rychlost);
        }
        // dozadu
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Vector3 l = new Vector3(0.0f, 0.0f, -1.0f);
            transform.Translate(l * rychlost);
        }
        // dopredu
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Vector3 l = new Vector3(0.0f, 0.0f, 1.0f);
            transform.Translate(l * rychlost);
        }
    }
}
