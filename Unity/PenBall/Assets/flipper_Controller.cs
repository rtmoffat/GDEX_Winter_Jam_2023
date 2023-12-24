using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class flipper_Controller : MonoBehaviour
{
    public JointMotor2D motor;
    public HingeJoint2D joint;
    // Start is called before the first frame update
    void Start()
    {
        joint=gameObject.GetComponent<HingeJoint2D>();
        motor = joint.motor;
        motor.motorSpeed=-1000f;
        joint.motor = motor;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow)) {
            motor.motorSpeed =1000f;
            joint.motor = motor;
        }
        else
        {
            if (motor.motorSpeed>0)
            {
                motor.motorSpeed = -1000;
                joint.motor = motor;
            }
            
        }
    }
}
