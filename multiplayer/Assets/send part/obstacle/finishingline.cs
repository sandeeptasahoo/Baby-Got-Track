using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finishingline : MonoBehaviour
{
    gamemanager gamemanager;
    
    void Start()
    {
        gamemanager=GameObject.FindGameObjectWithTag("gamemanager").GetComponent<gamemanager>();
    }
    void OnTriggerEnter(Collider players)
    {
        if(SceneManager.GetActiveScene().name=="solo")
        {
            SceneManager.LoadScene("solowining");
        }
        gamemanager.timescore=Mathf.Round(Time.time);
        
    }
    // Start is called before the first frame update

}
