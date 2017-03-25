using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {
	private GameObject mainCamera;

	// Use this for initialization
	void Start () {
		mainCamera = (GameObject) GameObject.FindWithTag ("Main Camera");
	}
	
	// Update is called once per frame
	void Update () {
		mainCamera.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
	}
}
