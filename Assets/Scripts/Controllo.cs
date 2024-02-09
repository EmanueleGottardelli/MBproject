using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Controllo : MonoBehaviour
{
    public GameObject nemico;
    public GameObject nemico2;
    public GameObject nemico3;
    public GameObject laser;
    float spawnTimer;
    float spawnTimer2;
    float spawnTimer3;
    float shootTimer;
    public Text punteggio;
    void Start()
    {
        spawnTimer = 2.0f;
        spawnTimer2 = 5.0f;
        spawnTimer3 = 10.0f;
        PlayerPrefs.SetInt("CurrentScore", 0); // azzeriamo il contatore

    }
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        spawnTimer2 -= Time.deltaTime;
        spawnTimer3 -= Time.deltaTime;
        shootTimer -= Time.deltaTime;
        punteggio.text = PlayerPrefs.GetInt("CurrentScore", 0).ToString();

        if (spawnTimer <= 0.0f)
        {
            GameObject instance = (GameObject)Instantiate(nemico,
                new Vector3(10, Random.Range(-4.0f, 3.3f), -2.0f),
                transform.rotation);
            spawnTimer = 2.0f;
        }

        if (spawnTimer2 <= 0.0f)
        {
            GameObject instance = (GameObject)Instantiate(nemico2,
                new Vector3(10, Random.Range(-4.0f, 3.3f), -2.0f),
                transform.rotation);
            spawnTimer2 = 5.0f;
        }

        if (spawnTimer3 <= 0.0f)
        {
            GameObject instance = (GameObject)Instantiate(nemico3,
                new Vector3(10, Random.Range(-4.0f, 3.3f), -2.0f),
                transform.rotation);
            spawnTimer3 = 10.0f;
        }

        if (shootTimer <= 0.0f)
        {
            if (Input.GetButton("Fire1"))
            {
                Vector3 spawnLaserPos = Camera.main.ScreenToWorldPoint(
                    new Vector3(-5.0f, Input.mousePosition.y, 8));
                Instantiate(laser, spawnLaserPos, Quaternion.identity);
                shootTimer = 0.3f;
            }
        }
    }
}