using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class decisionrow : MonoBehaviour
{
    public int Previous_still_tile;
    int min;
    int max;
    // Start is called before the first frame update
    void Start()
    {
        int i=0;
        int j=(int)Random.Range(0,6);
        Previous_still_tile=j;
        //Debug.Log(Previous_still_tile +" "+ i);
        transform.GetChild(i).transform.GetChild(j).GetComponent<falling_tile>().decide=0;
        i++;
        while(i<6)
        {
            min=Previous_still_tile-1;
            max=Previous_still_tile+1;
            min=Mathf.Clamp(min,0,6);
            max=Mathf.Clamp(max,0,6);
            j=(int)Random.Range(min,max);
            Previous_still_tile=j;
            transform.GetChild(i).transform.GetChild(j).GetComponent<falling_tile>().decide=0;
            //Debug.Log(Previous_still_tile +" "+ i);
            i++;
            
        }
        this.enabled=false;
    }
}
