using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RARAX : MonoBehaviour
{
    public float speed = 2.5f;
    public float orbitingspeed;
    public GameObject centralaxis;
    // Start is called before the first frame update
    void Start()
    { 
}



    // Update is called once per frame
    void Update()
{
    transform.Rotate(0, speed, 0);
    this.transform.RotateAround(centralaxis.transform.position, transform.up, orbitingspeed * Time.deltaTime);
        
    }
}
