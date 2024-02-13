using UnityEngine;
using UnityEngine.SceneManagement;

public class Menù : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject settingsMenuPanel;

   void start()
    {
        mainMenuPanel.SetActive(true);
        settingsMenuPanel.SetActive(false);
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(2);
    }

    public void CaricamentoMenu()
    {
        SceneManager.LoadScene(1);
    }

    
    public void ActivateMainMenuPanel()
    {
        mainMenuPanel.SetActive(true);
        settingsMenuPanel.SetActive(false);
    }

    public void ActivateSettingsMenuPanel()
    {
        mainMenuPanel.SetActive(false);
        settingsMenuPanel.SetActive(true);
    }
}
