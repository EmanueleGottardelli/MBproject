using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    public InputField usernameInputField;
    public InputField passwordInputField;
    public Button loginButton;
    public Text errorMessageText;

    void Start()
    {
        // Controlla se ci sono credenziali memorizzate e le imposta automaticamente nei campi di input
        if (PlayerPrefs.HasKey("username"))
        {
            usernameInputField.text = PlayerPrefs.GetString("username");
        }

        // Aggiungi listener per il click del pulsante di accesso
        loginButton.onClick.AddListener(OnLoginButtonClick);
    }

    void OnLoginButtonClick()
    {
        string username = usernameInputField.text;
        string password = passwordInputField.text;

        // Simula un controllo delle credenziali
        if (username == "admin" && password == "password")
        {
            // Salva il nome utente nelle preferenze del giocatore
            PlayerPrefs.SetString("username", username);
            PlayerPrefs.Save();

            // Naviga alla scena principale del gioco
            SceneManager.LoadScene("MainScene");
        }
        else
        {
            // Mostra un messaggio di errore se le credenziali sono errate
            errorMessageText.text = "Username o password errati.";
        }
    }
}
