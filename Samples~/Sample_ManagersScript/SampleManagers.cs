using Pukui.Sound;
using UnityEngine;

public class SampleManagers : SingletonMono<SampleManagers>
{
    SoundManager _sound = new SoundManager();

    public static SoundManager Sound { get { return Instance._sound; } }

    private void Start()
    {
        _sound.Init();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.V))
        {
            Sound.Play("BGM", "lobby_bgm");
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            Sound.Play("SFX", "click_normal");
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            Sound.Play("SFX", "click_wrong");
        }
    }
}
