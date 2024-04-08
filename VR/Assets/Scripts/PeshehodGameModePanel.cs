using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PeshehodGameModePanel : ScaleColliderPanel
{
    [SerializeField] private GameObject plaingPanel;

    //[SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI nameLevel;

    //[SerializeField] private List<string> numberLevel;
    //[SerializeField] private List<Sprite> imagesTown;

    [SerializeField] private LevelVideo levelVideo;

    private int sceneNumber;
    private FadeScreenInteractor fadeScreenInteractor;

    public override void Initialize()
    {
        base.Initialize();

        fadeScreenInteractor = Game.GetInteractor<FadeScreenInteractor>();
    }

    public void NameLevel(string nameLevel)
    {
        this.nameLevel.text = nameLevel;
    }

    public void ViborGame(int level)
    {
        if(!plaingPanel.activeSelf)
            plaingPanel.SetActive(true);

        sceneNumber = level;
        levelVideo.PlayClip(level-2);
    }

    public void PlayGame()
    {
        if(sceneNumber != 0)
        {
            fadeScreenInteractor.StartFadeToTransition(1, sceneNumber);
        }
    }
}
