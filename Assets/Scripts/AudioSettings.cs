using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioSettings : MonoBehaviour {

    public Button btnSave;

    public Button btnCancel;

    private float currentVolume;

    private VolumeManagement vm;

    private Slider sldr;

    private MainMenuController mmc;

    private void Awake()
    {
        mmc = FindObjectOfType<MainMenuController>();
    }
    // Use this for initialization
    void Start () {
        vm = GameObject.Find("AudioMixerControl").GetComponent<VolumeManagement>();
        sldr = GetComponentInChildren<Slider>();
        vm.MasterVolume = currentVolume = sldr.value;
        btnSave.onClick.AddListener(() => Save());
        btnCancel.onClick.AddListener(() => SetVolume(currentVolume));
	}

    void Save()
    {
        currentVolume = sldr.value;
        mmc.ShowMainMenu();
    }
	
	void SetVolume(float volume)
    {
        sldr.value = volume;
        mmc.ShowMainMenu();
    }
}
