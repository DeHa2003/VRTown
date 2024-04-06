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

        private CharacterController characterController;

        public override void Initialize()
        {
            base.Initialize();
            SceneManager.sceneUnloaded += OnSceneUnloaded;
        }

        public void CreatePlayer()
        {
            if (GamePlayer != null)
            {
                DestroyPlayer();
            }
            Debug.Log("�������� ������");

            GamePlayer = Coroutines.Instantiate(Resources.Load<Player>(PLAYER_PREFAB_PATH));
            characterController = GamePlayer.GetComponent<CharacterController>();
            GamePlayer.GetComponent<PlayerComponents>().Initialize();
        }

        public void DestroyPlayer()
        {
            if (GamePlayer == null)
            {
                Debug.LogWarning("�� ��������� ������� ������� ������");
                return;
            }

            Coroutines.Destroy(GamePlayer.gameObject);
            SceneManager.sceneUnloaded -= OnSceneUnloaded;
        }

        public void PlayerToPosition(Vector3 vector)
        {
            characterController.enabled = false;
            characterController.transform.position = vector;
            characterController.enabled = true;
        }

        #region Events

        private void OnSceneUnloaded(UnityEngine.SceneManagement.Scene arg0)
        {
            DestroyPlayer();
        }

        #endregion
    }
}
