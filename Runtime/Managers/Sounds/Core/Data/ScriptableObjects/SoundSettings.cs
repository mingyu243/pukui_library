using UnityEngine;

namespace Pukui.Sound
{
    [CreateAssetMenu(fileName = "SoundSettings", menuName = "Pukui/Sound Settings")]
    public class SoundSettings : ScriptableObject
    {
        [SerializeField] SoundDatabase _database;
        [SerializeField] int _controllerMaxSize;

        static SoundSettings s_instance;

        public static SoundSettings Instance
        {
            get
            {
                if (s_instance != null)
                {
                    return s_instance;
                }
                s_instance = Resources.Load<SoundSettings>("SoundSettings");
                return s_instance;
            }
        }

        public static SoundDatabase Database => Instance._database;
        public static int ControllerMaxSize => Instance._controllerMaxSize;
    }
}