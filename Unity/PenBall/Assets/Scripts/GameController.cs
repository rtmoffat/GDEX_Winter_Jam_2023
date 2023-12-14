using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.AnimatedValues;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject ball;
    Rigidbody2D m_RigidBody2D;
    public Camera m_Camera;
    private Quaternion m_Camera_Rotation;
    // Start is called before the first frame update
    void Start()
    {
        //Kick the ball into motion
        m_RigidBody2D = ball.GetComponent<Rigidbody2D>();
        m_RigidBody2D.AddForce(m_RigidBody2D.transform.right*1000.0f,ForceMode2D.Impulse);
        //Get initial camera rotation and don't change it. We only care about x/y axis.
        m_Camera_Rotation=m_Camera.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        //Keep camera initial rotation
        m_Camera.transform.rotation = m_Camera_Rotation;
    }
    private void LateUpdate()
    {
        
    }
    public void startGame()
    {
        
        SceneManager.LoadScene("Level_1",LoadSceneMode.Single);
        print("starting game");
    }
    public void testLevel()
    {
        print("loading test level");
        SceneManager.LoadScene("Test_Level", LoadSceneMode.Single);
    }
    public void quitGame()
    {
        print("quitting!");
        Application.Quit();

    }
}
