using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Image = UnityEngine.UI.Image;

public class PlayerControl : MonoBehaviour
{
    public int moveSpeed; 
    public int laserSpeed;
    public Sprite forwardFace;
    public Sprite leftMove;
    public Sprite rightMove;
    public GameObject laserBeam;
    public GameObject PlayerSprite;
    public GameObject onDeath;
    // Start is called before the first frame update
    void Start()
    {
       
    }
    // Update is called once per frame
    void Update()
    {
         //Store the current horizontal input in the int moveHorizontal.
         float moveHorizontal = Input.GetAxis ("Horizontal");

         //Store the current vertical input in the int moveVertical.
         float moveVertical = Input.GetAxis ("Vertical");

         //Use the two store ints to create a new Vector2 variable movement.
         Vector2 movement = new Vector2 (moveHorizontal, moveVertical);

         transform.Translate(movement * Time.deltaTime * moveSpeed);

        if (Input.GetKeyDown(KeyCode.Space)) {
            //create bullet
            GameObject laser = Instantiate(laserBeam, transform.position, Quaternion.identity);
            //Send the bullet
            laser.GetComponent<Rigidbody2D>().velocity = Vector2.up * laserSpeed;
            //Destroy bullet
            Destroy(laser, 2);
        }

        if ((Input.GetKeyDown(KeyCode.LeftArrow)) || (Input.GetKeyDown(KeyCode.A))){
            //Changes sprite to face to the left
            GetComponent<SpriteRenderer>().sprite = leftMove;
        }

        if ((Input.GetKeyUp(KeyCode.LeftArrow)) || (Input.GetKeyUp(KeyCode.A))) {
            //Changes sprite to face forwards
            GetComponent<SpriteRenderer>().sprite = forwardFace;
        }

        if ((Input.GetKeyDown(KeyCode.RightArrow)) || (Input.GetKeyDown(KeyCode.D))) {
            //Changes sprite to face to the right
            GetComponent<SpriteRenderer>().sprite = rightMove;
        }

        if ((Input.GetKeyUp(KeyCode.RightArrow)) || (Input.GetKeyUp(KeyCode.D))) {
            //Changes sprite to face forwards
            GetComponent<SpriteRenderer>().sprite = forwardFace;
        }
    }

    void OnTriggerEnter2D(Collider2D col) {
    if (col.gameObject.tag == "EnemyLaser") {
        // Destroy itself (the player) and the enemy laser or sprite
        Destroy(PlayerSprite, 0.0f);
        Destroy(col.gameObject, 0.0f);
        onDeath = (GameObject)Instantiate(onDeath, transform.position, Quaternion.identity);
        Destroy(onDeath, 1.7f);
    }
}
}