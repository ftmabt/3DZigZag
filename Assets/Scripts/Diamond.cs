using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    PlayerController pc;
    
    private void Start()
    {
        pc = GameObject.Find("Ball").GetComponent<PlayerController>();

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ball")
        {
            gameObject.GetComponent<AudioSource>().Play();
            Destroy(gameObject, 0.2f);
            pc.speed += 0.2f;
            
        }
    }
}
