using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class launchCotroller : MonoBehaviour
{
    public InputAction InputAction;
    public GameObject launchee;
    public float launchForce = 2000f;
    public GameObject launchPad;
    // Start is called before the first frame update

    private void Awake()
    {
        InputAction.Enable();
        InputAction.performed += ctx => { onLaunch(ctx); };
    }
    void OnSceneLoaded(Scene scene,LoadSceneMode mode)
    {
        //InputAction.Enable();
    }

    void Start()
    {
        
    }
   
    // Update is called once per frame
    void Update()
    {
        
    }
    public void onLaunch(InputAction.CallbackContext context)
    {
        launchee.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, launchForce));
        InputAction.Disable();
        Destroy(launchPad);
    }
}
