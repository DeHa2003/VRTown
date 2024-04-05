using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lessons.Architecture
{
    public class BankInteractor : Interactor
    {
        public Action OnChangeCoins;
        private BankRepository repository;

        public int Coins => this.repository.coins;

        public override void OnCreate()
        {
            base.OnCreate();
            this.repository = Game.GetRepository<BankRepository>();
        }

        public override void Initialize()
        {
            Bank.Initialize(this);
        }

        public bool IsEnoughtCoins(int value)
        {
            return Coins >= value;
        }

        public void AddCoins(object sender, int value)
        {
            this.repository.coins += value;
            this.repository.Save();

            OnChangeCoins?.Invoke();
        }

        public void Spend(object sender, int value)
        {
            this.repository.coins -= value;
            this.repository.Save();

            OnChangeCoins?.Invoke();
        }
    }
}
