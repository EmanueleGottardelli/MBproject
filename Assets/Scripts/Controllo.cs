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
    public GameObject bonusLaserVelocitax2;
    public GameObject vita;
    float spawnTimerVita = 40.0f;
    float spawnTimerBonus = 35.0f;
    float spawnTimerBonusCurrent;
    float i;
    float j;
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
        j = 0;
        i = 0;
        currentspawnTimer = ispawnTimer;
        currentspawnTimer2 = ispawnTimer2;
        currentspawnTimer3 = ispawnTimer3;
        spawnTimerBonusCurrent = spawnTimerBonus;
        PlayerPrefs.SetInt("CurrentScore", 0); // azzeriamo il contatore
        PlayerPrefs.SetInt("CurrentVite", 1);

    }

    void SpawnEnemy1()
    {
        i = i + 0.4f;
        GameObject instance = (GameObject)Instantiate(nemico,
            new Vector3(10, Random.Range(-4.0f, 3.3f), -2.0f),
            transform.rotation);

        // Resetta il timer di spawn al valore iniziale
        currentspawnTimer = ispawnTimer - (spawnTimerDecreaseRate * (i));
    }

    void SpawnEnemy2()
    {
        i = i + 0.4f;
        GameObject instance = (GameObject)Instantiate(nemico2,
            new Vector3(10, Random.Range(-4.0f, 3.3f), -2.0f),
            transform.rotation);

        // Resetta il timer di spawn al valore iniziale
        currentspawnTimer2 = ispawnTimer2 - (spawnTimerDecreaseRate * (i));
    }

    void SpawnEnemy3()
    {
        i = i + 0.4f;
        GameObject instance = (GameObject)Instantiate(nemico3,
            new Vector3(10, Random.Range(-4.0f, 3.3f), -2.0f),
            transform.rotation);
        // Resetta il timer di spawn al valore iniziale
        currentspawnTimer3 = ispawnTimer3 - (spawnTimerDecreaseRate * (i));
    }

    void Update()
    {
        spawnTimerVita -= Time.deltaTime;
        spawnTimerBonusCurrent -= Time.deltaTime;
        currentspawnTimer -= Time.deltaTime;
        currentspawnTimer2 -= Time.deltaTime;
        currentspawnTimer3 -= Time.deltaTime;
        punteggio.text = PlayerPrefs.GetInt("CurrentScore", 0).ToString();
        contVite.text = PlayerPrefs.GetInt("CurrentVite", 1).ToString();

        if (currentspawnTimer <= 0.0f)
        {
            SpawnEnemy1();
            if (currentspawnTimer <= 0.7f) // Limita il timer minimo per evitare valori negativi o troppo vicini a zero
            {
                currentspawnTimer = 0.7f;
            }
        }

        if (currentspawnTimer2 <= 0.0f)
        {
            SpawnEnemy2();
            if (currentspawnTimer2 < 1.3f) // Limita il timer minimo per evitare valori negativi o troppo vicini a zero
            {
                currentspawnTimer2 = 1.3f;
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
            spawnTimerVita = 40.0f;
        }


        if (spawnTimerBonusCurrent <= 0.0f)
        {
            j = j + 3;
            float randomValue = Random.value; // Genera un numero casuale tra 0 e 1

            // Se il numero casuale è inferiore a 0.5, spawniamo il primo bonus, altrimenti il secondo
            if (randomValue < 0.7f)
            {

                GameObject instance = (GameObject)Instantiate(bonusLaserDannox2,
                new Vector3(10, Random.Range(-4.0f, 3.3f), -2.0f),
                transform.rotation);
                spawnTimerBonusCurrent = spawnTimerBonus - j;
                if(spawnTimerBonusCurrent <= 20.0f)
                {
                    spawnTimerBonusCurrent = 20.0f;
                }
            }
            else
            {
                GameObject instance = (GameObject)Instantiate(bonusLaserVelocitax2,
               new Vector3(10, Random.Range(-4.0f, 3.3f), -2.0f),
               transform.rotation);
                spawnTimerBonusCurrent = spawnTimerBonus - j;
                if (spawnTimerBonusCurrent <= 20.0f)
                {
                    spawnTimerBonusCurrent = 20.0f;
                }
            }
        }
    }
}