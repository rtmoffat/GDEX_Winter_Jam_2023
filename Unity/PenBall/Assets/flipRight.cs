using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class flipRight : MonoBehaviour
{
    //public InputAction flipLeft;
    public InputAction flipRightFlipper;



    // Start is called before the first frame update
    void Awake()
    {
        //flipLeft.Enable();
        flipRightFlipper.Enable();
        //flipLeft.performed += ctx => { onFlipLeft(ctx); };
        flipRightFlipper.performed += ctx => { onFlipRight(ctx); };
        //flipLeft.canceled += ctx => { onFlipLeftReleased(ctx); };
        flipRightFlipper.canceled += ctx => { onFlipRightReleased(ctx); };
    }

    public void onFlipLeft(InputAction.CallbackContext context)
    {
        Debug.Log("Pressed");
        gameObject.GetComponent<HingeJoint2D>().useMotor = true;

    }
    public void onFlipRight(InputAction.CallbackContext context)
    {
        Debug.Log("Right Flipper Pressed");
        gameObject.GetComponent<HingeJoint2D>().useMotor = true;

    }
    public void onFlipLeftReleased(InputAction.CallbackContext context)
    {
        Debug.Log("Relased");
        gameObject.GetComponent<HingeJoint2D>().useMotor = false;
    }
    public void onFlipRightReleased(InputAction.CallbackContext context)
    {
        Debug.Log("Right Flipper Relased");
        gameObject.GetComponent<HingeJoint2D>().useMotor = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
