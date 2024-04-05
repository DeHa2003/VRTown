using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lessons.Architecture
{
    public static class Bank
    {
        public static bool isInitialized = false;
        public static int coins => bankInteractor.Coins;

        private static BankInteractor bankInteractor;

        public static void Initialize(BankInteractor interactor)
        {
            bankInteractor = interactor;
            isInitialized = true;
        }

        public static bool IsEnoughCoins(int value)
        {
            return bankInteractor.IsEnoughtCoins(value);
        }

        public static void AddCoins(object sender, int value)
        {
            bankInteractor.AddCoins(sender, value);
        }

        public static void Spend(object sender, int value)
        {
            bankInteractor.Spend(sender, value);
        }

    }
}
