using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerProjectileBehaviour : MonoBehaviour {
    public float damage = 10;
    public float speed = 15;

    private Rigidbody2D rbody2D;
    private Camera mainCamera;
    private SpriteRenderer spriteRenderer;
    public void hit () {
        Destroy(this);
    }

    void Awake () {
        rbody2D = GetComponent<Rigidbody2D>();
        mainCamera = (Camera) GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    void Start () {
        float horizontal = Mathf.Round(Input.GetAxisRaw("AimHorizontal"));
        float vertical = Mathf.Round(Input.GetAxisRaw("AimVertical"));

        Vector2 direction = new Vector2(horizontal, vertical);

        rbody2D.velocity = direction * speed;
    }

    private void Update () {
        Vector3 pos = mainCamera.WorldToViewportPoint(transform.position);
        if (checkPointOnScreen(pos) == false) {
            Destroy(gameObject);
        }
    }

    private bool checkPointOnScreen (Vector3 pointOnScreen) {
        return pointOnScreen.x > 0 && pointOnScreen.y > 0
            && pointOnScreen.x < 1 && pointOnScreen.y < 1;
    }
}
