using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RARS : MonoBehaviour
{
    public float amplitude;
    public float speed; 
    Vector3 pos; 
    float meanposition;  
    public float initial_angle=0;
    void Start()
    {
        meanposition=transform.localPosition.y;
    }
    void Update()
    {
        initial_angle+=Time.deltaTime*speed;
        pos=transform.localPosition;
        pos.y=meanposition+(Mathf.Sin(initial_angle)*amplitude);
        transform.localPosition=pos;
    }
}
