using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionControl : PlayerComponentControl
{
    private PlayerFadeScreenScript transitions;
    private void Awake()
    {
        Debug.Log("Дочерний класс");
        transitions = getPlayer.player.GetComponentInChildren<PlayerFadeScreenScript>();
    }

    public void LoadScene(int sceneNumber)
    {
        //StartCoroutine(transitions.LoadSceneCoroutine(sceneNumber));
    }
}
