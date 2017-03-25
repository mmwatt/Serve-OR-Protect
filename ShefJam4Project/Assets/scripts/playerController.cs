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
		health = maxHealth;
    }

    void FixedUpdate () {
        float changeHorizontal = Input.GetAxis("Horizontal");
        float changeVertical = Input.GetAxis("Vertical");

        Vector2 newPos = new Vector2(changeHorizontal, changeVertical);
        rbody2D.velocity = newPos * movementSpeed;
		anim.SetFloat ("vx", rbody2D.velocity.x);
		anim.SetFloat ("vy", rbody2D.velocity.y);
        rbody2D.position = new Vector2(Mathf.Clamp(rbody2D.position.x, xMin, xMax), Mathf.Clamp(rbody2D.position.y, yMin, yMax));
    }

    void Update () {
        mainCamera.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        if (Input.GetAxisRaw("Fire1") != 0f) {
            if (!isFiring) {
                shootBullet();
                isFiring = true;
            }
        }

        if (Input.GetAxisRaw("Fire1") == 0f) {
            isFiring = false;
        }
    }

    public void shootBullet () {
        Instantiate(bullet,transform.position,Quaternion.identity);
    }
}
