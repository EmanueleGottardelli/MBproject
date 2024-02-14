using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiaNavicella : MonoBehaviour
{
    public GameObject mynav;
    public int viteIniziali = 1;
    public int viteAttuali;
    
    // Start is called before the first frame update
    void Start()
    {
        viteAttuali = viteIniziali;
        Debug.Log("Numero di vite: " + viteAttuali);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
