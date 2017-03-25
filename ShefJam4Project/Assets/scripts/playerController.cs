using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

    public GameObject bullet;
    
    public float movementSpeed;
    public float xMin, xMax, yMin, yMax;
    private Rigidbody2D rbody2D;

    public void Awake () {
        rbody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate () {
        float changeHorizontal = Input.GetAxis("Horizontal");
        float changeVertical = Input.GetAxis("Vertical");

        Vector2 newPos = new Vector2(changeHorizontal, changeVertical);
        rbody2D.velocity = newPos * movementSpeed;

        rbody2D.position = new Vector2(Mathf.Clamp(rbody2D.position.x, xMin, xMax), Mathf.Clamp(rbody2D.position.y, yMin, yMax));
    }

    public void shootBullet () {
        Instantiate(bullet);
    }
}
