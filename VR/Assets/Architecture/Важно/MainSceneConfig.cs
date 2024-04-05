using Lessons.Architecture;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneConfig : SceneConfig
{
    public const string SCENE_NAME = "MainScene";
    public override string sceneName => SCENE_NAME;

    public override Dictionary<Type, Interactor> CreateAllInteractors()
    {
        var interactorsMap = new Dictionary<Type, Interactor>();

        CreateInteractor<SettingsInteractor>(interactorsMap);
        CreateInteractor<AudioInteractor>(interactorsMap);
        CreateInteractor<NotificationInteractor>(interactorsMap);
        CreateInteractor<PanelAnimationInteractor>(interactorsMap);
        CreateInteractor<ShopInteractor>(interactorsMap);
        CreateInteractor<ScoreInteractor>(interactorsMap);
        CreateInteractor<BallsInteractor>(interactorsMap);
        CreateInteractor<BankInteractor>(interactorsMap);

        return interactorsMap;
    }

    public override Dictionary<Type, Repository> CreateAllRepositories()
    {
        var repositoriesMap = new Dictionary<Type, Repository>();

        CreateRepository<SettingsRepository>(repositoriesMap);
        CreateRepository<ShopRepository>(repositoriesMap);
        CreateRepository<ScoreRepository>(repositoriesMap);
        CreateRepository<BallsRepository>(repositoriesMap);
        CreateRepository<BankRepository>(repositoriesMap);

        return repositoriesMap;
    }
}
