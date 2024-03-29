using UnityEngine;
using UnityEngine.UI;

public class AudioSliderController : MonoBehaviour
{
    public AudioSource audioSource;
    public Slider slider;

    void Start()
    {
        // Assicurati di avere un riferimento all'AudioSource
        if (audioSource == null)
            audioSource = GetComponent<AudioSource>();

        // Assicurati di avere un riferimento allo Slider
        if (slider == null)
            slider = GetComponent<Slider>();

        // Imposta il valore dello Slider sul volume corrente dell'AudioSource
        slider.value = audioSource.volume;

        // Aggiungi un listener per rilevare i cambiamenti nello Slider e regolare il volume di conseguenza
        slider.onValueChanged.AddListener(delegate { OnSliderValueChanged(); });
    }

   public void OnSliderValueChanged()
    {
        // Imposta il volume dell'AudioSource in base al valore dello Slider
        audioSource.volume = slider.value;
    }
}
