using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Valve.VR;

public class FadeScreeningAndTransitions : MonoBehaviour
{
    public Color startColor;
    public Color endColor;
    public float duration;

    public void LoadScene(int sceneNumber)
    {
        StartCoroutine(Fade(sceneNumber));
    }
    private IEnumerator Fade(int sceneNumber)
    {
        Time.timeScale = 1.0f;
        SteamVR_Fade.Start(startColor, duration);

        yield return new WaitForSeconds(duration);
        SceneManager.LoadScene(sceneNumber);


        SteamVR_Fade.Start(endColor, duration);
    }
}
