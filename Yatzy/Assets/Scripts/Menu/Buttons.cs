﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void StartClick()
    {
        SceneManager.LoadScene("Game");
    }

    public void SettingsClick()
    {
        // 개발중
    }

    public void QuitClick()
    {
        Application.Quit();
    }

}
