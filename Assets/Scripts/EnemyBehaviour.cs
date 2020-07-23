using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public int moveSpeed; 
    public int laserSpeed;
    public Sprite forwardFace;
    public Sprite leftMove;
    public Sprite rightMove;
    public GameObject enemy;
    public GameObject laserBeam;
    bool changeDir = true;
    float Xpos;
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void FixedUpdate() {
        if (transform.position.y > 3) {
            Vector2 nPosition = new Vector2(transform.position.x,3);
            //Send the enemy
            transform.position = Vector2.MoveTowards(transform.position, nPosition, 3 * Time.deltaTime);
        }
        InvokeRepeating("dynamicMoves", 0, 0);
    }

    void OnTriggerEnter2D(Collider2D col) {
    if (col.gameObject.tag == "Laser") {
        // Destroy itself (the enemy) and the bullet
        Destroy(enemy, 0.0f);
        Destroy(col.gameObject, 0.0f);
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
