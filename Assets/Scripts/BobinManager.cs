using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobinManager : MonoBehaviour /* MonoSingleton<BobinManager>*/
{
    public List<GameObject> bobins = new List<GameObject>();

    public int bobinCount;
    public int PlaneCount;
    [SerializeField] private float particalSeenTime;
    [SerializeField] private int OPBobinParticalCount;


    public void PlaneFullBobinPlacemennt()
    {
        for (int i = 0; i < MyDoPath.Instance.runnerCount; i++)
        {
            bobins[i].SetActive(true);
            StartCoroutine(Partical(i));
        }
    }

    public void BobinPlacement()
    {
        if (ItemData.Instance.field.bobinCount % MyDoPath.Instance.runnerCount == 0)
        {
            for (int i = 0; i < MyDoPath.Instance.runnerCount; i++)
            {
                bobins[i].SetActive(true);
                StartCoroutine(Partical(i));
            }
        }
        else
        {
            for (int i = 0; i < ItemData.Instance.field.bobinCount % MyDoPath.Instance.runnerCount; i++)
            {
                bobins[i].SetActive(true);
                StartCoroutine(Partical(i));
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
            StartCoroutine(Partical(MyDoPath.Instance.runnerCount - 1));
        }
        else
        {
            bobins[(ItemData.Instance.field.bobinCount % MyDoPath.Instance.runnerCount) - 1].SetActive(true);
            StartCoroutine(Partical((ItemData.Instance.field.bobinCount % MyDoPath.Instance.runnerCount) - 1));
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

    IEnumerator Partical(int count)
    {
        GameObject partical = ObjectPool.Instance.GetPooledObject(OPBobinParticalCount);
        partical.transform.position = bobins[count].transform.position;
        yield return new WaitForSeconds(particalSeenTime);
        ObjectPool.Instance.AddObject(OPBobinParticalCount, partical);
    }
}
