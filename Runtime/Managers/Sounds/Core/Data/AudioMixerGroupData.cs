using UnityEngine.Audio;

namespace Pukui.Sound
{
    [System.Serializable]
    public class AudioMixerGroupData
    {
        public string mixerGroupName;
        public AudioMixerGroup mixerGroup;
        public SoundData[] sounds;
    }
}