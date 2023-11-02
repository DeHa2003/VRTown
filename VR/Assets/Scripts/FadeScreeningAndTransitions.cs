using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Valve.VR;

public class FadeScreeningAndTransitions : MonoBehaviour
{
    [SerializeField] private Color startColor;
    [SerializeField] private Color endColor;
    [SerializeField] private float duration;

    public IEnumerator LoadSceneCoroutine(int sceneNumber)
    {
        Time.timeScale = 1.0f;
        SteamVR_Fade.Start(startColor, duration);

        yield return new WaitForSeconds(duration);
        SceneManager.LoadScene(sceneNumber);


        SteamVR_Fade.Start(endColor, duration);
    }
}
