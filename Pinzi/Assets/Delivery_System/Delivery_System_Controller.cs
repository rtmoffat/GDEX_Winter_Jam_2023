using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Delivery_System_Controller : MonoBehaviour
{
    public static int deliveryCount = 0;
    public static int retrievedCount = 0;
    public static int score=0;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    // Start is called before the first frame update
    void Start()
    {   
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
    public static void updateScore(GameObject guiText,GameObject scoreImage)
    {
        string message = "";
        message += "Retrieved:" + Delivery_System_Controller.retrievedCount.ToString();
        message += "\nDelivered:" + Delivery_System_Controller.deliveryCount.ToString();
        message += "\nScore:" + Delivery_System_Controller.score.ToString();
        guiText.GetComponent<TextMeshProUGUI>().text = message;
        //TextMeshProUGUI guiText=GameObject.FindObjectOfType(typeof(TextMeshProUGUI)) as TextMeshProUGUI;
        //Image scoreImage = GameObject.Find("Score_Image").GetComponent<Image>();
        
    }
}
