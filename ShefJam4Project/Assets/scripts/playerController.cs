using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {
	Animator anim;
    public GameObject bullet;
	public int maxHealth;
	public int health;
    
    public float movementSpeed;
    public float xMin, xMax, yMin, yMax;

    private Rigidbody2D rbody2D;
    private GameObject mainCamera;

    private bool isFiring = false;

    public void Awake () {
		anim = GetComponent<Animator> ();
        rbody2D = GetComponent<Rigidbody2D>();
        mainCamera = (GameObject)GameObject.FindWithTag("MainCamera");
    }

    void FixedUpdate () {
        float changeHorizontal = Input.GetAxis("Horizontal");
        float changeVertical = Input.GetAxis("Vertical");

        Vector2 newPos = new Vector2(changeHorizontal, changeVertical);
        rbody2D.velocity = newPos * movementSpeed;

        rbody2D.position = new Vector2(Mathf.Clamp(rbody2D.position.x, xMin, xMax), Mathf.Clamp(rbody2D.position.y, yMin, yMax));
    }

    void Update () {

        float horizontal = Mathf.Round(Input.GetAxisRaw("Horizontal"));
        float vertical = Mathf.Round(Input.GetAxisRaw("Vertical"));
        shootBullet(horizontal,vertical);
        
        animatePlayerDirections(horizontal, vertical);
    }

    private void animatePlayerDirections (float horizontal, float vertical) {
        horizontal = Mathf.Round(horizontal);
        vertical = Mathf.Round(vertical);
        if (horizontal == 0 && vertical == 0) anim.SetTrigger("front");
        else if (horizontal > 0 && vertical == 0) anim.SetTrigger("right");
        else if (horizontal < 0 && vertical == 0) anim.SetTrigger("left");
        else if (horizontal == 0 && vertical > 0) anim.SetTrigger("front"); //replace with back animation
        else if (horizontal == 0 && vertical < 0) anim.SetTrigger("front");
    }
    
    private void shootBullet (float horizontal, float vertical) {
        mainCamera.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        if (Input.GetAxisRaw("Fire1") != 0f && (horizontal != 0 || vertical != 0)) {
            if (!isFiring) {
                Instantiate(bullet, transform.position, Quaternion.identity);
                isFiring = true;
            }
        }
        if (Input.GetAxisRaw("Fire1") == 0f) {
            isFiring = false;
        }
    }

    private void OnTriggerEnter2D (Collider2D col) {
        if (col.gameObject.tag == "enemyProjectiles") {
            enemyProjectileBehaviour enemyProjectile = col.gameObject.GetComponent<enemyProjectileBehaviour>();
            health -= enemyProjectile.damage;
            enemyProjectile.hit();
        }
    }
}
