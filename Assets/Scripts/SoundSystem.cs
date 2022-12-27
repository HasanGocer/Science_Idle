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
        mainSource.enabled = true;
    }

    public void MainMusicStop()
    {
        mainSource.Stop();
        mainSource.enabled = false;
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
