using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class joystickplayercontrol : MonoBehaviour
{
    // Start is called before the first frame update
    Joystick joystick;
    Quaternion left;
    Quaternion right;
    Quaternion back;
    Quaternion forward;
    CapsuleCollider col;
    Rigidbody rb;
    float horrizontal;
    float Vertical;
    public float speed;
    public float jumppower;
    public Vector3 lastTriggerPos;
    Vector3 initial_pos;
    Vector3 pos;
    Animator anim;
    float timer_for_yawn=5;
    float standing;
    float slidetimer=-1;
    float jumptimer=-1;
    public bool transparent=false;
    public bool fall=false;
    bool jumptrigger=false;
    bool yawn_timer_set;
    bool yawn_trigger;
    void Start()
    {
        initial_pos=transform.position;
        joystick=FindObjectOfType<Joystick>();
        col=GetComponent<CapsuleCollider>();
        rb=GetComponent<Rigidbody>();
        left=Quaternion.LookRotation(-transform.right,transform.up);
        right=Quaternion.LookRotation(transform.right,transform.up);
        back=Quaternion.LookRotation(-transform.forward,transform.up);
        forward=Quaternion.LookRotation(transform.forward,transform.up);
        anim=GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if(slidetimer>0)
        {
            slidetimer-=Time.deltaTime;
            if(slidetimer<0)
            {
                anim.SetBool("IsSliding", false);
                col.enabled=true;
            }
        }
        if(jumptimer>0)
        {
            jumptimer-=Time.deltaTime;
            if(jumptimer<0)
            {
                anim.SetBool("IsJumping", false);
                anim.SetBool("IsIdle", true);
            }
        }
        if(transform.position.y<-150)
        {
            respawn();
        }
        if (transform.position.y < -5 && transform.position.y > -150) 
        {
            arrestallanimation();
            anim.SetBool("IsFalling", true);
        }
        if(Input.GetKey("space"))
        {
            jump();
        }
        if(Input.GetKey("h"))
        {
            slide();
        }
       joystick_running();
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("obstacle") && transparent==false)
        {
            fallinganimation(collision.contacts[0].normal);
            Debug.Log("collided again");
            //obstaclehit();
        }
        if(jumptrigger)
        {
            jumptrigger=false;
            jumptimer=-1;
            anim.SetBool("IsJumping", false);
            anim.SetBool("IsIdle", true);

        }
    }

    void joystick_running()
    {
        Vertical=joystick.Vertical;
       horrizontal=joystick.Horizontal;
       if(Vertical>0.5 || Input.GetKey("w"))
       {
           transform.rotation=Quaternion.Slerp(transform.rotation,forward,5*Time.deltaTime);
       }
       else if(Vertical<-0.5 || Input.GetKey("s"))
       {
           transform.rotation=Quaternion.Slerp(transform.rotation,back,5*Time.deltaTime);
       }
       if(horrizontal>0.5 || Input.GetKey("d"))
       {
           transform.rotation=Quaternion.Slerp(transform.rotation,right,5*Time.deltaTime);
       }
       else if(horrizontal<-0.5 || Input.GetKey("a"))
       {
           transform.rotation=Quaternion.Slerp(transform.rotation,left,5*Time.deltaTime);
       }
       if(Mathf.Abs(horrizontal)>0.5|| Mathf.Abs(Vertical)>0.5 || Input.GetKey("w")||Input.GetKey("s") || Input.GetKey("d") || Input.GetKey("a"))
       {
           transform.position+=transform.forward*speed*Time.deltaTime;
           arrestallanimation();
           anim.SetBool("IsRunning", true);
           yawn_timer_set=false;
           
       }
       else
       {
           
           if(!yawn_timer_set)
           {
               arrestallanimation();
               anim.SetBool("IsIdle",true);
               timer_for_yawn=10;
               yawn_timer_set=true;
               yawn_trigger=false;
           }
           timer_for_yawn-=Time.deltaTime;
           if(timer_for_yawn<0 && yawn_trigger==false)
           {
               anim.SetBool("IsIdle",false);
               anim.SetBool("Isyawn",true);
               yawn_trigger=true;
               timer_for_yawn=3;
               
           }
           if(timer_for_yawn<0 && yawn_trigger==true)
           {
               yawn_trigger=false;
               timer_for_yawn=10;
               anim.SetBool("Isyawn",false);
               anim.SetBool("IsIdle",true);
           }
       }
    }

void fallinganimation(Vector3 direction)
    {
        arrestallanimation();
        anim.SetBool("IsJumping", false);
        anim.SetBool("IsSliding", false);
         if(Mathf.Abs(direction.x)>Mathf.Abs(direction.z))
            {
                if(direction.x>0)
                {
                    
                    anim.SetBool("IsDeathRight", true);
                   // Debug.Log("right");
                }
                else
                {
                    
                    anim.SetBool("IsDeathLeft", true);
                    //Debug.Log("left");
                }
                
            }
            else
            {
               if(direction.z>0)
                {
                    
                    anim.SetBool("IsDeathForward", true);
                    //Debug.Log("forward");
                }
                else
                {
                    
                    anim.SetBool("IsDeathBackward", true);
                    //Debug.Log("back");
                }
            }
        GetComponent<reappear>().enabled=true;
        fall=true;
        GetComponent<flashing>().enabled=true;
    }
    public void jump()
    {
        if(fall==false && !jumptrigger)
        {
            rb.AddForce(0, jumppower, 0);
            arrestallanimation();
            anim.SetBool("IsJumping", true);
            jumptimer=1.5f;
            jumptrigger=true;
        }
    }

    public void slide()
    {
        if(fall==false)
        {
            anim.SetBool("IsSliding", true);
            col.enabled=false;
            slidetimer=1.5f;
        }
    }

    void arrestallanimation()
    {
        anim.SetBool("IsRunning", false);
        anim.SetBool("IsIdle",false);
        anim.SetBool("Isyawn",false);

    }

    void arrest_all_falling()
    {
        anim.SetBool("IsDeathRight", false);
        anim.SetBool("IsDeathLeft", false);
        anim.SetBool("IsDeathForward", false);
        anim.SetBool("IsDeathBackward",false);
        anim.SetBool("IsFalling", false);
        anim.SetBool("IsStanding",false);
    }

    public void respawn()
    {
        pos=lastTriggerPos;
        pos.y=initial_pos.y;
        pos.x=0;
        transform.position=pos;
        transform.eulerAngles=Vector3.zero;
        rb.velocity=Vector3.zero;
        rb.angularVelocity=Vector3.zero;
        arrestallanimation();
        arrest_all_falling();
        anim.SetBool("IsIdle", true);
    }
}
