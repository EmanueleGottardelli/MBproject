using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameObjectController : MonoBehaviour
{
    public Text countdownText;

    public float gameOverTime;
    public bool countDown;
    // Start is called before the first frame update
    void Start()
    {
        countDown = true;
        gameOverTime = 5.0f;
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
