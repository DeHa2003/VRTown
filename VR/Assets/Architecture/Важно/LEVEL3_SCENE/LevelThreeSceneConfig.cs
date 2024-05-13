using Lessons.Architecture;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelThreeSceneConfig : SceneConfig
{
    public const string SCENE_NAME = "Level3_Scene";
    public override string sceneName => SCENE_NAME;

    public override Dictionary<Type, Interactor> CreateAllInteractors()
    {
        var interactorsMap = new Dictionary<Type, Interactor>();

        CreateInteractor<PlayerInteractor>(interactorsMap);
        CreateInteractor<TransitionInteractor>(interactorsMap);
        CreateInteractor<CarsInteractor>(interactorsMap); 

        return interactorsMap;
    }

    public override Dictionary<Type, Repository> CreateAllRepositories()
    {
        var repositoriesMap = new Dictionary<Type, Repository>();



        return repositoriesMap;
    }
}
