using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pumch : MonoBehaviour
{
    public float ampliude;
    public float speed;
    float force;
    public float counter;
    float angle;
    Vector3 meanpos;
    Vector3 pos;
    // Start is called before the first frame update
    void Start()
    {
        meanpos=transform.position;
        pos=meanpos;
    }

    // Update is called once per frame
    void Update()
    {
        if(counter<0)
        {
            angle+=Time.deltaTime*speed;
            pos=meanpos+transform.up*ampliude*(Mathf.Sin(angle));
            transform.position=pos;
        }
        else
        {
            counter-=Time.deltaTime;
        }
    }

    void OnCollisionEnter(Collision player)
    {
        if(player.collider.tag=="Player")
        {
            force=player.collider.GetComponent<playerscript>().obstacle_force;
            player.collider.GetComponent<Rigidbody>().AddForce(-1*player.contacts[0].normal * force);
        }
        
    }
}
