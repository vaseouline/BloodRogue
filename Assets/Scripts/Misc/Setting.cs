using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

//Basic script for setting
//Probably not gonna use some of the function listed below

public class Setting : MonoBehaviour
{
    public AudioMixer audioMixer;
    //float currentVolume;

    //GameState (?)
    public void saveSetting()
    {

    }

    public void loadSetting()
    {

    }

    //Audio
    public void setVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
        //currentVolume = volume;
    }
    
    //Resolution (?)
    public void setFullScreen(bool isfullscreen)
    {
        Screen.fullScreen = isfullscreen;

    }

    public void setBrightness(float brightness)
    {

    }

    //Controls (?) Configure/ Rebinding Controls?

    //Setting Difficulty (?)
    public void setDifficulty(int difficulty)
    {

    }  



    
}
