using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moonwalk : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform leftpoint;
    public Transform rightpoint;
    public float speed;
   
    Vector3 c;
    void Start()
    {
        c=transform.position;
        transform.LookAt(rightpoint);
    }

    // Update is called once per frame
    void Update()
    {
       c.z+=Time.deltaTime*speed;
       transform.position=c;
       if(transform.position.z>leftpoint.position.z)
       {
           transform.rotation=Quaternion.LookRotation(-transform.forward);
           speed*=-1;
       }
       if(transform.position.z<rightpoint.position.z)
       {
           transform.rotation=Quaternion.LookRotation(-transform.forward);
           speed*=-1;
       }

    }
}
