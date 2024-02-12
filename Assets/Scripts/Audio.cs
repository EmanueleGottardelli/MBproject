using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public bool canMute;

    void Start()
    {
        canMute = true;
    }

    public void OnUi()
    {
            if(canMute)
            {
                AudioListener.pause = true;
                canMute = false;
            }
            else
            {
                AudioListener.pause = false;
                canMute = true;
            }
    }
}