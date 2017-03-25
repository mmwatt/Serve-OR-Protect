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


    private float fireRate = 3f; //lower is harder

    public void Start () {
        rbody2D = GetComponent<Rigidbody2D>();
        currHealth = maxHealth;
        randomWaitShoot();
    }

    void FixedUpdate () {

    }

    void Update () {
        Transform target = GameObject.FindWithTag("Player").transform;
        Vector3 direction = (transform.position - target.position);
        float step = movementSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);


    }

    private void randomWaitShoot () {
        IEnumerator coroutine = WaitThenShoot(fireRate);
        StartCoroutine(coroutine);
    }

    private IEnumerator WaitThenShoot (float waitTime) {
        while (true) {
            yield return new WaitForSeconds(Random.Range(0f, waitTime));
            spawnBullet();
        }
    }

	private void spawnBullet () {
		Instantiate(bullet, transform.position, Quaternion.identity);
	}

    private void killed () {
        Debug.Log("Enemy Killed.");
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D (Collider2D col) {
        if (col.gameObject.tag == "playerProjectiles") {
            playerProjectileBehaviour playerProjectile = col.gameObject.GetComponent<playerProjectileBehaviour>();
            currHealth -= playerProjectile.damage;
            playerProjectile.hit();
        }
        if(currHealth <= 0) {
            killed();
        }
    }
}
