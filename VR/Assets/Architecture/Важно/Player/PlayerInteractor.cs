using System;
using UnityEngine;
using Valve.VR.InteractionSystem;

namespace Lessons.Architecture
{
    public class PlayerInteractor : Interactor, IPlayerInteractorProvider , IPlayerEvents, IPlayerInteractorProvider_SetData
    {
        public GamePlayer GamePlayer { get; private set; }

        public event Action<GamePlayer> OnCreatePlayer;
        public event Action OnDestroyPlayer;

        private const string PLAYER_PREFAB_PATH = "Prefabs/GamePlayer";
        private string target;

        public void CreatePlayer()
        {
            //if (GamePlayer != null)
            //{
            //    DestroyPlayer();
            //}
            //Debug.Log("Создание игрока");

            if (Player.instance == null)
            {
                 Coroutines.DontDestroyOnLoad(Coroutines.Instantiate(Resources.Load<Player>(PLAYER_PREFAB_PATH)));
            }
            GamePlayer = Player.instance.GetComponent<GamePlayer>();
            GamePlayer.Initialize();
            GamePlayer.SetMenuTarget(target);

            OnCreatePlayer?.Invoke(GamePlayer);
        }

        public void DestroyPlayer()
        {
            if (GamePlayer == null)
            {
                Debug.LogWarning("Вы пытаетесь удалить пустого игрока");
                return;
            }

            Coroutines.Destroy(GamePlayer.gameObject);
            OnDestroyPlayer?.Invoke();
        }

        public void SetData(string nameTarget)
        {
            this.target = nameTarget;
        }
    }
}

public interface IPlayerInteractorProvider : IInterface
{
    GamePlayer GamePlayer { get; }
    void CreatePlayer();
    void DestroyPlayer();
}

public interface IPlayerEvents : IInterface
{
    event Action<GamePlayer> OnCreatePlayer;
    event Action OnDestroyPlayer;
}

public interface IPlayerInteractorProvider_SetData
{
    void SetData(string nameTarget);
}
