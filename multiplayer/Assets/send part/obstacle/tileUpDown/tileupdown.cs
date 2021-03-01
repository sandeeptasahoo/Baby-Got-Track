using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileupdown : MonoBehaviour
{
   public float speed;
   public float time_buffer;
   Vector3 pos;
   public float amplitude;
   float time;
    void Start()
    {
        time+=time_buffer;
        speed=Random.Range(1,5);
        time_buffer=Random.Range(0,5);
        amplitude=Random.Range(1,10);
    }

    // Update is called once per frame
    void Update()
    {
        time+=Time.deltaTime*speed;
        pos=transform.position;
        pos.y=Mathf.PingPong(time,amplitude);
        transform.position=pos;
        transform.eulerAngles=Vector3.zero;
    }
}
