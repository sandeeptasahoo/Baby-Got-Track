using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CY3 : MonoBehaviour
{
    public float speed = 2.5f;
    float startZ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, speed);

    }
}
