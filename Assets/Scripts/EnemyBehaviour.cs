using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public int moveSpeed; 
    public int laserSpeed;
    // public Sprite forwardFace;
    // public Sprite leftMove;
    // public Sprite rightMove;
    public GameObject enemy;
    public GameObject laserBeam;
    public GameObject onDeath;
    bool changeDir = true;
    float Xpos;
    float Xleft = -13.0f;
    float Xright = 13.0f;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void FixedUpdate() {
        if (transform.position.y > 3) {
            //Send the enemy
            if (transform.position.x >= 0) {
                Xpos = Xright;
            }
            else {
                Xpos = Xleft;
            }
            Vector2 nPosition = new Vector2(Xpos,3);
            transform.position = Vector2.MoveTowards(transform.position, nPosition, 3 * Time.deltaTime);
        }
        InvokeRepeating("dynamicMoves", 0, 0);
    }

    void OnTriggerEnter2D(Collider2D col) {
    if (col.gameObject.tag == "Laser") {
        // Destroy itself (the enemy) and the bullet
        Destroy(enemy);
        Destroy(col.gameObject);
        onDeath = (GameObject)Instantiate(onDeath, transform.position, Quaternion.identity);
        Destroy(onDeath, 1.7f);
    }
    }

    void dynamicMoves() {
        if (changeDir) {
            Vector2 xPosition = new Vector2(Xpos,3);
            transform.position = Vector2.MoveTowards(transform.position, xPosition, 10 * Time.deltaTime);

            if (transform.position.x == Xpos) {
                Xpos = Random.Range(-13.0f, 13.0f);
                //create bullet
                GameObject laser = Instantiate(laserBeam, transform.position, Quaternion.identity);
                //Send the bullet
                laser.GetComponent<Rigidbody2D>().velocity = Vector2.up * laserSpeed;
                //Destroy bullet
                Destroy(laser, 2);
            }
        }
    }

    void OnBecameInvisible() {
        Destroy(enemy);

    }
}