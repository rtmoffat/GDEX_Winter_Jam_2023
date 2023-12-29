using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vector3 = new(target.transform.position.x, target.transform.position.y, -10f);

        transform.position = vector3;
    }
    //add boundaries for camera
    //add resolution code
    // this will be in lateupdate
    //render to texture to fix overview camera size
    //penguin mask <---0---->
    //break through ice
    //paper/present wall
    //location
    //present delivery

}
