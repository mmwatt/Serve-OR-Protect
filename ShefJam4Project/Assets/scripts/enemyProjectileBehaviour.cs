using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyProjectileBehaviour : MonoBehaviour {
    public int damage = 10;
    public float speed = 15;

    private Rigidbody2D rbody2D;
    private Camera mainCamera;
    private SpriteRenderer spriteRenderer;
    private GameObject player;

    public void hit () {
        Destroy(gameObject);
    }

    void Awake () {
        rbody2D = GetComponent<Rigidbody2D>();
        mainCamera = (Camera)GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Start () {

        //Set bullet direction to player position with some fuzzing.
        Vector3 pos = player.transform.position;
        Vector3 direction = pos - transform.position;
        direction = new Vector3(Mathf.Round(direction.x), Mathf.Round(direction.y), direction.z);
        //normalise x and y to 1
        if (direction.x > 1) direction.x = 1;
        if (direction.y > 1) direction.y = 1;
        if (direction.x < -1) direction.x = -1;
        if (direction.y < -1) direction.y = -1;
        direction.z = 0;

        rbody2D.velocity = direction * speed;
    }

    private void Update () {
        //Check whether the bullet has left camera view
        Vector3 pos = mainCamera.WorldToViewportPoint(transform.position);
        if (checkPointOnScreen(pos) == false) {
            hit();
        }
    }

    //checks point is within camera frustum
    private bool checkPointOnScreen (Vector3 pointOnScreen) {
        return pointOnScreen.x > 0 && pointOnScreen.y > 0
            && pointOnScreen.x < 1 && pointOnScreen.y < 1;
    }
}
