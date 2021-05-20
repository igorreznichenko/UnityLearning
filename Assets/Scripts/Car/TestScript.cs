using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    bool isPaused = false;
    bool isBusy = false;

    private void Awake()
    {
        Debug.Log("Awake");
    }

    private void OnEnable()
    {
        Debug.Log("OnEnable");
    }

    private void OnGUI()
    {
        if (isPaused)
            GUI.Label(new Rect(100, 100, 50, 30), "Game paused");
    }
    private void OnApplicationPause(bool pause)
    {
        isPaused = pause;
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("OnStart");
    }
    private void OnApplicationFocus(bool focus)
    {
        isPaused = !focus;
    }
    IEnumerator MakeCoroutine(float seconds)
    {
        Debug.Log("Hello");
        yield return new WaitForSeconds(seconds);
        Debug.Log("World!");
    }
 
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Escape))
            Time.timeScale = 0;
        else
            if (Input.GetKey(KeyCode.K) && !isBusy)
        {
            isBusy = true;
            StartCoroutine("MakeCoroutine", 3);
        }
    }
    
}
