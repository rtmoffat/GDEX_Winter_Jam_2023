using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class playercontroller : MonoBehaviour
{
    private Vector2 initPostion;
    // Start is called before the first frame update
    void Start()
    {
        initPostion = transform.position;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name=="Lower_Boundary_SS")
        {
            Debug.Log("fell");
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }

}
