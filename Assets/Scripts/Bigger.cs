using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bigger : MonoBehaviour
{
    GameManager gm;

    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        gm.x += 5;
        gameObject.GetComponent<AudioSource>().Play();
        Destroy(gameObject, 0.2f);
        gm.x = Mathf.Clamp(gm.x, 25, 40);
        other.gameObject.transform.localScale = new Vector3(gm.x, gm.x, gm.x);
        
    }
}
