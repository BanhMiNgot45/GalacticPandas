using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundAction : Action
{
    private string message;
    AudioSource sound;
    AudioClip clip;
    public PlaySoundAction(AudioSource s, AudioClip c, Battle b):base(null,null,b)
    {
        sound = s;
        clip = c;

    }

    public override System.Object init()
    {
        sound.Stop();
        sound.time = 0;
        sound.clip = clip;
        sound.Play();
        return null;
    }

    public override System.Object _run()
    {
         kill();
        return null;
    }
    public override System.Object cleanUp()
    {
        return null;
    }
}
