using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonop : MonoBehaviour
{
    public AudioSource audi1;
    public GameObject pnl1;
    public GameObject pnl2;
    public GameObject pnl3;
    public GameObject pnl4;
    public void instruction()
    {
        audi1.Play();
        pnl1.gameObject.SetActive(true);
    }
    public void backbtn()
    {
        audi1.Play();
        pnl1.gameObject.SetActive(false);
    }
    public void credits()
    {
        audi1.Play();
        pnl2.gameObject.SetActive(true);
    }
    public void backbtn2()
    {
        audi1.Play();
        pnl2.gameObject.SetActive(false);
    }
    public void multii()
    {
        audi1.Play();
        pnl3.gameObject.SetActive(true);

    }
    public void bk()
    {
        audi1.Play();
        pnl3.gameObject.SetActive(false);
    }
    public void priv()
    {
        audi1.Play();
        pnl3.gameObject.SetActive(false);
        pnl4.gameObject.SetActive(true);
    }
    public void bk1()
    {
        audi1.Play();
        pnl4.gameObject.SetActive(false);
    }

    public void exit()
    {
        audi1.Play();
        Application.Quit();
    }
}
