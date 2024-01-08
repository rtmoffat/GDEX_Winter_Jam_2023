using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class DestinationController : MonoBehaviour
{
    public GameObject scoreText;
    public GameObject scoreImage;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Delivery_System_Controller.retrievedCount > 0)
        {
            Delivery_System_Controller.deliveryCount+=Delivery_System_Controller.retrievedCount;
            Delivery_System_Controller.retrievedCount=0;
            Debug.Log(Delivery_System_Controller.deliveryCount);
            Delivery_System_Controller.updateScore(scoreText, scoreImage);
        }
        

    }
}
