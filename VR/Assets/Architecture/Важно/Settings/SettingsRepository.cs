using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Lessons.Architecture
{
    public class SettingsRepository : Repository
    {
        public float volumeBackgroundAudioSource;
        public float volumeEffectsAudioSource;
        public override void OnCreate()
        {
            base.OnCreate();
        }

        public override void Initialize()
        {
            if (File.Exists(Application.persistentDataPath + "/SettingsData.fun"))
            {
                SettingsData settingsData = GetSettingsData();
                volumeBackgroundAudioSource = settingsData.volumeBackgroundAudioSource;
                volumeEffectsAudioSource = settingsData.volumeEffectsAudioSource;
            }
            else
            {
                Save();
            }
        }

        public override void Save()
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            string path = Application.persistentDataPath + "/SettingsData.fun";
            FileStream stream = new FileStream(path, FileMode.Create);

            SettingsData settingsData = new SettingsData(volumeBackgroundAudioSource, volumeEffectsAudioSource);

            binaryFormatter.Serialize(stream, settingsData);
            stream.Close();
        }

        public SettingsData GetSettingsData()
        {
            string path = Application.persistentDataPath + "/SettingsData.fun";
            if (File.Exists(path))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                FileStream stream = new FileStream(path, FileMode.Open);

                SettingsData settingsData = binaryFormatter.Deserialize(stream) as SettingsData;
                stream.Close();

                return settingsData;
            }
            else
            {
                Debug.Log("Save file not found in " + path);
                return null;
            }
        }
    }

    [System.Serializable]
    public class SettingsData
    {
        public float volumeBackgroundAudioSource;
        public float volumeEffectsAudioSource;

        public SettingsData(float volumeBackgroundAudio, float volumeEffectsAudioSource)
        {
            this.volumeBackgroundAudioSource = volumeBackgroundAudio;
            this.volumeEffectsAudioSource = volumeEffectsAudioSource;
        }
    }
}
