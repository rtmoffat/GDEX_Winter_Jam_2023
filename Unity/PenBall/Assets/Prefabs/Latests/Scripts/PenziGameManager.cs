using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;

public class PenziGameManager : MonoBehaviour
{
    public static int giftCount = 0;
    

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public static void incGift()
    {
        giftCount++;
    }
}
