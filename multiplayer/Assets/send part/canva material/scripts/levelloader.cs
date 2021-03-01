using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelloader : MonoBehaviour
{
    public GameObject loadingscreen;
    public Slider slidrr;
    public Scrollbar scrollbar;
    public Text text;
    public Button but1;
    public Button but2;
    public Button but3;
    public AudioSource audi2;
    private Vector2 val =new Vector2 (500f,750f);
    

    public void Loadlevel(int sceneindex)
    {
        audi2.Play();
        StartCoroutine(LoadAsyn(sceneindex));
    }
    IEnumerator LoadAsyn(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        loadingscreen.gameObject.SetActive(true);
        while (operation.isDone == false)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            text.text = progress * 100 + "%";
            slidrr.value = progress;
           // Debug.Log(progress);
            yield return null;
        }

    }
}
