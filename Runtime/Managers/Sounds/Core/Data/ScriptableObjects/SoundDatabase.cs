using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace Pukui.Sound
{
    [CreateAssetMenu(fileName = "SoundDatabase", menuName = "Pukui/Sound Database")]
    public class SoundDatabase : ScriptableObject
    {
        public AudioMixerGroup masterMixerGroup;
        public AudioMixerGroupData[] mixerGroupDataArray;
    }
}
