using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager : MonoSingleton<PointManager>
{
    public void MonneyUpperFunc()
    {
        if (ItemData.Instance.maxFactor.addedMoney >= ItemData.Instance.factor.addedMoney)
        {
            GameManager.Instance.SetAddedResearchPoint();
            ItemData.Instance.AddedResearchPoint();

        }

    }
}
