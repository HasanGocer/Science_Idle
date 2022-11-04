using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobinManager : MonoBehaviour /* MonoSingleton<BobinManager>*/
{
    public List<GameObject> bobins = new List<GameObject>();

    public int bobinCount;
    public int PlaneCount;


    public void PlaneFullBobinPlacemennt()
    {
        for (int i = 0; i < MyDoPath.Instance.runnerCount; i++)
        {
            bobins[i].SetActive(true);
        }
    }

    public void BobinPlacement()
    {
        if (ItemData.Instance.field.bobinCount % MyDoPath.Instance.runnerCount == 0)
        {
            for (int i = 0; i < MyDoPath.Instance.runnerCount; i++)
            {
                bobins[i].SetActive(true);
            }
        }
        else
        {
            for (int i = 0; i < ItemData.Instance.field.bobinCount % MyDoPath.Instance.runnerCount; i++)
            {
                bobins[i].SetActive(true);
            }
        }

    }

    public void BobinBuy()
    {
        ItemData.Instance.factor.bobinCount++;
        GameManager.Instance.SetBobinCount();
        ItemData.Instance.BobinCount();
        Buttons.Instance.bobinCountText.text = ItemData.Instance.fieldPrice.bobinCount.ToString();

        if (ItemData.Instance.field.bobinCount % MyDoPath.Instance.runnerCount == 0)
        {
            bobins[MyDoPath.Instance.runnerCount - 1].SetActive(true);
        }
        else
        {
            bobins[(ItemData.Instance.field.bobinCount % MyDoPath.Instance.runnerCount) - 1].SetActive(true);
        }

        if (ItemData.Instance.maxFactor.bobinCount == ItemData.Instance.factor.bobinCount)
        {
            ItemData.Instance.maxFactor.bobinCount += MyDoPath.Instance.runnerCount;
            Buttons.Instance.bobinCountText.text = "Full";
            Buttons.Instance.bobinCountButton.enabled = false;
            BuyPlane.Instance.BobinCountMaxBool = true;
            BuyPlane.Instance.NewMoneyPlaneButton();
        }
    }
}
