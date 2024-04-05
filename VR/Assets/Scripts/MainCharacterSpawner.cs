using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class MainCharacterSpawner : MonoBehaviour
{
    [SerializeField] Player playerPref;
    [SerializeField] private Player playerThisScene;

    private Player activePlayer;
    private void Start()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        if(players.Length == 2)
        {
            Destroy(players[1]);
        }
    }
}
