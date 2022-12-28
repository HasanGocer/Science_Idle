using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSystem : MonoSingleton<SoundSystem>
{
    [SerializeField] private AudioSource mainSource;
    [SerializeField] private AudioClip mainMusic, missionCompletedEffect, newMoneyPlaneBuyEffect, newResearchPlaneBuyEffect, buyFieldEffect;

    public void MainMusicPlay()
    {
        mainSource.clip = mainMusic;
        mainSource.Play();
        mainSource.volume = 70;
        mainSource.mute = false;
    }

    public void MainMusicStop()
    {
        mainSource.Stop();
        mainSource.volume = 0;
        mainSource.mute = true;
    }

    public void CallMissionCompletedEffect()
    {
        mainSource.PlayOneShot(missionCompletedEffect);
    }

    public void CallNewMoneyTableEffect()
    {
        mainSource.PlayOneShot(newMoneyPlaneBuyEffect);
    }

    public void CallNewResearchTableEffect()
    {
        mainSource.PlayOneShot(newResearchPlaneBuyEffect);
    }

    public void CallBuyFieldEffect()
    {
        mainSource.PlayOneShot(buyFieldEffect);
    }
}
