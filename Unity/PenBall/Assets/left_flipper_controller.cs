using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class left_flipper_controller : MonoBehaviour
{
    public HingeJoint2D joint;
    public JointMotor2D motor;
    // Start is called before the first frame update
    void Start()
    {
        joint= GetComponent<HingeJoint2D>();
        motor = joint.motor;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow)) {
            motor.motorSpeed = -1000;
            joint.motor = motor;
        }
        else
        {
            motor.motorSpeed= 1000;
            joint.motor = motor;
        }
    }
}
