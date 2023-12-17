using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class flipperController : MonoBehaviour
{
    private bool flipped = false;
    private bool flippedMax = false;
    private Vector3 originalPosition;
    //private float maxFlipDegrees = 90f;
    public float maxFlipDegrees;
    public KeyCode flipperKeyCode;
    public float angle;
    // Start is called before the first frame update
    void Start()
    {
        originalPosition = transform.rotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(flipperKeyCode)&(!flippedMax))
        {
            
            Vector3 destination = new Vector3(0, 0, maxFlipDegrees);
            //transform.eulerAngles = destination;
            transform.Rotate(destination,angle);
            flipped = true;
            if (transform.rotation.eulerAngles.z>=(originalPosition.z+maxFlipDegrees))
            {
                flippedMax = true;
            }
        }
       if( (!Input.GetKey(flipperKeyCode) & (flipped==true)))
        {
            Vector3 destination = new Vector3(0, 0, -maxFlipDegrees);
            transform.Rotate(destination,angle);
            if (transform.rotation.eulerAngles.z<=(originalPosition.z))
            {
                flippedMax = false;
                flipped = false;
            }
        }
    }
}
