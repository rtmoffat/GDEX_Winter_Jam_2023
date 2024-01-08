using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using FMODUnity;
using FMOD.Studio;

public class MusicManager : MonoBehaviour
{
    public static FMOD_Scene_Change instance = null;

    [SerializeField]
    public FMODUnity.EventReference fmodEvent;
    //private string music = null;

    public FMOD.Studio.EventInstance Music;
    //private FMOD.Studio.EventInstance levelMusic;

    private void Awake()
    {
        DontDestroyOnLoad(this);

    }
    // Start is called before the first frame update
    void Start()
    {
        Music = FMODUnity.RuntimeManager.CreateInstance("event:/MUSIC/Music");
        Music.start();
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "TitleScreen")
        {
            Music.setParameterByName("Music", 1);
        }
        if (SceneManager.GetActiveScene().name == "Test_Level")
        {
            Music.setParameterByName("Music", 2);
        }
        if (SceneManager.GetActiveScene().name == "Level_1")
        {
            Music.setParameterByName("Music", 2);
        }
    }


}