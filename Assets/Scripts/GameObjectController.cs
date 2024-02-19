using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameObjectController : MonoBehaviour
{
    public Text countdownText;
    public Text scoreText;
    public Text highScoreText;

    public float gameOverTime;
    public bool countDown;

    public MiaNavicella player;
   

    void CheckHighscore()
    {
        int _score = PlayerPrefs.GetInt(player.user.currentUser + "CurrentScore", 0);
        if (_score > player.record)
            PlayerPrefs.SetInt(player.user.currentUser + "HighScore", _score);
        player.record = PlayerPrefs.GetInt(player.user.currentUser + "HighScore", _score);
        PlayerPrefs.Save();
    }

    // Start is called before the first frame update
    void Start()
    {

        countDown = true;
        gameOverTime = 5.0f;
        CheckHighscore();
        scoreText.text = "Score: " + PlayerPrefs.GetInt(player.user.currentUser + "CurrentScore", 0);
        highScoreText.text = "Highscore: " + PlayerPrefs.GetInt(player.user.currentUser + "HighScore", 0);
        PlayerPrefs.Save();
    }

    // Update is called once per frame
    void Update()
    {

        gameOverTime -= Time.deltaTime;
        int secondsLeft = Mathf.CeilToInt(gameOverTime);
        countdownText.text = "Return to menu in: " + secondsLeft.ToString();
        if (gameOverTime <= 0.0f)
            SceneManager.LoadScene(1);
    }
}
