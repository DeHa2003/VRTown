using Lessons.Architecture;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class SceneManagerBase
{
    public event Action<Scene> OnSceneLoadEvent;
    public Scene scene { get; private set; }
    public bool isLoading { get; private set; }

    protected Dictionary<string, SceneConfig> sceneConfigsMap;

    public SceneManagerBase()
    {
        sceneConfigsMap = new Dictionary<string, SceneConfig>();
    }

    public abstract void InitSceneMap();

    private IEnumerator LoadCurrentSceneRoutine(SceneConfig sceneConfig)
    {
        this.isLoading = true;
        yield return Coroutines.StartRoutine(InitializeSceneRoutine(sceneConfig));

        this.isLoading = false;

        OnSceneLoadEvent?.Invoke(scene);
    }

    public Coroutine LoadCurrentSceneAsync()
    {
        if (isLoading)
            throw new Exception("Scene loading now");

        var sceneName = SceneManager.GetActiveScene().name;

        var config = this.sceneConfigsMap[sceneName];
        return Coroutines.StartRoutine(LoadCurrentSceneRoutine(config));
    }

    public Coroutine LoadNewSceneAsync(string sceneName)
    {
        if (isLoading)
            throw new Exception("Scene loading now");

        var config = this.sceneConfigsMap[sceneName];
        return Coroutines.StartRoutine(LoadNewSceneRoutine(config));
    }

    private IEnumerator LoadNewSceneRoutine(SceneConfig sceneConfig)
    {
        this.isLoading = true;

        yield return Coroutines.StartRoutine(LoadSceneRoutine(sceneConfig));
        yield return Coroutines.StartRoutine(InitializeSceneRoutine(sceneConfig));

        this.isLoading = false;

        OnSceneLoadEvent?.Invoke(scene);
    }



    private IEnumerator LoadSceneRoutine(SceneConfig sceneConfig)
    {
        var async = SceneManager.LoadSceneAsync(sceneConfig.sceneName);
        async.allowSceneActivation = false;

        while (async.progress < 0.9)
        {
            yield return null;
        }

        async.allowSceneActivation = true;
    }
    private IEnumerator InitializeSceneRoutine(SceneConfig sceneConfig)
    {
        this.scene = new Scene(sceneConfig);
        yield return this.scene.InitializeAsync();
    }

    public T GetRepository<T>() where T:Repository
    {
        return this.scene.GetRepository<T>();
    }

    public T GetInteractor<T>() where T : Interactor
    {
        return this.scene.GetInteractor<T>();
    }
}
