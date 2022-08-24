using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour
{
    [SerializeField] private Renderer rend;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rend.material.color = Color.red;
            gameObject.tag = "Owner1";
        }
        else if (collision.gameObject.CompareTag("Player2"))
        {
            rend.material.color = Color.green;
            gameObject.tag = "Owner2";
        }
    }
    private void ColorCheck()
    {

    }
}
