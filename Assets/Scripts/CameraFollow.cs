using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Camera cam;
    Vector3 offset;
    GameManager gm;
    [SerializeField] GameObject ball;
    private void Awake()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        cam = Camera.main;
        offset = ball.transform.position - transform.position;
    }

    private void FixedUpdate()
    {
        if (!gm._gameOver)
        {
            transform.position=Vector3.Lerp(transform.position, ball.transform.position - offset, 5f*Time.deltaTime);
        }
    }
}
