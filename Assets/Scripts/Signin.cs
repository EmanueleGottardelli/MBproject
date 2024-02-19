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

    // Dizionario per associare gli ID ai nomi utente
    Dictionary<string, int> userIdMap;

    // Start is called before the first frame update
    void Start()
    {
        // Inizializza il dizionario caricando i dati salvati precedentemente
        LoadUserIdMap();
    }

    void LoadUserIdMap()
    {
        // Carica il dizionario salvato precedentemente, se esiste
        string userIdMapJson = PlayerPrefs.GetString("UserIdMap", "{}");
        userIdMap = JsonUtility.FromJson<Dictionary<string, int>>(userIdMapJson);
    }

    void SaveUserIdMap()
    {
        // Salva il dizionario
        string userIdMapJson = JsonUtility.ToJson(userIdMap);
        PlayerPrefs.SetString("UserIdMap", userIdMapJson);
        PlayerPrefs.Save();
    }

    public void OnRegisterButtonClick()
    {
        string username = usernameInputField.text;
        string password = passwordInputField.text;

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            errorMessageText.text = "Inserire un nome utente e una password.";
        }
        else if (userIdMap.ContainsKey(username))
        {
            errorMessageText.text = "Il nome utente esiste già.";
        }
        else
        {
            // Genera un nuovo ID per il nuovo utente
            int newUserId = GenerateUniqueUserId();

            // Aggiungi il nuovo utente al dizionario
            userIdMap.Add(username, newUserId);

            // Registra il nuovo utente con la sua password
            PlayerPrefs.SetString("username", username);
            PlayerPrefs.SetString(username, password);
            // Imposta l'highscore del nuovo utente a 0
            PlayerPrefs.SetInt(username + "HighScore", 0);

            // Salva il dizionario aggiornato e i dati dell'utente
            SaveUserIdMap();
            PlayerPrefs.Save();

            errorMessageText.text = "Registrazione completata. Effettua l'accesso.";
            SceneManager.LoadScene(0);
        }
    }

    public void RitornaAlLogin()
    {
        SceneManager.LoadScene(0);
    }
    int GenerateUniqueUserId()
    {
        // Genera un ID univoco basato sul timestamp attuale
        return (int)System.DateTime.Now.Ticks;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
