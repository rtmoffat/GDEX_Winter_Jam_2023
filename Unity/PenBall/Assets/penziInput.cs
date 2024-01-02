using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class penziInput : MonoBehaviour
{
    [SerializeField]
    public InputAction launch;
    public float launchForce = 5000f;

    private bool launched = false;
    // Start is called before the first frame update
    void Awake()
    {
        launch.Enable();
        launch.performed += ctx => { onLaunchPressed(ctx); };
    }

    void onLaunchPressed(InputAction.CallbackContext context)
    {
        if (!launched)
        {
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, launchForce));
            launched = true;
            Debug.Log("launched!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
