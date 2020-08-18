﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceSide : MonoBehaviour
{

    bool onGround;
    public int sideValue;

    private void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Ground")
        {
            onGround = true;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.tag == "Ground")
        {
            onGround = false;
        }
    }
    
    public bool GetOnGround()
    {
        return onGround;
    }
}
