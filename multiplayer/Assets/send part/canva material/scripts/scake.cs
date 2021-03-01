using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scake : MonoBehaviour
{
    
    Vector3 initial_scale;
    Vector3 scale;
    public GameObject player;
    public float max_y_size;
    Animator anim;
    public string animation_name;
    void Start()
    {
      initial_scale=transform.localScale; 
      scale=initial_scale;
      anim=player.GetComponent<Animator>();
    }

    void Update()
    {
        if(transform.localScale.y < max_y_size)
        {
            increase_scale();
        }
        else
        {
            player.SetActive(true);
            anim.Play(animation_name);
            this.enabled=false;

        }
    }

    void increase_scale()
    {
        scale.y+=Mathf.Lerp(0,max_y_size+1,Time.deltaTime);
        transform.localScale=scale;
    }
}
