using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Vector2 moveAmount;
    
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //gameObject.transform.Translate(moveAmount);
        
        //Vector3 movement = new Vector3(moveAmount.x, 0, moveAmount.y);
        //transform.Translate(movement * moveSpeed * Time.deltaTime);
        transform.Translate(moveAmount);
    }
    
    public void OnMove(InputAction.CallbackContext context)
    {
        moveAmount = context.ReadValue<Vector2>();           
    }
    
}
