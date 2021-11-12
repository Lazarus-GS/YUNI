using UnityEngine;
using UnityEngine.Audio;

public class MMnenuVol : MonoBehaviour
{
  

    public AudioMixer audioMixer;

    public void changeVolume(float Volume)
    {
        audioMixer.SetFloat("masterVolume", Volume);
    }
}
