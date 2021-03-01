using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INSTANTCIATE_OBSTACLE : MonoBehaviour
{
    public GameObject[] obstacle;
    public float[] gap;
    public GameObject finishing_mat;
    public float starting_buffer;
    public float total_pathlenght;
    float appearance_range;
    float appearanceposition;
    int index;
    int numberofobstacle;
    
    void Start()
    {
        numberofobstacle=obstacle.Length;
        appearanceposition=transform.position.z + starting_buffer;
        appearance_range=transform.position.z+total_pathlenght;
    }

    
    void Update()
    {
        if(appearanceposition-transform.position.z<appearance_range)
        {
            appear();
        }
        else
        {   
            Vector3 pos=finishing_mat.transform.position;
            pos.z=appearanceposition;
            Instantiate(finishing_mat,pos,finishing_mat.transform.rotation);
            this.enabled=false;
        }
       
    }

    void appear()
    {
        index=(int)Random.Range(0,numberofobstacle);
        Vector3 pos=obstacle[index].transform.position;
        pos.z=appearanceposition;
        Instantiate(obstacle[index],pos,obstacle[index].transform.rotation);
        appearanceposition=pos.z+gap[index];
        
    }
}
