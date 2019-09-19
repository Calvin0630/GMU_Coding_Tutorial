using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float enemyStartingHealth = 100;
    float enemyHealth;
    public Color healthyColor = Color.green;
    public Color unhealthyColor = Color.red;
    Material enemyMaterial;
    GameObject playerTarget;
    public float moveSpeed = 5;
    Rigidbody rBody;
    // Start is called before the first frame update
    void Start() {
        enemyMaterial = GetComponent<MeshRenderer>().material;
        enemyMaterial.color = healthyColor;
        enemyHealth = enemyStartingHealth;
        playerTarget = GameObject.Find("Player");
        if (playerTarget == null) Debug.LogError("Enemy.cs is unable to find the player object to follow it.");
        rBody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        //if the enemy is greater than a certain distance from the player
        if ((playerTarget.transform.position-gameObject.transform.position).magnitude>2) {
            //move enemy towards the player
            rBody.velocity = moveSpeed * (playerTarget.transform.position - gameObject.transform.position).normalized;

        }
        
    }
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Projectile") {
            //Debug.Log("Hit " + other.name);
            enemyHealth -= 10;
            if (enemyHealth < 0) {
                Destroy(gameObject);
            }
            enemyMaterial.color = Color.Lerp(unhealthyColor, healthyColor, enemyHealth / enemyStartingHealth);
        }
    }
}
