using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float sensitivity = 0.2f;
    
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 moveDirection = new Vector3(0,0,1); // smer pohybu
            transform.Translate(moveDirection * sensitivity); // zmena transformácie (pozície) objektu hráča vzhľadom na smer pohybu
        }
        if (Input.GetKey(KeyCode.S))
        {
            Vector3 moveDirection = new Vector3(0, 0, -1);
            transform.Translate(moveDirection * sensitivity);
        }
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 moveDirection = new Vector3(-1, 0, 0);
            transform.Translate(moveDirection * sensitivity);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 moveDirection = new Vector3(1, 0, 0);
            transform.Translate(moveDirection * sensitivity);
        }
        if (Input.GetKey(KeyCode.E))
        {
            Vector3 moveDirection = new Vector3(0, 1, 0);
            transform.Rotate(moveDirection);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            Vector3 moveDirection = new Vector3(0, -1, 0);
            transform.Rotate(moveDirection);
        }
    }
}
