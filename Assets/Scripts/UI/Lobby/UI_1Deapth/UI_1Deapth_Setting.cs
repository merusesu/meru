using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class UI_1Deapth_Setting : MonoBehaviour
{
    public AudioMixer AudioMixer;
    public Slider Master;
    public Slider BGM;
    public Slider SFX;

    
    public void MasterControl()
    {
        float sound = Master.value;

        if (sound == -40f) AudioMixer.SetFloat("Master", -80);
        else AudioMixer.SetFloat("Master", sound);
    }
    
    public void BGMControl()
    {
        float sound = BGM.value;

        if (sound == -40f) AudioMixer.SetFloat("BGM", -80);
        else AudioMixer.SetFloat("BGM", sound);
    }

    public void SFXControl()
    {
        float sound = SFX.value;

        if (sound == -40f) AudioMixer.SetFloat("SFX", -80);
        else AudioMixer.SetFloat("SFX", sound);
    }

    public void OnBtnBack()
    {
        transform.gameObject.SetActive(false);
    }

}
