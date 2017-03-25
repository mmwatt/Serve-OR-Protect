using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {
	Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		int playerHealth = GameObject.FindWithTag("Player").GetComponent<playerController>().health;
		if (playerHealth <= 0) {
			anim.SetTrigger("gameOver");
		}
	}
}
