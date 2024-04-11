using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Video;

public class LevelDescriptionPanel : ScaleColliderPanel
{
    [SerializeField] private TextMeshProUGUI textLevelNumber;
    [SerializeField] private TextMeshProUGUI textLevelName;
    [SerializeField] private TextMeshProUGUI textLevelDescription;
    [SerializeField] private LevelVideo levelVideo;

    private int scenePlay;
    private FadeScreenInteractor fadeScreenInteractor;

    public override void Initialize()
    {
        base.Initialize();
        fadeScreenInteractor = Game.GetInteractor<FadeScreenInteractor>();
    }

    public void SetData(LevelDescriptionScriptableObject levelDescription)
    {
        this.textLevelNumber.text = levelDescription.LevelNumber;
        this.textLevelName.text = levelDescription.LevelName;
        this.textLevelDescription.text = levelDescription.LevelDescription;
        this.scenePlay = levelDescription.LevelScene;

        levelVideo.SetVideoClip(levelDescription.VideoClip);
        levelVideo.Play();
    }

    public void PlayGame()
    {
        fadeScreenInteractor.StartFadeToTransition(1, scenePlay);
    }
}
