using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixer Volume;

    void Start()
    {
        Volume.SetFloat("MainV", GlobalData.getVolume());
    }
}