﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DoThing : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void changeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void quit()
    {
        Application.Quit();
    }
}
