using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class pause : MonoBehaviour
{
    public GameObject pausescr;
    public GameObject overscr;
    public GameObject controlsetup;
    public float time;
    public void pausebtn()
    {
        controlsetup.SetActive(false);
        pausescr.gameObject.SetActive(true);
        time=Time.timeScale;
        Time.timeScale=0;
    }
    public void resume()
    {
        controlsetup.SetActive(true);
        pausescr.gameObject.SetActive(false);
        Time.timeScale=time;
    }
    public void quitbtn()
    {
        pausescr.gameObject.SetActive(false);
        overscr.gameObject.SetActive(true);
    }

    
   
}
