using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vita : MonoBehaviour
{
    public float velocita;
    public GameObject explosion;
    public float lifepoints;
    public MiaNavicella player;
    public int _tempScoreVita;


    // Start is called before the first frame update
    void Start()
    {
        // Verifica se player è null
        if (player == null)
        {
            Debug.LogWarning("Il riferimento a player è null!");
        }
    }

    public void AddScoreVita()
    {
        // prende il punteggio attuale
        int _temp2 = PlayerPrefs.GetInt("CurrentVite");
        if (_temp2 <= 2) 
        {
            _temp2 = _temp2 + _tempScoreVita;
            PlayerPrefs.SetInt("CurrentVite", _temp2);
        }     
    }

    public void MenoScoreVita()
    {
        // prende il punteggio attuale
        int _temp3 = PlayerPrefs.GetInt("CurrentVite");
        // aggiungiamo i punti e salviamo il nuovo risultato
        _temp3 = _temp3 - _tempScoreVita;
        PlayerPrefs.SetInt("CurrentVite", _temp3);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals("laser"))
        {
            Destroy(other.gameObject);
            lifepoints -= other.gameObject.GetComponent<Laser>().danno;
            if (lifepoints <= 0)
            {
                if(player.viteAttuali <= 2)
                {
                    player.viteAttuali++;
                    Debug.Log("Numero di vite: " + player.viteAttuali);               
                }
                Destroy(this.gameObject);
                GameObject explosionInstance = Instantiate(explosion, transform.position, transform.rotation);
                // Distruggi l'oggetto di esplosione dopo 0.3 secondi
                Destroy(explosionInstance, 0.3f);
                AddScoreVita();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Verifica se player è null
        if (player == null)
        {
            Debug.LogWarning("Il riferimento a player è null!");
        }
        this.transform.position -= new Vector3(velocita, 0, 0) * Time.deltaTime;

        if (this.transform.position.x <= -9.0f)
        {
            Destroy(this.gameObject);
        }
    }
}
