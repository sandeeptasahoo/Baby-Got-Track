using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    public float speed;
    public Vector3 direction;
    // Update is called once per frame
    void start()
    {
    }
    void Update()
    {
        transform.Rotate(direction*Time.deltaTime*speed);
    }
}
