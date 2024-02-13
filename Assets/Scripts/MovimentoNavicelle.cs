using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.ComponentModel.Design;
public class MovimentoNavicelle : MonoBehaviour
{
    public float velocita;
    public GameObject explosion;
    public float lifepoints;
    public int _tempScore;
    public Giocatore giocatore;


    void Start()
    {

    }
    void AddScore()
    {
        // prende il punteggio attuale
        int _temp = PlayerPrefs.GetInt("CurrentScore");
        // aggiungiamo i punti e salviamo il nuovo risultato
        _temp = _temp + _tempScore;
        PlayerPrefs.SetInt("CurrentScore", _temp);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals("laser"))
        {
            Destroy(other.gameObject);
            lifepoints -= other.gameObject.GetComponent<Laser>().danno;
            if (lifepoints <= 0)
            {
                Destroy(this.gameObject);
                GameObject explosionInstance = Instantiate(explosion, transform.position, transform.rotation);
                // Distruggi l'oggetto di esplosione dopo 0.3 secondi
                Destroy(explosionInstance, 0.3f);
                AddScore();

            }
        }
    }
   

    
    // Update viene chiamata ogni frame
    void Update()
    {
        this.transform.position -= new Vector3(velocita, 0, 0) * Time.deltaTime;

        // Controlla se la navicella � oltre la posizione specificata
        if (this.transform.position.x <= -9.0f)
        {
            giocatore.TakeDamage();
            Destroy(this.gameObject);
        }
    }
}