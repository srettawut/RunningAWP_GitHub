using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour
{
    public CanvasGroup panel;
    public float fadeDuration = 1f;

    [Header("CHANGE CAM BUTTON")]
    public GameObject camButton1;
    public GameObject camButton2;
    public GameObject camButton3;

    private void Start()
    {
        panel.alpha = 0;
    }
    public void FadeOutIn()
    {
        StartCoroutine(FadeSequecne());
    }
    IEnumerator FadeSequecne()
    {
        yield return StartCoroutine(Fade(0,1));

        yield return new WaitForSeconds(0.3f);

        yield return StartCoroutine(Fade(1,0));
    }

    IEnumerator Fade(float start,float end)
    {
        float elapsed = 0f;
        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            panel.alpha=Mathf.Lerp(start,end,elapsed/fadeDuration);
            yield return null;
        }
        panel.alpha = end;
    }
    
    public void OpenButton1()
    {
        camButton1.SetActive(true);
        camButton2.SetActive(false);
        camButton3.SetActive(false);
    }

    public void OpenButton2()
    {
        camButton1.SetActive(false);
        camButton2.SetActive(true);
        camButton3.SetActive(false);
    }

    public void OpenButton3()
    {
        camButton1.SetActive(false);
        camButton2.SetActive(false);
        camButton3.SetActive(true);
    }
}
