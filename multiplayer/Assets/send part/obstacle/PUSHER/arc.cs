using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arc : MonoBehaviour
{
    public float buffertime;
    float timeCounter = 0;
    public float direction=1;
    public float maxspeed=3;
    float speed ;
    public float width = 23f;
    float period;
    Vector3 pos;
    float meanpos;

    // Start is called before the first frame update
    void Start()
    {
       meanpos=transform.position.x;
       timeCounter+=buffertime;
       speed=maxspeed;

    }

    // Update is called once per frame
    void Update()
    {
        timeCounter += Time.deltaTime * speed;
        period=Mathf.PingPong(timeCounter,1.2f);
        if(period>1)
        {
            speed=1f;
        }
        if(period<0.1)
        {
            speed=maxspeed;
        }
        pos=transform.position;
        pos.x =meanpos+ direction*period * width;
        transform.position = pos;
    }
    
}
