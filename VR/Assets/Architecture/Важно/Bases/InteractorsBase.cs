using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lessons.Architecture
{
    public class InteractorsBase
    {
        private Dictionary<Type, Interactor> interactorsMap;
        private SceneConfig sceneConfig;

        public InteractorsBase(SceneConfig sceneConfig)
        {
            this.sceneConfig = sceneConfig;
        }

        public void CreateAllInteractors()
        {
            interactorsMap = sceneConfig.CreateAllInteractors();
        }


        public T GetInteractor<T>() where T : Interactor
        {
            var type = typeof(T);
            return (T)interactorsMap[type];
        }





        //События
        public void SendOnCreateToAllInteractors()
        {
            var allInteractors = this.interactorsMap.Values;

            foreach (var interactor in allInteractors)
            {
                interactor.OnCreate();
            }
        }

        public void InitializedToAllInteractors()
        {
            var allInteractors = this.interactorsMap.Values;

            foreach (var interactor in allInteractors)
            {
                interactor.Initialize();
            }
        }

        public void StartAllInteractors()
        {
            var allInteractors = this.interactorsMap.Values;

            foreach (var interactor in allInteractors)
            {
                interactor.OnStart();
            }
        }
    }
}
