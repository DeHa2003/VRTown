using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR.InteractionSystem;

namespace Lessons.Architecture
{
    public class PlayerInteractor : Interactor
    {
        private const string PLAYER_PREFAB_PATH = "Prefabs/GamePlayer";
        public Player GamePlayer { get; private set; }

        public override void OnCreate()
        {
            base.OnCreate();
        }

        public override void Initialize()
        {
            base.Initialize();
            SceneManager.sceneUnloaded += OnSceneUnloaded;
        }

        private void OnSceneUnloaded(UnityEngine.SceneManagement.Scene arg0)
        {
            DestroyPlayer();
        }

        public override void OnStart()
        {
            base.OnStart();

            CreatePlayer();
        }

        private void CreatePlayer()
        {
            if(GamePlayer != null)
            {
                DestroyPlayer();
            }
            Debug.Log("Создание игрока");

            GamePlayer = Coroutines.Instantiate(Resources.Load<Player>(PLAYER_PREFAB_PATH));
            GamePlayer.GetComponent<PlayerComponents>().Initialize();
        }

        private void DestroyPlayer()
        {
            if(GamePlayer == null)
            {
                Debug.LogWarning("Вы пытаетесь удалить пустого игрока");
                return;
            }

            Coroutines.Destroy(GamePlayer.gameObject);
            SceneManager.sceneUnloaded -= OnSceneUnloaded;
        }
    }
}
