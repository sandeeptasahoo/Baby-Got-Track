using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movependlm : MonoBehaviour
{
    public Vector3 from = new Vector3(0f, 0f, 135f);
    public Vector3 to = new Vector3(0f, 0f, 225f);
    public float speed;
    float force;
   public float direction;
   public float time;

    void Update()
    {
        
        float t = Mathf.PingPong((Time.time+time) * speed * 2.0f, 1.0f);
        transform.eulerAngles = Vector3.Lerp(from, to, t);
        if(transform.eulerAngles.x>45 && transform.eulerAngles.x<50)
        {
            direction=1;
        }
        if(transform.eulerAngles.x>310 && transform.eulerAngles.x<320)
        {
            direction=-1;
           
        }
       
    }

    void OnCollisionEnter(Collision hit)
    {
        if(hit.collider.tag=="Player")
        {
            force=hit.collider.GetComponent<playerscript>().obstacle_force;
            hit.collider.GetComponent<Rigidbody>().AddForce(-1*hit.contacts[0].normal * force);
            
        }
    }
}
