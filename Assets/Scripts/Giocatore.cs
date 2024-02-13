using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Giocatore : MonoBehaviour
{

    public int maxLives = 3; // Numero massimo di vite
    private int currentLives; // Vite attuali del giocatore

    void Start()
    {
        currentLives = 1; // Inizializza le vite attuali al massimo
    }

    public void TakeDamage()
    {
        currentLives--; // Sottrae una vita al giocatore
        if (currentLives <= 0)
        {
            // Se il giocatore ha esaurito le vite, termina la partita
            SceneManager.LoadScene(3); // Carica la scena di Game Over
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
