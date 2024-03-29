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
    public MiaNavicella player;
    public Vita vita;

    
    void Start()
    {      
        // Verifica se player � null
        if (player == null)
        {
            Debug.LogWarning("Il riferimento a player � null!");
        }
    }
    void AddScore(string username)
    {
        // prende il punteggio attuale
        int _temp = PlayerPrefs.GetInt( username + "CurrentScore",0);
        // aggiungiamo i punti e salviamo il nuovo risultato
        _temp = _temp + _tempScore;
        PlayerPrefs.SetInt(username + "CurrentScore", _temp);
        PlayerPrefs.Save();
        Debug.Log("Punteggio aggiornato per " + username + ": " + _temp);

        //int highScore = PlayerPrefs.GetInt(username +"HighScore", 0);
        //Debug.Log("username: "+ username + "--> High score attuale: "+ highScore);
    }


    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals("laser"))
        {
            Destroy(other.gameObject);
            lifepoints -= other.gameObject.GetComponent<Laser>().danno;
            Debug.Log("Lifepoints : " + lifepoints);
            if (lifepoints <= 0)
            {
                Destroy(this.gameObject);
                GameObject explosionInstance = Instantiate(explosion, transform.position, transform.rotation);
                // Distruggi l'oggetto di esplosione dopo 0.3 secondi
                Destroy(explosionInstance, 0.3f);
                AddScore(player.user.currentUser);

            }
        }
    }

  

    // Update viene chiamata ogni frame
    void Update()
    {
        // Verifica se player � null
        if (player == null)
        {
            Debug.LogWarning("Il riferimento a player � null!");
        }
        this.transform.position -= new Vector3(velocita, 0, 0) * Time.deltaTime;

        // Controlla se la navicella � oltre la posizione specificata
        if (this.transform.position.x <= -9.0f)
        {
            Destroy(this.gameObject);
            player.viteAttuali--;
            vita.MenoScoreVita();
            Debug.Log("Numero di vite: " + player.viteAttuali);
            if (player.viteAttuali <= 0)
            {
                SceneManager.LoadScene(3);
            }
        }
    }
}