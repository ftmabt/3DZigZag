using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    public GameObject tapTxt;
    GameManager gm;
    public AudioSource ac;
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody>();
        gm.isStarted = false;
        gm._gameOver = false;
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0)&&(!gm.isStarted))
        {
            rb.velocity = new Vector3(speed, 0, 0);
            gm.isStarted = true;
            tapTxt.SetActive(false);
            ac.Play();
        }

            if (Input.GetMouseButtonDown(0)&&(!gm._gameOver))
        {
            SwitchDirection();
        }

        if (!Physics.Raycast(transform.position, Vector3.down, 1f))
        {
            gm._gameOver = true;
            rb.velocity = new Vector3(0, -25f, 0);
        }
    }

    void SwitchDirection()
    {
        if (rb.velocity.z > 0)
        {
            rb.velocity = new Vector3(speed, 0, 0);
        }
        else if(rb.velocity.x > 0)
        {
            rb.velocity = new Vector3(0, 0, speed);
        }
    }
    
}
