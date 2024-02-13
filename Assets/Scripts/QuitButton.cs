using UnityEngine;
using UnityEngine.UI;

public class QuitButton : MonoBehaviour
{
    void Start()
    {
        // Assicura che il bottone sia associato alla funzione QuitGame() quando viene cliccato
        GetComponent<Button>().onClick.AddListener(QuitGame);
    }

   public void QuitGame()
    {
        // Esci dal gioco quando il bottone viene cliccato
        Application.Quit();
    }
}
