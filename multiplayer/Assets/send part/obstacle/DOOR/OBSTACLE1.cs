using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OBSTACLE1 : MonoBehaviour
{
    public float force;

    public float speed = 300f;
    void Update()
    {
        transform.Rotate(Vector3.up, speed * Time.deltaTime);
    }
    /*void OnCollisionEnter(Collision player)
    {
        if (player.collider.tag == "Player")
        {
            player.collider.GetComponent<Rigidbody>().AddForce(transform.up * force);
        }

    }*/
}
