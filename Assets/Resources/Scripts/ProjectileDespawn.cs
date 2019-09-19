using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDespawn : MonoBehaviour
{
    public float lifeTime = 10;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Destroy(gameObject, lifeTime);  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
