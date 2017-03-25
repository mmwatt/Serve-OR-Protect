using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance = null;
	// Use this for initialization
	void Awake () {
        //Makes sure that GameManager is a singleton
		if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(this);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
