using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballLauncher : MonoBehaviour
{
    public float launchForce=5000f;
    private bool launched = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) & !launched) {
            print("Launching ball");
            launched = true;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, launchForce));
        }
        //m_RigidBody2D = ball.GetComponent<Rigidbody2D>();
        //m_RigidBody2D.AddForce(m_RigidBody2D.transform.right * 1000.0f, ForceMode2D.Impulse);

    }
}
