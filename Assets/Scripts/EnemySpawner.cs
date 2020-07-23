﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
 // Variable to store the enemy prefab and relevant stats
public GameObject enemy;

// Variable to know how fast we should create new enemies
public float spawnTime = 2;

void Start() {
    // Call the 'addEnemy' function in 0 second
    // Then every 'spawnTime' seconds
    // 0, spawnTime = 2
    InvokeRepeating("addEnemy", 0, spawnTime);
}

// New function to spawn an enemy
void addEnemy() {
    // Get the renderer component of the spawn object
    var rd = GetComponent<SpriteRenderer>();

    // Position of the left edge of the spawn object
    // It's: (position of the center) minus (half the width)
    var x1 = transform.position.x - rd.bounds.size.x/2;

    // Same for the right edge
    var x2 = transform.position.x + rd.bounds.size.x/2;

    // Randomly pick a point within the spawn object
    Vector2 spawnPoint = new Vector2(Random.Range(x1, x2), transform.position.y);

    // Create an enemy at the 'spawnPoint' position
    Instantiate(enemy, spawnPoint, Quaternion.identity);
} 
}
