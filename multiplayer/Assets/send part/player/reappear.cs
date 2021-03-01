using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reappear : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    Animator anim;
    public float time_falltime;
    public float time_rise;
    public float timecount1;
    bool Up;
    
    void Awake()
    {
        anim = GetComponent<Animator>();
        rb=GetComponent<Rigidbody>();
    }
    void OnEnable()
    {
        GetComponent<joystickplayercontrol>().enabled=false;
        timecount1=time_falltime;
        Up=true;  
    }

    // Update is called once per frame
    void Update()
    {
        timecount1-=Time.deltaTime;
        
        if(timecount1<0)
        {
            if(Up==true)
            {
                Up=false;
                anim.SetBool("IsStanding",true);
                timecount1=time_rise;
            }
            else
            {
                anim.SetBool("IsStanding",false);
                arrest_all_movement();
                anim.SetBool("IsIdle",true);
                replay();
                this.enabled=false;


            }
        }

        if (transform.position.y < -5 ) 
        {
            replay();
            GetComponent<flashing>().enabled=false;
            this.enabled=false;
        }

       
        
    }

    void replay()
    {
         //GetComponent<playerscript>().enabled=true;
         GetComponent<joystickplayercontrol>().enabled=true;
         GetComponent<joystickplayercontrol>().fall=false;
        //GetComponent<flashing>().enabled=true;
           
    }
    void arrest_all_movement()
    {
        anim.SetBool("IsDeathForward", false);
        anim.SetBool("IsDeathBackward", false);
        anim.SetBool("IsDeathLeft", false);
        anim.SetBool("IsDeathRight", false);
    }

       
}
