using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreBoard : MonoBehaviour
{
    // Start is called before the first frame update
    public Text text;
    void Start()
    {
        text.text="Score\n"+GameObject.FindGameObjectWithTag("gamemanager").GetComponent<gamemanager>().timescore;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
