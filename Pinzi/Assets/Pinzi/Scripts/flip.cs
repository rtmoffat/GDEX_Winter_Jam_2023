using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class flip : MonoBehaviour
{
    public InputAction flipAction;
    private HingeJoint2D hj2d;
    private JointMotor2D jm2d;
    void Awake()
    {
        hj2d = gameObject.GetComponent<HingeJoint2D>();
        flipAction.Enable();
        flipAction.performed += ctx => { onFlipped(ctx); };
        flipAction.canceled += ctx => { onFlipReleased(ctx); };
    }

    public void onFlipped(InputAction.CallbackContext context)
    {
        Debug.Log("Pressed");
        reverseMotor();
        
        
        
    }
    public void onFlipReleased(InputAction.CallbackContext context)
    {
        Debug.Log("Relased");
        reverseMotor();
    }
    void reverseMotor()
    {
        jm2d = hj2d.motor;
        jm2d.motorSpeed*=-1;
        hj2d.motor = jm2d;
    }
}
