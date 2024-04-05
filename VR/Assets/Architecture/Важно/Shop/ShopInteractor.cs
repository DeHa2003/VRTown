using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lessons.Architecture
{
    public class ShopInteractor : Interactor
    {
        public Action OnBuy;
        public List<int> IDsARItems { get; private set; }
        public List<int> IDsARTargets { get; private set; }

        private ShopRepository shopRepository;
        public override void OnCreate()
        {
            base.OnCreate();
            IDsARItems = new List<int>();
            IDsARTargets = new List<int>();
        }
        public override void Initialize()
        {
            base.Initialize();
            shopRepository = Game.GetRepository<ShopRepository>();
        }

        public override void OnStart()
        {
            base.OnStart();
            this.IDsARItems = shopRepository.IDsARItems;
            this.IDsARTargets = shopRepository.IDsARTargets;
        }

        public void BuyARItem(object sender, int value)
        {
            OnBuy?.Invoke();

            if(IDsARItems.Count == 0) { IDsARItems.Add(value); shopRepository.Save(); return; }

            for (int i = 0; i < IDsARItems.Count; i++)
            {
                if (IDsARItems[i] != value)
                {
                    this.IDsARItems.Add(value);
                    shopRepository.Save();
                    break;
                }
            }
        }

        public void BuyARTarget(object sender, int value)
        {
            OnBuy?.Invoke();

            if (IDsARTargets.Count == 0) { IDsARTargets.Add(value); shopRepository.Save(); return; }

            for (int i = 0; i < IDsARTargets.Count; i++)
            {
                if (IDsARTargets[i] != value)
                {
                    this.IDsARTargets.Add(value);
                    shopRepository.Save();
                    break;
                }
            }
        }
    }
}
