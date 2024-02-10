using UnityEngine;
using UnityEngine.SceneManagement;

public class Menù : MonoBehaviour
{
    public void LoadNextScene()
    {
        SceneManager.LoadScene(2);
    }

    public void CaricamentoMenu()
    {
        SceneManager.LoadScene(1);
    }
}
