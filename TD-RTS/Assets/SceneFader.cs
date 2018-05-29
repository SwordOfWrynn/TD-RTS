using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour {

    public Image img;
    public AnimationCurve curve;

    void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FadeTo(string _scene)
    {
        StartCoroutine(FadeOut(_scene));
    }


    IEnumerator FadeIn()
    {
        float t = 1f;
        while (t > 0)
        {
            t -= Time.deltaTime;
            float a = curve.Evaluate(t);
            img.color = new Color(0, 0, 0, a);
            yield return 0;
        }
    }

    IEnumerator FadeOut(string _scene)
    {
        float t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime;
            float a = curve.Evaluate(t);
            img.color = new Color(0, 0, 0, a);
            yield return 0;
        }
        SceneManager.LoadScene(_scene);
    }

}
