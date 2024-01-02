using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class lightBlink : MonoBehaviour
{
    private SpriteRenderer sprRenderer;
    public Color color1=Color.white;
    public Color color2=Color.magenta;
    // Start is called before the first frame update
    void Start()
    {
        sprRenderer = gameObject.GetComponent<SpriteRenderer>();

        //InvokeRepeating("changeColor", 0.1f, 1.0f);
        //color1= Color.white;
        //color2= Color.magenta;
        StartCoroutine(ccc());
    }

    IEnumerator ccc()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            changeColor();   
        }
    }
    void changeColor()
    {
        if (sprRenderer.color != color1) { 
            sprRenderer.color = color1;
            Debug.Log("setting color 1");
        }
        else
        {
            Debug.Log("Setting color 2");
            sprRenderer.color = color2;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
