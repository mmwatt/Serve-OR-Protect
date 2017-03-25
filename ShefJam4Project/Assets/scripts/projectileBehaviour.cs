using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileBehaviour : MonoBehaviour {
    public float damage = 10;
	
	public void hit () {
        Destroy(this);
    }
	
}
