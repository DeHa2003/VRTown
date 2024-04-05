using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lessons.Architecture
{
    public class RepositoriesBase
    {
        private Dictionary<Type, Repository> repositoriesMap;
        private SceneConfig sceneConfig;

        public RepositoriesBase(SceneConfig sceneConfig)
        {
            this.sceneConfig = sceneConfig;
        }
        public void CreateAllRepositories()
        {
            repositoriesMap = sceneConfig.CreateAllRepositories();
        }

        public T GetRepository<T>() where T : Repository
        {
            var type = typeof(T);
            return (T)repositoriesMap[type];
        }






        //События
        public void SendOnCreateToAllRepositories()
        {
            var repositories = repositoriesMap.Values;

            foreach (var repository in repositories)
            {
                repository.OnCreate();
            }
        }
        public void InitializedToAllRepositories()
        {
            var repositories = repositoriesMap.Values;

            foreach (var repository in repositories)
            {
                repository.Initialize();
            }
        }
        public void StartAllRepositories()
        {
            var repositories = repositoriesMap.Values;

            foreach (var repository in repositories)
            {
                repository.OnStart();
            }
        }
    }
}
