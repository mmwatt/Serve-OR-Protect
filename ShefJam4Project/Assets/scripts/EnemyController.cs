using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
	public GameObject bullet;
	private GameObject player;
	public float movementSpeed;
	public float xMin, xMax, yMin, yMax;
	private Rigidbody2D rbody2D;

    public int maxHealth = 40;
    public int currHealth;
	public void Start(){
		rbody2D = GetComponent<Rigidbody2D>();
        currHealth = maxHealth;
	}

	void FixedUpdate ()
	{
		
	}

	void Update () {
		Transform target = GameObject.FindWithTag("Player").transform;
		Vector3 direction = (transform.position - target.position);
		float step = movementSpeed * Time.deltaTime;
		transform.position = Vector3.MoveTowards (transform.position, target.position, step);

	}

	public void Shoot(){
	}

	public void shootBullet () {
		Instantiate(bullet);
	}

    private void OnCollisionEnter2D (Collision2D collision) {
        if (collision.gameObject.tag == "playerProjectiles") {
            playerProjectileBehaviour playerProjectile = collision.gameObject.GetComponent<playerProjectileBehaviour>();
            currHealth -= playerProjectile.damage;
            Debug.Log("Enemy health: " + currHealth);
        }

    }
}
