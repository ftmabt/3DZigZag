using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool _gameOver;
    public bool isStarted;
    public float x=30;

    float score = 0;
    float hishest;
    [SerializeField] Text scoreTxt;
    [SerializeField] GameObject panel;
    [SerializeField] GameObject leaderboard;
    [SerializeField] Text highestTxt;
    [SerializeField] AudioSource ac;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        PlayerPrefs.SetFloat("score", score);


        highestTxt.text = $"{PlayerPrefs.GetFloat("highest"):F0}";
    }
    private void Update()
    {
        if (isStarted && !_gameOver)
        {
            score += Time.deltaTime;
            scoreTxt.text = $"{score:F0}";
            leaderboard.SetActive(false);
        }
        if (_gameOver)
        {
            ac.Stop();
            panel.SetActive(true);
            PlayerPrefs.SetFloat("score", score);
            if (PlayerPrefs.HasKey("highest"))
            {
                if(score> PlayerPrefs.GetFloat("highest"))
                {
                    PlayerPrefs.SetFloat("highest", score);
                }
            }
            else
            {
                PlayerPrefs.SetFloat("highest", score);
            }
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
