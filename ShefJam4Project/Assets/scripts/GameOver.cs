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
		int maxHealth = GameObject.FindWithTag("Player").GetComponent<playerController>().maxHealth;
		Transform bar = GameObject.FindWithTag("healthBar").transform;
		bar.localScale = new Vector3((maxHealth/playerHealth), 3.3f, 0);
		if (playerHealth <= 0) {
			anim.SetTrigger("gameOver");
		}
	}
}
