using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionControl : PlayerComponentControl
{
    private FadeScreeningAndTransitions transitions;
    private void Awake()
    {
        Debug.Log("Дочерний класс");
        transitions = getPlayer.player.GetComponentInChildren<FadeScreeningAndTransitions>();
    }

    public void LoadScene(int sceneNumber)
    {
        StartCoroutine(transitions.LoadSceneCoroutine(sceneNumber));
    }
}
