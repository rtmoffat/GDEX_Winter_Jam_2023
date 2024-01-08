using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class square_target_controller : MonoBehaviour
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
        Delivery_System_Controller.score += 100;
        Delivery_System_Controller.updateScore(scoreText,scoreImage);
    }
}
