using Lessons.Architecture;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SceneConfig : MonoBehaviour
{
    public abstract Dictionary<Type, Repository> CreateAllRepositories();
    public abstract Dictionary<Type, Interactor> CreateAllInteractors();

    public abstract string sceneName { get; }

    public void CreateInteractor<T>(Dictionary<Type, Interactor> interactorMap) where T:Interactor, new()
    {
        var interactor = new T();
        var type = typeof(T);
        interactorMap[type] = interactor;

    }

    public void CreateRepository<T>(Dictionary<Type, Repository> repositoryMap) where T : Repository, new()
    {
        var repository = new T();
        var type = typeof(T);
        repositoryMap[type] = repository;

    }
}
