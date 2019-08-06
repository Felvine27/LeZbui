using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    //public Transform obj;
    //public float pct;
    public Transform target;
    private Vector3 offset;
    // Start is called before the first frame update


    //public void OnValidate() {
    //   obj.position=  Vector3.Lerp(Vector3.left * -3f, Vector3.left * 3f, pct);
    //}

    // Update is called once per frame
    void LateUpdate()
    {
        Follow();
    }

    void Follow()
    {
        transform.LookAt(target);
        offset = new Vector3(-5, 15, -5);
        transform.position = Vector3.Lerp(transform.position, target.position + offset,Time.deltaTime*2f);
    }
}