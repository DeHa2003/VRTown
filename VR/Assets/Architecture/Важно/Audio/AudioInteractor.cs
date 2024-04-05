using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lessons.Architecture
{
    public class AudioInteractor : Interactor
    {
        private AudioManager audioManager;
        public void SetData(AudioManager audioManager, string startSound)
        {
            this.audioManager = audioManager;
            audioManager.PlayBackgroundSound(startSound);
        }

        public void PlayBackgroundSound(string nameClip)
        {
            audioManager.PlayBackgroundSound(nameClip);
        }

        public void PlayOtherSound(AudioSource audio, string clipName, float volume, float spatialBlend = 0)
        {
            audioManager.PlayOtherSound(audio, clipName, volume, spatialBlend);
        }

        public void PlayEffectSound(string nameClip)
        {
            audioManager.PlayEffectSound(nameClip);
        }
    }
}
