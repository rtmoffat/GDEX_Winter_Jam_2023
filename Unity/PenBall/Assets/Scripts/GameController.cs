using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
//using UnityEditor.AnimatedValues;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    //public GameObject ball=null;
    //Rigidbody2D m_RigidBody2D;
    //public Camera m_Camera;
    
    /*public GameObject leftFlipperRotationContainer_obj;
    public GameObject rightFlipperRotationContainer_obj;
    private Vector3 leftFlipperRotationOriginalPosition_V3;
    private Vector3 rightFlipperRotationOriginalPosition_V3;
    private Vector3 flipperRotation_V3=new Vector3(0f, 0f, 50.0f);
    private float flipperRotationSpeed=5.0f;*/

    //private Quaternion m_Camera_Rotation;
    // Start is called before the first frame update
    void Start()
    {
        /*if (leftFlipperRotationContainer_obj != null)
        {
            leftFlipperRotationOriginalPosition_V3 = leftFlipperRotationContainer_obj.transform.rotation.eulerAngles;
        }
        if (rightFlipperRotationContainer_obj != null)
        {
            rightFlipperRotationOriginalPosition_V3 = rightFlipperRotationContainer_obj.transform.rotation.eulerAngles;
        }*/
        //Kick the ball into motion
        //only do this if the ball exists
        /*if (ball)
        {
            //Get initial camera rotation and don't change it. We only care about x/y axis.
            m_Camera_Rotation = m_Camera.transform.rotation;
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }

        //Keep camera initial rotation
        //m_Camera.transform.rotation = m_Camera_Rotation;

        //Flipper controls
        /*
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Vector3 destination = new Vector3(0, 0, -30);
            leftFlipperRotationContainer_obj.transform.eulerAngles = Vector3.Lerp(leftFlipperRotationContainer_obj.transform.rotation.eulerAngles,
                                                 destination,
                                                 Time.deltaTime);
        }
        
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            Vector3 destination = new Vector3(0, 0, -30);
            leftFlipperRotationContainer_obj.transform.eulerAngles = Vector3.Lerp(leftFlipperRotationContainer_obj.transform.rotation.eulerAngles,
                                                 destination,
                                                 Time.deltaTime);
        }
        */
    }
    private void LateUpdate()
    {
        
    }
    public void startGame()
    {
        
        SceneManager.LoadScene("New_Level",LoadSceneMode.Single);
        print("starting game");
    }
    public void testLevel()
    {
        print("loading test level");
        SceneManager.LoadScene("Level_1", LoadSceneMode.Single);
    }
    public void quitGame()
    {
        print("quitting!");
        Application.Quit();

    }
}
