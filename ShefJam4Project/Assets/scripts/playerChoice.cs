using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerChoice : MonoBehaviour {
    public bool[] choices = new bool[3]; //True is good.

    //Prevents object from being destroyed when a new scene is loaded.
	private void Awake () {
        DontDestroyOnLoad(gameObject);
    }
}
