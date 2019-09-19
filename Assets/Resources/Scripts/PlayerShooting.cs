using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//this script is responsible for the player shooting
public class PlayerShooting : MonoBehaviour
{
    GameObject projectilePrefab;
    public float projectileSpeed = 100;
    // Start is called before the first frame update
    void Start() {
        projectilePrefab = (GameObject)Resources.Load("Prefabs/Projectile");
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            GameObject projectile = Instantiate(projectilePrefab, gameObject.transform.position, Quaternion.identity);

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f)) {
                //Debug.Log("You selected the " + hit.transform.name); // ensure you picked right object
                Vector3 projectileDirection = (hit.point - gameObject.transform.position).normalized;
                projectile.GetComponent<Rigidbody>().velocity = gameObject.GetComponent<Rigidbody>().velocity + (projectileSpeed * projectileDirection);
                
            }
        }
    }
}
