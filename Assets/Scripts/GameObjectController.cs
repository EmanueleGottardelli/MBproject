using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameObjectController : MonoBehaviour
{
    float gameOverTime;
    // Start is called before the first frame update
    void Start()
    {
        gameOverTime = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        gameOverTime -= Time.deltaTime;
        if (gameOverTime <= 0.0f)
            SceneManager.LoadScene(1);
    }
}
