using Pukui.Sound;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Pukui.Sound
{
    public class SoundDatabaseWrapper
    {
        public SoundDatabase Database => SoundSettings.Database;

        Dictionary<string, AudioMixerGroupData> _mixerGroupDataDic;
        Dictionary<(AudioMixerGroupData, string), SoundData> _soundDataDic;

        bool _isInitialized = false;

        public void Init()
        {
            if (_isInitialized)
            {
                return;
            }

            _isInitialized = true;

            // Convert Dictionary.
            _mixerGroupDataDic = new();
            _soundDataDic = new();
            foreach (AudioMixerGroupData a in Database.mixerGroupDataArray)
            {
                _mixerGroupDataDic.Add(a.mixerGroupName, a);
                foreach (SoundData s in a.sounds)
                {
                    _soundDataDic.Add((a, s.soundName), s);
                }
            }
        }

        public AudioMixerGroupData GetMixerGroupData(string mixerGroupName)
        {
            return _mixerGroupDataDic[mixerGroupName];
        }

        public SoundData GetSoundData(AudioMixerGroupData mixerGroupData, string soundName)
        {
            return _soundDataDic[(mixerGroupData, soundName)];
        }

    }
}
