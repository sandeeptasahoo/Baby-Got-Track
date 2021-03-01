using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class timess : MonoBehaviour
{
    public GameObject pnlllll;
    private float timerr;
    // Start is called before the first frame update
    void Start()
    {

        timerr = Time.time;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - timerr > 8)
        {
            pnlllll.gameObject.SetActive(true);
        }
        
    }
}
