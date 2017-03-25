using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance = null;
	Animator anim;
	// Use this for initialization
	void Awake () {
        //Makes sure that GameManager is a singleton
		anim = GetComponent<Animator>();
		if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(this);
        }
	}
	
	// Update is called once per frame
	void Update () {
		int playerHealth = GameObject.FindWithTag("Player").GetComponent<playerController>().health;
		Debug.Log ("Thing" + playerHealth);
		if (playerHealth <= 0) {
			anim.SetTrigger("gameOver");
		}
	}
}
