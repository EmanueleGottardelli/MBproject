using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Signin : MonoBehaviour
{
    public InputField usernameInputField;
    public InputField passwordInputField;
    public Button SignIn;
    public Text errorMessageText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

   public void OnRegisterButtonClick()
    {
        string username = usernameInputField.text;
        string password = passwordInputField.text;

        // Simula un processo di registrazione
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            errorMessageText.text = "Inserire un nome utente e una password.";
        }
        else if (PlayerPrefs.HasKey(username))
        {
            errorMessageText.text = "Il nome utente esiste già.";
        }
        else
        {
            // Registra il nuovo utente
            PlayerPrefs.SetString(username, password);
            PlayerPrefs.Save();
            errorMessageText.text = "Registrazione completata. Effettua l'accesso.";
            SceneManager.LoadScene(0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
