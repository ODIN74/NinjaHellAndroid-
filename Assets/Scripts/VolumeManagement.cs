using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeManagement : MonoBehaviour {

    public AudioMixer am;

    private float currentVolume;

    public float MasterVolume
    {
        get
        {
            am.GetFloat("masterVolume", out currentVolume);
            return currentVolume;
        }

        set
        {
            am.SetFloat("masterVolume", value);
        }
    }
}
