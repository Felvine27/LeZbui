﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider EverythingColided)
    {

        if (EverythingColided.CompareTag("Player")) 
            SceneManager.LoadScene(0);
        Debug.Log(EverythingColided.name);
    }

}
