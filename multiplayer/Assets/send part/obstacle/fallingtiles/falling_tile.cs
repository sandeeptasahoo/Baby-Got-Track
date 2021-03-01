using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class falling_tile : MonoBehaviour
{
    Rigidbody rb;
    public int decide;
    // Start is called before the first frame update
    void Awake()
    {
        rb=GetComponent<Rigidbody>();
        fall_decision();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y<-350)
        {
            Destroy(this.gameObject);
        }
    }

    public void bestill()
    {
        decide=0;
        rb.constraints=RigidbodyConstraints.FreezeAll;
        rb.isKinematic=true;
    }

    void OnCollisionEnter(Collision hit)
    {
        if( decide==1)
        {
            rb.AddForce(-15000*transform.up);
            rb.isKinematic=false;
            rb.constraints=RigidbodyConstraints.None;
        }
    }
    void fall_decision()
    {
        decide=(int)Random.Range(0,2);
        
    }
}
