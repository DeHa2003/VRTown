using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Lessons.Architecture
{
    public class ShopRepository : Repository
    {
        public List<int> IDsARItems { get; set; }
        public List<int> IDsARTargets { get; set; }
        public override void OnCreate()
        {
            base.OnCreate();
            IDsARItems = new List<int>();
            IDsARTargets = new List<int>();
        }

        public override void Initialize()
        {
            if(File.Exists(Application.persistentDataPath + "/Shop.fun"))
            {
                ShopID shop = GetShopID();
                IDsARItems = shop.IDsARItems.ToList();
                IDsARTargets = shop.IDsARTargets.ToList();
            }
            else
            {
                IDsARItems.Add(0);
                IDsARTargets.Add(0);
                Save();
            }
        }
        
        public override void Save()
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            string path = Application.persistentDataPath + "/Shop.fun";
            FileStream stream = new FileStream(path, FileMode.Create);

            ShopID shopID = new ShopID(IDsARItems, IDsARTargets);

            binaryFormatter.Serialize(stream, shopID);
            stream.Close();
        }

        public ShopID GetShopID()
        {
            string path = Application.persistentDataPath + "/Shop.fun";
            if (File.Exists(path))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);

                ShopID data = binaryFormatter.Deserialize(stream) as ShopID;
                stream.Close();

                return data;
            }
            else
            {
                Debug.Log("Save file not found in " + path);
                return null;
            }
        }
    }

    [System.Serializable]
    public class ShopID
    {
        public int[] IDsARItems;
        public int[] IDsARTargets;
        
        public ShopID(List<int> list, List<int> list2)
        {
            this.IDsARItems = new int[list.Count];
            this.IDsARItems = list.ToArray();

            this.IDsARTargets = new int[list2.Count];
            this.IDsARTargets = list2.ToArray();
        }
    }
}
