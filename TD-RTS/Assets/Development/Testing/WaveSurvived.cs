using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveSurvived : MonoBehaviour {

    public TextMeshProUGUI wavesText;

    void OnEnable()
    {
        StartCoroutine(AnimateText());
    }
    IEnumerator AnimateText()
    {
        wavesText.text = "0";
        int wave = 0;

        yield return new WaitForSeconds(0.2f);

        while (wave < PlayerStats.Waves)
        {
            wave++;
            wavesText.text = wave.ToString();

            yield return new WaitForSeconds(0.05f);
        }
    }

}
