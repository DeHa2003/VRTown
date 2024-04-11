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
        //public Player GamePlayer { get; private set; }
        public PlayerComponents PlayerComponents { get; private set; }


        private CharacterController characterController;

        public override void Initialize()
        {
            base.Initialize();
            SceneManager.sceneUnloaded += OnSceneUnloaded;
        }

        public void CreatePlayer()
        {
            //if (GamePlayer != null)
            //{
            //    DestroyPlayer();
            //}
            //Debug.Log("Создание игрока");

            if(Player.instance == null)
            {
                 Coroutines.DontDestroyOnLoad(Coroutines.Instantiate(Resources.Load<Player>(PLAYER_PREFAB_PATH)));
            }

            PlayerComponents = Player.instance.GetComponent<PlayerComponents>();
            characterController = Player.instance.GetComponent<CharacterController>();
            Player.instance.GetComponent<PlayerComponents>().Initialize();

            //GamePlayer = Coroutines.Instantiate(Resources.Load<Player>(PLAYER_PREFAB_PATH));
            //PlayerComponents = GamePlayer.GetComponent<PlayerComponents>();
            //characterController = GamePlayer.GetComponent<CharacterController>();
            //GamePlayer.GetComponent<PlayerComponents>().Initialize();
        }

        //public void DestroyPlayer()
        //{
        //    if (GamePlayer == null)
        //    {
        //        Debug.LogWarning("Вы пытаетесь удалить пустого игрока");
        //        return;
        //    }

        //    Coroutines.Destroy(GamePlayer.gameObject);
        //    SceneManager.sceneUnloaded -= OnSceneUnloaded;
        //}

        public void PlayerToPosition(Vector3 vector)
        {
            characterController.enabled = false;
            characterController.transform.position = vector;
            characterController.enabled = true;
        }

        #region Events

        private void OnSceneUnloaded(UnityEngine.SceneManagement.Scene arg0)
        {
            //DestroyPlayer();
        }

        #endregion
    }
}
