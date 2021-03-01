using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CYR : MonoBehaviour
{
  float force;
    
    void OnCollisionEnter(Collision player)
    {
        if (player.collider.tag == "Player")
        {
           // Vector3.Reflect(player.collider.transform.eulerAngles,player.contacts[0].normal);
           force=player.collider.GetComponent<playerscript>().obstacle_force;
            player.collider.GetComponent<Rigidbody>().AddForce(-1*player.contacts[0].normal * force);
            
        }

    }
}
