using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public Text timetext, score_txt, bestscore;
    public float currentTime;
    public float duration;
    public bool time_pause = true;
    public GameObject taptoplay;
    public AudioSource wrong_sound, merge_sound;
    public GameObject restart_panel;
    public int Score;
    public GameObject[] cubes;
    public GameObject spawnPoint;
    public GameObject hand;



    void Awake()
    {
        currentTime = duration;
        timetext.text = currentTime.ToString();
        Time.timeScale = 0;
        StartCoroutine(CountdownTime());
        bestscore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }


    void Update()
    {

        if (currentTime <= 0)
        {
            restart_panel.SetActive(true);
            Time.timeScale = 0;
        }

        score_txt.text = Score.ToString();

        if (Score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", Score);
            bestscore.text = "BEST " + Score.ToString();


        }
        bestscore.text = "BEST " + Score.ToString();
    }

    private IEnumerator CountdownTime()
    {

        while (currentTime >= 0 && time_pause == true)
        {

            timetext.text = currentTime.ToString();
            yield return new WaitForSeconds(1f);
            currentTime--;

        }
        yield return null;
    }

    private void OnSplashAdClicked()
    {
        Debug.Log("SplashAdClicked.");
    }
    public void Tapto()
    {
        Time.timeScale = 1f;
        taptoplay.SetActive(false);

        StartCoroutine(handwait());
    }


    public void RestartGame()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);


    }
    IEnumerator handwait()
    {
        yield return new WaitForSeconds(0.1f);
        hand.SetActive(true);


    }

}

