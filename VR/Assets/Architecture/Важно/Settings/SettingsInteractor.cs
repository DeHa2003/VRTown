using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lessons.Architecture
{
    public class SettingsInteractor : Interactor
    {
        public float volumeBackgroundAudioSource { get; private set; }
        public float volumeEffectsAudioSource { get; private set; }

        private AudioManager audioManager;
        private SettingsRepository settingsRepository;

        public override void Initialize()
        {
            base.Initialize();
            settingsRepository = Game.GetRepository<SettingsRepository>();
        }

        public override void OnStart()
        {
            base.OnStart();
            this.volumeBackgroundAudioSource = settingsRepository.volumeBackgroundAudioSource;
            this.volumeEffectsAudioSource = settingsRepository.volumeEffectsAudioSource;
        }

        public void SetData(AudioManager audioManager)
        {
            this.audioManager = audioManager;
            audioManager.ChangeVolumeEffectsSound(this.volumeEffectsAudioSource);
            audioManager.ChangeVolumeBackgroundSound(this.volumeBackgroundAudioSource);
        }

        public void ChangeVolumeBackgroundSound(object sender, float value)
        {
            volumeBackgroundAudioSource = value;
            audioManager.ChangeVolumeBackgroundSound(value);
        }

        public void ChangeVolumeEffectsSound(object sender, float value)
        {
            volumeEffectsAudioSource = value;
            audioManager.ChangeVolumeEffectsSound(value);
        }

        public void ApplyChanges()
        {
            settingsRepository.volumeBackgroundAudioSource = volumeBackgroundAudioSource;
            settingsRepository.volumeEffectsAudioSource = volumeEffectsAudioSource;
            settingsRepository.Save();
        }

    }
}
