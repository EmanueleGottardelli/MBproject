using UnityEngine;
using UnityEngine.UI;

public class ForceOrderInLayer : MonoBehaviour
{
    public int desiredOrderInLayer = 0; // L'ordine di rendering desiderato per questo oggetto UI

    void Start()
    {
        // Imposta l'ordine di rendering desiderato per questo oggetto UI
        GetComponent<Canvas>().sortingOrder = desiredOrderInLayer;
    }
}
