using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene
{
    private InteractorsBase interactorsBase;
    private RepositoriesBase repositoriesBase;
    private SceneConfig sceneConfig;

    public Scene(SceneConfig sceneConfig)
    {
        this.sceneConfig = sceneConfig;
        interactorsBase = new InteractorsBase(this.sceneConfig);
        repositoriesBase = new RepositoriesBase(this.sceneConfig);
    }

    public Coroutine InitializeAsync()
    {
        return Coroutines.StartRoutine(this.InitializeRoutine());
    }

    private IEnumerator InitializeRoutine()
    {
        interactorsBase.CreateAllInteractors();
        repositoriesBase.CreateAllRepositories();

        yield return null;

        interactorsBase.SendOnCreateToAllInteractors();
        repositoriesBase.SendOnCreateToAllRepositories();

        yield return null;

        interactorsBase.InitializedToAllInteractors();
        repositoriesBase.InitializedToAllRepositories();

        yield return null;

        interactorsBase.StartAllInteractors();
        repositoriesBase.StartAllRepositories();
    }




    public T GetRepository<T>() where T : Repository
    {
        var type = typeof(T);
        return repositoriesBase.GetRepository<T>();
    }
    public T GetInteractor<T>() where T : Interactor
    {
        var type = typeof(T);
        return interactorsBase.GetInteractor<T>();
    }
}
