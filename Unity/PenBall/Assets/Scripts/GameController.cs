using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    public void startGame()
    {
        
        SceneManager.LoadScene("Level_1",LoadSceneMode.Single);
        print("starting game");
    }
    public void quitGame()
    {
        print("quitting!");
        Application.Quit();

    }
}