using UnityEngine;

namespace Pukui.Sound
{
    public class SoundManager
    {
        static SoundDatabaseWrapper s_database;
        static SoundPooler s_pooler;

        public static SoundDatabaseWrapper Database => s_database;
        public static SoundPooler Pooler => s_pooler;

        public void Init()
        {
            GameObject root = GameObject.Find("@Sound");
            if (root == null)
            {
                root = new GameObject { name = "@Sound" };
                Object.DontDestroyOnLoad(root);
            }

            if (s_database == null)
            {
                s_database = new SoundDatabaseWrapper();
                s_database.Init();
            }
            if (s_pooler == null)
            {
                s_pooler = new SoundPooler();
                s_pooler.Init(root.transform);
            }
        }

        public SoundController Play(string mixerGroupName, string soundName)
        {
            AudioMixerGroupData amgd = Database.GetMixerGroupData(mixerGroupName);
            if (amgd == null) return null;

            SoundData sd = Database.GetSoundData(amgd, soundName);
            if (sd == null) return null;

            SoundController sc = Pooler.GetController();
            sc.SetSourceProperties(amgd.mixerGroup, sd.soundClip);
            sc.gameObject.name = $"{sd.soundClip.name}";
            sc.Play();

            return null;
        }
    }
}

