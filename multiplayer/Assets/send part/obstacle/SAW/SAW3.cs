using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SAW3 : MonoBehaviour
{
    public float speed = 2.5f;
    float startZ;
    public float distance = 7;
    float addZ;
    float force;
    // Start is called before the first frame update
    void Start()
    {
        startZ = transform.position.x;

    }

    void Update()
    {
        transform.Rotate(0, 0, speed);
        addZ = Mathf.PingPong(Time.time * speed, distance);
        transform.position = new Vector3((startZ + addZ), transform.position.y, transform.position.z);

    }
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