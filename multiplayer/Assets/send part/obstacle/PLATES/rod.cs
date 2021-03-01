using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rod : MonoBehaviour
{
    public float speed = 100f;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(transform.right, Time.deltaTime * speed);

    }
    
}
