using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour {
    public static EnemyManager instance = null;
    public GameObject enemyPrefab;


    public int enemyNo;
    public float xMax;
    public float yMax;

    public int enemiesAlive;
    void Start () {
        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(gameObject);
        }
        enemiesAlive = enemyNo;
        for (int i = 0; i < enemyNo; i++) spawnEnemy();
    }

    private void Update () {
        if (enemiesAlive <= 0) {
            LoadNext();
        }
    }
    void spawnEnemy () {
        float xPos = Random.Range(-xMax,xMax);
        float yPos = Random.Range(-yMax, yMax);
        Vector3 position = new Vector3(xPos, yPos, 0f);
        Instantiate(enemyPrefab, position, Quaternion.identity);
    }

    void LoadNext () {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
