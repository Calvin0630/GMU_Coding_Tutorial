using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 offset = new Vector3(0, 10, -10);
    public GameObject target;
    // Start is called before the first frame update
    void Start() {
        if (target == null) Debug.Log("the camera target is null. you forgot to assign it in the editor.");
    }

    // Update is called once per frame
    void Update() {
        gameObject.transform.position = target.transform.position + offset;
        transform.LookAt(target.transform);
    }
}
