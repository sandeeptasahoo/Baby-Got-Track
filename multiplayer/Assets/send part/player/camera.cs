using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public GameObject player;
    public float bufferdistance;
    public float lookspeed;
    Vector3 pos;
    
    void Update()
    {
        pos=transform.position;
        pos.z=player.transform.position.z-bufferdistance;
        pos.x=player.transform.position.x;
        if(player.transform.position.y<-10)
        {
            allign();
        }
        transform.position=pos;
        transform.LookAt(player.transform);
        //lookat();
        
    }

    void allign()
    {
        pos.z=Mathf.Lerp(transform.position.z,player.transform.position.z,Time.deltaTime);
    }
    void lookat()
    {
        Quaternion target=Quaternion.LookRotation(player.transform.position,transform.up);
        transform.rotation=Quaternion.Slerp(transform.rotation,target,lookspeed);
    }
}
