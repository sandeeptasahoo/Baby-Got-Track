using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerscript : MonoBehaviour
{
    public float speed;
    public float rotationspeed;
    public float jumppower;
    public Vector3 lastTriggerPos;
    public float dropdistance;
    public float obstacle_force;
    CapsuleCollider col;
    float slideheight=1;
    float normalheight;
    Rigidbody rb;
    Quaternion left;
    Quaternion right;
    Quaternion back;
    Quaternion forward;
    float distance=2;
    public Animator anim;
    private bool isgrounded = true;
    public bool transparent=false;
    Vector3 pos;

    Vector3 initial_pos;
    /*private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground")) 
        {
            isgrounded = true;
            arrestrotation();
            anim.SetBool("IsJumping", false);
            anim.SetBool("IsIdle", true);
        }
        
        if(collision.collider.CompareTag("obstacle")&& transparent==false)
        {
            fallinganimation(collision.contacts[0].normal);
            //obstaclehit();
        }
    }*/
    void OnEnable()
    {
        if(transform.position.y>0)
        {
            arrest_all_movement();
            anim.SetBool("IsIdle", true);
        }
    }
    void Start()
    {
        initial_pos=transform.position;
        left=Quaternion.LookRotation(-transform.right,transform.up);
        right=Quaternion.LookRotation(transform.right,transform.up);
        back=Quaternion.LookRotation(-transform.forward,transform.up);
        forward=Quaternion.LookRotation(transform.forward,transform.up);
        anim = GetComponent<Animator>();
        rb=GetComponent<Rigidbody>();
        col=GetComponent<CapsuleCollider>();
        normalheight=col.height;
        lastTriggerPos=transform.position;

    }


    void Update()
    {
        playercontroller();
        if(transform.position.y<dropdistance*-1)
        {
            respawn();
        }
        if (transform.position.y < -1 && transform.position.y > dropdistance * -1) 
        {
            arrest_all_movement();
            anim.SetBool("IsFalling", true);
        }
        
        
        
    }

    void respawn()
    {
        pos=lastTriggerPos;
        pos.y=initial_pos.y;
        pos.x=0;
        transform.position=pos;
        transform.eulerAngles=Vector3.zero;
        rb.velocity=Vector3.zero;
        rb.angularVelocity=Vector3.zero;
        arrest_all_movement();
        anim.SetBool("IsIdle", true);
    }

    void arrestrotation()
    {
        transform.eulerAngles=new Vector3(0,transform.eulerAngles.y,0);
    }

    void arrest_all_movement()
    {
        anim.SetBool("IsIdle", false);
        anim.SetBool("IsRunning", false);
        anim.SetBool("IsSliding", false);
        anim.SetBool("IsJumping", false);
        anim.SetBool("IsFalling", false);
        anim.SetBool("IsDeathForward", false);
        anim.SetBool("IsDeathBackward", false);
        anim.SetBool("IsDeathLeft", false);
        anim.SetBool("IsDeathRight", false);
    }

    void obstaclehit()
    {
        gameObject.GetComponent<reappear>().enabled=true;
    }
    void playercontroller()

    {
        Debug.DrawLine(transform.position,transform.position+(transform.forward*distance),Color.red);
        if(Input.GetKey("w"))
        {
            transform.rotation=Quaternion.Slerp(transform.rotation,forward,rotationspeed*Time.deltaTime);
            transform.position+=transform.forward*speed*Time.deltaTime;
            arrestrotation();
            anim.SetBool("IsRunning", true);
            anim.SetBool("IsIdle", false);

        }
        if(Input.GetKeyUp("w"))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, forward, rotationspeed * Time.deltaTime);
            transform.position += transform.forward * speed * Time.deltaTime;
            anim.SetBool("IsRunning", false);
            anim.SetBool("IsIdle", true);

        }
        if(Input.GetKey("a"))
        {
            //transform.LookAt(left);
            transform.rotation=Quaternion.Slerp(transform.rotation,left,rotationspeed*Time.deltaTime);
            transform.position+=transform.forward*speed*Time.deltaTime;
            arrestrotation();
            anim.SetBool("IsRunning", true);
            anim.SetBool("IsIdle", false);

        }
        if (Input.GetKeyUp("a"))
        {
            //transform.LookAt(left);
            transform.rotation = Quaternion.Slerp(transform.rotation, left, rotationspeed * Time.deltaTime);
            transform.position += transform.forward * speed * Time.deltaTime;
            anim.SetBool("IsRunning", false);
            anim.SetBool("IsIdle", true);

        }
        if (Input.GetKey("d"))
        {
            transform.rotation=Quaternion.Slerp(transform.rotation,right,rotationspeed*Time.deltaTime);
            transform.position+=transform.forward*speed*Time.deltaTime;
            arrestrotation();
            anim.SetBool("IsRunning", true);
            anim.SetBool("IsIdle", false);

        }
        if (Input.GetKeyUp("d"))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, right, rotationspeed * Time.deltaTime);
            transform.position += transform.forward * speed * Time.deltaTime;
            anim.SetBool("IsRunning", false);
            anim.SetBool("IsIdle", true);

        }
        if (Input.GetKey("s"))
        {
            transform.rotation=Quaternion.Slerp(transform.rotation,back,rotationspeed*Time.deltaTime);
            transform.position+=transform.forward*speed*Time.deltaTime;
            arrestrotation();
            anim.SetBool("IsRunning", true);
            anim.SetBool("IsIdle", false);

        }
        if (Input.GetKeyUp("s"))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, back, rotationspeed * Time.deltaTime);
            transform.position += transform.forward * speed * Time.deltaTime;
            anim.SetBool("IsRunning", false);
            anim.SetBool("IsIdle", true);

        }
        if (Input.GetKey("space"))
        {
            if(isgrounded == true)
            {
                gameObject.GetComponent<Rigidbody>().AddForce(0, jumppower, 0);
                arrest_all_movement();
                anim.SetBool("IsJumping", true);
                anim.SetBool("IsIdle",true);

                isgrounded = false;
            }
            
        }
        if(Input.GetKey("g"))
        {
            anim.SetBool("IsSliding", true);
            col.enabled=false;
        
        }
        else
        {
            anim.SetBool("IsSliding", false);
            //col.height=normalheight;
            col.enabled=true;
        }

    }
    
    void fallinganimation(Vector3 direction)
    {
         if(Mathf.Abs(direction.x)>Mathf.Abs(direction.z))
            {
                if(direction.x>0)
                {
                    arrest_all_movement();
                    anim.SetBool("IsDeathRight", true);
                   // Debug.Log("right");
                }
                else
                {
                    arrest_all_movement();
                    anim.SetBool("IsDeathLeft", true);
                    //Debug.Log("left");
                }
                
            }
            else
            {
               if(direction.z>0)
                {
                    arrest_all_movement();
                    anim.SetBool("IsDeathForward", true);
                    //Debug.Log("forward");
                }
                else
                {
                    arrest_all_movement();
                    anim.SetBool("IsDeathBackward", true);
                    //Debug.Log("back");
                }
            }
        gameObject.GetComponent<reappear>().enabled=true;
        GetComponent<flashing>().enabled=true;
    }
   
}
