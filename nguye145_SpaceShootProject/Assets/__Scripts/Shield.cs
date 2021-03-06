﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [Header("Set in Inspector")]
    public float rotationsPerSecond = 0.1f;

    [Header("Set Dynamically")]
    public int levelShown = 0;

    //This non-public variable will not appear in the Inspector
    Material mat;

    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }
    void Update()
    {
        //Read the current shield level from the Hero Singleton
        int currLevel = Mathf.FloorToInt( Player.S.shieldLevel1);
        
        //if this is different from leveshown...
        if (levelShown != currLevel)
        {
            levelShown = currLevel;
            
            //Adjust the texture offet to show different shield level
            mat.mainTextureOffset = new Vector2(0.2f*levelShown,0);
        }
        //Rotate the shield a bit every frame in a time-based way
        float rZ = -(rotationsPerSecond*Time.time*360) % 360f;
        transform.rotation = Quaternion.Euler(0,0,rZ);
    }

}
