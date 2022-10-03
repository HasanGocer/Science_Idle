using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatManager : MonoSingleton<GameStatManager>
{
    public int runnerCountFactor, runnerSpeedFactor, bobinCountFactor, addedMoneyFactor;
    public int runnerCount, bobinCount;
    public float runnerSpeed, addedMoney;
}
