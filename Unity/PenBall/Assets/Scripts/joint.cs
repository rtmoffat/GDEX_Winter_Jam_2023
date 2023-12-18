using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class joint : MonoBehaviour
{
    private HingeJoint2D hingeJoint;
    public float flipperForce = 5000f;
    public float maxRotationAngle = 45f;
    public KeyCode key;
    public int direction;

    // Start is called before the first frame update
    void Start()
    {
        hingeJoint= GetComponent<HingeJoint2D>();
        hingeJoint.useLimits = true;
        hingeJoint.useMotor = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(key))
        {
            flip(direction);
        }
        else
        {
            resetFlipper();
        }
    }
    void flip(int direction)
    {
        SetFlipperLimits(maxRotationAngle * direction);

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddTorque(flipperForce * direction);
    }
    void resetFlipper()
    {
        SetFlipperLimits(0f);
    }
    void SetFlipperLimits(float angle)
    {
        JointAngleLimits2D limits = hingeJoint.limits;
        limits.min = -angle;
        limits.max = angle;
        hingeJoint.limits = limits;
    }
    void ApplyFlipperForce(int direction)
    {
        SetFlipperLimits(maxRotationAngle * direction);

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddTorque(flipperForce * direction);
    }
}
