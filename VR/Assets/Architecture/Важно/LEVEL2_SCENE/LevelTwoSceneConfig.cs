using Lessons.Architecture;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTwoSceneConfig : SceneConfig
{
    public const string SCENE_NAME = "Level2_Scene";
    public override string sceneName => SCENE_NAME;

    public override Dictionary<Type, Interactor> CreateAllInteractors()
    {
        var interactorsMap = new Dictionary<Type, Interactor>();

        CreateInteractor<PlayerInteractor>(interactorsMap);
        CreateInteractor<TransitionInteractor>(interactorsMap);
        CreateInteractor<FootballInteractor>(interactorsMap);
        CreateInteractor<CarsInteractor>(interactorsMap);
        CreateInteractor<DroneInteractor>(interactorsMap);

        //CreateInteractor<SettingsInteractor>(interactorsMap);
        //CreateInteractor<AudioInteractor>(interactorsMap);
        //CreateInteractor<NotificationInteractor>(interactorsMap);
        //CreateInteractor<PanelAnimationInteractor>(interactorsMap);
        //CreateInteractor<BankInteractor>(interactorsMap);
        //CreateInteractor<ShopInteractor>(interactorsMap);

        return interactorsMap;
    }

    public override Dictionary<Type, Repository> CreateAllRepositories()
    {
        var repositoriesMap = new Dictionary<Type, Repository>();

        //CreateRepository<SettingsRepository>(repositoriesMap);
        //CreateRepository<BankRepository>(repositoriesMap);
        //CreateRepository<ShopRepository>(repositoriesMap);

        return repositoriesMap;
    }
}
