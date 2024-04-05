using Lessons.Architecture;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class Coins : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI textCoins;
    protected BankInteractor bankInteractor;

    public void Initialize()
    {
        bankInteractor = Game.GetInteractor<BankInteractor>();
        bankInteractor.OnChangeCoins += GetCoins;
        GetCoins();
    }

    private void OnDestroy()
    {
        bankInteractor.OnChangeCoins -= GetCoins;
    }
    private void GetCoins()
    {
        textCoins.text = bankInteractor.Coins.ToString();
    }
}
