using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Security.Cryptography.X509Certificates;
using UnityEngine.UIElements;


public class PackageController : MonoBehaviour
{
    public GameObject scoreText;
    public GameObject scoreImage;
    //private string message = "";
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
        Debug.Log("got the package!");
        Delivery_System_Controller.retrievedCount++;
        Destroy(gameObject);
        Delivery_System_Controller.updateScore(scoreText,scoreImage);
    }
}
