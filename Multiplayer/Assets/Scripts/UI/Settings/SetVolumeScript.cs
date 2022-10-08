using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SetVolumeScript : MonoBehaviour
{
    //Audio
    public Slider mainVolumeSlider;
    public AudioMixer audioMixer;
    public string exposedParametrer;

    //Sound Voids
    public void SetVolume(float sliderValue)
    {
        audioMixer.SetFloat(exposedParametrer, Mathf.Log10(sliderValue) * 20);
        if (sliderValue == 0)
        {
            audioMixer.SetFloat(exposedParametrer, -60);
        }
    }
}
