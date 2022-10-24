using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobinManager : MonoBehaviour /* MonoSingleton<BobinManager>*/
{
    public List<GameObject> bobins = new List<GameObject>();

    [SerializeField] private int bobinCount;

    public int PlaneCount;

    public void PlaneFullBobinPlacemennt()
    {
        for (int i = 0; i < bobinCount; i++)
        {
            bobins[i].SetActive(true);
        }
    }

    public void BobinBuy()
    {
        if (ItemData.Instance.maxFactor.bobinCount >= ItemData.Instance.factor.bobinCount)
        {
            bobins[ItemData.Instance.field.bobinCount % bobinCount].SetActive(true);
            ItemData.Instance.factor.bobinCount++;
            if (ItemData.Instance.maxFactor.bobinCount == ItemData.Instance.factor.bobinCount)
            {
                ItemData.Instance.maxFactor.bobinCount += MyDoPath.Instance.runnerCount;
                GameManager.Instance.SetBobinCount();
                ItemData.Instance.BobinCount();
                Buttons.Instance.bobinCountText.text = ItemData.Instance.fieldPrice.bobinCount.ToString();
                BuyPlane.Instance.BobinCountMaxBool = true;
            }
        }
    }
}
