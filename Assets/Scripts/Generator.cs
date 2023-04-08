using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject platform;
    public GameObject diamond;
    public GameObject smaller;
    public GameObject bigger;

    Vector3 lastPos;
    float size;
    GameManager gm;
    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        lastPos = platform.transform.position;
        //size = platform.transform.localScale.x;
        size = 1f;
        
            InvokeRepeating("SpawnPlatforms", 0.1f, 0.1f);
        
    }
    private void Update()
    {
        if (gm._gameOver)
        {
            CancelInvoke("SpawnPlatforms");
        }
    }
    void SpawnPlatforms()
    {
        int rand = Random.Range(0, 6);
        if (rand < 3)
        {
            SpawnX();
        }
        else if (rand >= 3)
        {
            SpawnZ();
        }
    }

    void SpawnX()
    {
        Vector3 pos = lastPos;
        pos.x += size;
        lastPos = pos;
        Instantiate(platform, pos, platform.transform.rotation);

        int rand = Random.Range(0, 30);
        if (rand < 1)
        {
            pos.y += 1;
            Instantiate(diamond, pos, diamond.transform.rotation);
        }
        else if ((rand > 12) && (rand < 15))
        {
            pos.y += 1;
            Instantiate(smaller, pos, smaller.transform.rotation);
        }
        else if ((rand > 4) && (rand < 7))
        {
            pos.y += 1;
            Instantiate(bigger, pos, bigger.transform.rotation);
        }
    }

    void SpawnZ()
    {
        Vector3 pos = lastPos;
        pos.z += size;
        lastPos = pos;
        Instantiate(platform, pos, platform.transform.rotation);

        int rand = Random.Range(0, 30);
        if (rand < 1)
        {
            pos.y += 1;
            Instantiate(diamond, pos, diamond.transform.rotation);
        }
        else if ((rand > 12) && (rand < 15))
        {
            pos.y += 1;
            Instantiate(smaller, pos, smaller.transform.rotation);
        }
        else if ((rand > 4) && (rand < 7))
        {
            pos.y += 1;
            Instantiate(bigger, pos, bigger.transform.rotation);
        }
    }
}
