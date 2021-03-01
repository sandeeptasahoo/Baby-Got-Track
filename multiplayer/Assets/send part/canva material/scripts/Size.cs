using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Size : MonoBehaviour
{
    public Scrollbar scroll;
    public Button but1;
    public Button but2;
    public Button but3;
    // Start is called before the first frame update
    void Start()
    {
       
        
    }

    // Update is called once per frame
    void Update()
    {
        if (scroll.value <0.37)
        {
            but1.interactable = true;
            but2.interactable = false;
            but3.interactable = false;
            but1.image.rectTransform.sizeDelta = new Vector2(500f, 750f);
            but2.image.rectTransform.sizeDelta = new Vector2(350f, 420f);
            but3.image.rectTransform.sizeDelta = new Vector2(350f, 420f);
        }
        else if(scroll.value>0.41 && scroll.value < 0.58)
        {
            but1.interactable = false;
            but2.interactable = true;
            but3.interactable = false;
            but1.image.rectTransform.sizeDelta = new Vector2(350f, 420f);
            but2.image.rectTransform.sizeDelta = new Vector2(500f, 750f);
            but3.image.rectTransform.sizeDelta = new Vector2(350f, 420f);

        }
        else if (scroll.value > 1)
        {
            but1.interactable = false;
            but2.interactable = false;
            but3.interactable = true;
            but1.image.rectTransform.sizeDelta = new Vector2(350f, 420f);
            but2.image.rectTransform.sizeDelta = new Vector2(350f, 420f);
            but3.image.rectTransform.sizeDelta = new Vector2(500f, 750f);
        }
        
    }
}
