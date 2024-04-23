using System;
using UnityEngine;
using Valve.VR.InteractionSystem;

namespace Lessons.Architecture
{
    public class PlayerInteractor : Interactor, IPlayerInteractorProvider , IPlayerEvents
    {
        public GamePlayer GamePlayer { get; private set; }

        public event Action<GamePlayer> OnCreatePlayer;
        public event Action OnDestroyPlayer;

        private const string PLAYER_PREFAB_PATH = "Prefabs/GamePlayer";

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
    }
}

public interface IPlayerInteractorProvider : IInterface
{
    void CreatePlayer();
    void DestroyPlayer();
}

public interface IPlayerEvents : IInterface
{
    event Action<GamePlayer> OnCreatePlayer;
    event Action OnDestroyPlayer;
}
