using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class touch : MonoBehaviour
{
    public Scrollbar scrollbr;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchposi =  Camera.main.ScreenToWorldPoint(touch.position);
            if (touchposi.x > 255 && touchposi.x<650  && touchposi.y>150 && touchposi.y<325)
            {
                scrollbr.value = touchposi.x;

            }
        }
        
    }
}
