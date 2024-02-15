using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using JetBrains.Annotations;
public class Controllo : MonoBehaviour
{
    public GameObject nemico;
    public GameObject nemico2;
    public GameObject nemico3;
    public GameObject bonusLaserDannox2;
    public GameObject vita;
    float spawnTimerVita = 30.0f;
    float spawnTimerBonusDannox2 = 15.0f;
    float i;
    float ispawnTimer = 2.0f;
    float ispawnTimer2 = 5.0f;
    float ispawnTimer3 = 10.0f;
    float currentspawnTimer;
    float currentspawnTimer2;
    float currentspawnTimer3;
    float spawnTimerDecreaseRate = 0.05f;
    public Text punteggio;
    public Text contVite;
    
    void Start()
    {
        i = 0;
        currentspawnTimer = ispawnTimer;
        currentspawnTimer2 = ispawnTimer2;
        currentspawnTimer3 = ispawnTimer3;
        PlayerPrefs.SetInt("CurrentScore", 0); // azzeriamo il contatore
        PlayerPrefs.SetInt("CurrentVite", 1);

    }

    void SpawnEnemy1()
    {
        i = i + 1;
        GameObject instance = (GameObject)Instantiate(nemico,
            new Vector3(10, Random.Range(-4.0f, 3.3f), -2.0f),
            transform.rotation);

        // Resetta il timer di spawn al valore iniziale
        currentspawnTimer = ispawnTimer - (spawnTimerDecreaseRate * (i));
    }

    void SpawnEnemy2()
    {
        i = i + 1;
        GameObject instance = (GameObject)Instantiate(nemico2,
            new Vector3(10, Random.Range(-4.0f, 3.3f), -2.0f),
            transform.rotation);

        // Resetta il timer di spawn al valore iniziale
        currentspawnTimer2 = ispawnTimer2 - (spawnTimerDecreaseRate * (i));
    }

    void SpawnEnemy3()
    {
        i = i + 1;
        GameObject instance = (GameObject)Instantiate(nemico3,
            new Vector3(10, Random.Range(-4.0f, 3.3f), -2.0f),
            transform.rotation);
        // Resetta il timer di spawn al valore iniziale
        currentspawnTimer3 = ispawnTimer3 - (spawnTimerDecreaseRate * (i));
    }

    void Update()
    {
        spawnTimerVita -= Time.deltaTime;
        spawnTimerBonusDannox2 -= Time.deltaTime;
        currentspawnTimer -= Time.deltaTime;
        currentspawnTimer2 -= Time.deltaTime;
        currentspawnTimer3 -= Time.deltaTime;
        punteggio.text = PlayerPrefs.GetInt("CurrentScore", 0).ToString();
        contVite.text = PlayerPrefs.GetInt("CurrentVite", 1).ToString();

        if (currentspawnTimer <= 0.0f)
        {
            SpawnEnemy1();
            if (currentspawnTimer < 0.5f) // Limita il timer minimo per evitare valori negativi o troppo vicini a zero
            {
                currentspawnTimer = 0.5f;
            }
        }

        if (currentspawnTimer2 <= 0.0f)
        {
            SpawnEnemy2();
            if (currentspawnTimer2 < 1.0f) // Limita il timer minimo per evitare valori negativi o troppo vicini a zero
            {
                currentspawnTimer2 = 1.0f;
            }
        }

        if (currentspawnTimer3 <= 0.0f)
        {
            SpawnEnemy3();
            if (currentspawnTimer3 < 3.0f) // Limita il timer minimo per evitare valori negativi o troppo vicini a zero
            {
                currentspawnTimer3 = 3.0f;
            }

        }

        if (spawnTimerVita <= 0.0f)
        {
            GameObject instance = (GameObject)Instantiate(vita,
            new Vector3(10, Random.Range(-4.0f, 3.3f), -2.0f),
            transform.rotation);
            spawnTimerVita = 30.0f;
        }

        if (spawnTimerBonusDannox2 <= 0.0f)
        {
            GameObject instance = (GameObject)Instantiate(bonusLaserDannox2,
            new Vector3(10, Random.Range(-4.0f, 3.3f), -2.0f),
            transform.rotation);
            spawnTimerBonusDannox2 = 15.0f;
        }

        /*if (shootTimer <= 0.0f)
        {
            if (dannoDoppio.bonusDannox2 == false)
            {
                if (Input.GetButton("Fire1"))
                {
                    Vector3 spawnLaserPos = Camera.main.ScreenToWorldPoint(
                        new Vector3(-5.0f, Input.mousePosition.y, 8));
                    Instantiate(laser, spawnLaserPos, Quaternion.identity);
                    shootTimer = 0.3f;
                }
            }
            else
            {
                if (Input.GetButton("Fire1"))
                {
                    Vector3 spawnLaserPos = Camera.main.ScreenToWorldPoint(
                        new Vector3(-5.0f, Input.mousePosition.y, 8));
                    Instantiate(laserDannox2, spawnLaserPos, Quaternion.identity);
                    shootTimer = 0.3f;
                }
            }
        }*/

        
    }
}