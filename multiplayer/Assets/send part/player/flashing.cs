using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashing : MonoBehaviour
{
    // Start is called before the first frame update
    public float transparencytime;
    public float fliker_time_period;
    public SkinnedMeshRenderer mesh;
    public CapsuleCollider[] body;
    float time1;
    float time2;
    float time3;
    void Start()
    {
        
    }
    void OnEnable()
    {
        time1=Time.time+fliker_time_period;
        time2=Time.time+(fliker_time_period*2);
        time3=Time.time+transparencytime;
        GetComponent<CapsuleCollider>().enabled=false;
        GetComponent<joystickplayercontrol>().transparent=true;
        for(int i=0;i<6;i++)
        {
            body[i].enabled=false;
        }
    }

    void OnDisable()
    {
        mesh.enabled=true;
        GetComponent<CapsuleCollider>().enabled=true;
        GetComponent<joystickplayercontrol>().transparent=false;
        for(int i=0;i<6;i++)
        {
            body[i].enabled=true;
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        if(Time.time<time3)
        fliker();
        else
        this.enabled=false;
        
    }

    void fliker()
    {
        if(time1<Time.time)
        {
            mesh.enabled=false;
           // gameObject.SetActive(false);
            time1=Time.time+(fliker_time_period*2);
        }
        if(time2<Time.time)
        {
            mesh.enabled=true;
           // gameObject.SetActive(true);
            time2=Time.time+(fliker_time_period*2);
        }

    }
}
