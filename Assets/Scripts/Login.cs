using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    public InputField usernameInputField;
    public InputField passwordInputField;
    public Button loginButton;
    public Text errorMessageText;
    public Button signButton;

    public string currentUser;
    public int currentRecord;

    void Start()
    {
        
    }

    public void OnLoginButtonClick()
    {
        string username = usernameInputField.text;
        string password = passwordInputField.text;

        // Simula un controllo delle credenziali
        if (CheckCredentials(username, password))
        {
            currentUser = PlayerPrefs.GetString("username");
            currentRecord = PlayerPrefs.GetInt(currentUser + "HighScore",0);
            Debug.Log("username: " + currentUser);
            Debug.Log("record: " + currentRecord);
            // Naviga alla scena principale del gioco
            SceneManager.LoadScene(1);

        }
        else
        {
            // Mostra un messaggio di errore se le credenziali sono errate
            errorMessageText.text = "Nome utente o password errati.";
        }
    }
    public void OnSignInButtonClick()
    {
        SceneManager.LoadScene(4);
    }

    public bool CheckCredentials(string username, string password)
    {
        // Verifica se il nome utente e la password corrispondono
        if (PlayerPrefs.HasKey(username) && PlayerPrefs.GetString(username) == password)
        {
            return true;
        }
        return false;
    }
}
