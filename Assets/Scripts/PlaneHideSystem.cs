using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlaneHideSystem : MonoSingleton<PlaneHideSystem>
{
    public int planeLimit;
    [SerializeField] private int _OPRunnerCount, _OPMoneyPlaneCount, _OPResearchPlaneCount;
    [SerializeField] private float _moneyRespawnTime, _researchRespawnTime;

    public int moneyHidePlaneCount, researchHidePlaneCount;

    public void MoneyPlaneHide()
    {
        if (BuyPlane.Instance.MoneyPlanes.Count > planeLimit)
        {
            for (int i = 0; i < MyDoPath.Instance.runnerCount; i++)
            {
                BuyPlane.Instance.MoneyPlanes[BuyPlane.Instance.MoneyPlanes.Count - planeLimit - 1].GetComponent<BobinManager>().bobins[i].SetActive(false);
                ObjectPool.Instance.AddObject(_OPRunnerCount, RunnerManager.Instance.Runner[((BuyPlane.Instance.MoneyPlanes.Count - planeLimit - 1) * MyDoPath.Instance.runnerCount) + i]);
            }
            ObjectPool.Instance.AddObject(_OPMoneyPlaneCount, BuyPlane.Instance.MoneyPlanes[BuyPlane.Instance.MoneyPlanes.Count - planeLimit - 1].gameObject);
            moneyHidePlaneCount++;
            GameManager.Instance.SetMoneyHidePlaneCount();
            StartCoroutine(HideMoneyAdded());
        }
    }

    public void ResearchPlaneHide()
    {
        if (BuyPlane.Instance.ResearchPlanes.Count > planeLimit)
        {
            TableBuy tableBuy = BuyPlane.Instance.ResearchPlanes[BuyPlane.Instance.ResearchPlanes.Count - planeLimit - 1].GetComponent<TableBuy>();
            for (int i = 0; i < 6; i++)
            {
                tableBuy.PasiveTables[i].SetActive(false);
                tableBuy.ActiveTables[i].GetComponent<TableWork>().hide = true;
            }
            tableBuy.ActiveTables.Clear();
            tableBuy.ActiveTablesBool.Clear();
            ObjectPool.Instance.AddObject(_OPResearchPlaneCount, BuyPlane.Instance.ResearchPlanes[BuyPlane.Instance.ResearchPlanes.Count - planeLimit - 1].gameObject);
            researchHidePlaneCount++;
            GameManager.Instance.SetResearchHidePlaneCount();
            StartCoroutine(HideResearchAdded());
        }
    }

    public IEnumerator HideMoneyAdded()
    {
        while (true)
        {
            if (moneyHidePlaneCount > 0 && GameManager.Instance.contractBool)
            {
                for (int i1 = 0; i1 < MyDoPath.Instance.runnerCount; i1++)
                {
                    for (int i = 0; i < moneyHidePlaneCount; i++)
                    {
                        GameManager.Instance.contractCount--;
                        if (GameManager.Instance.contractCount < 0)
                            GameManager.Instance.contractCount = 0;
                        GameManager.Instance.SetContractCount();
                    }
                    yield return new WaitForSeconds(_moneyRespawnTime);
                }
            }
            else
            {
                yield return null;
            }
        }
    }

    public IEnumerator HideResearchAdded()
    {
        while (true)
        {
            if (researchHidePlaneCount > 0)
            {
                for (int i1 = 0; i1 < 6; i1++)
                {
                    for (int i = 0; i < researchHidePlaneCount; i++)
                    {
                        MoneySystem.Instance.ResearchTextRevork(6 * (int)ItemData.Instance.field.addedResearchPoint);
                        CounterSystem.Instance.CounterPlus((int)ItemData.Instance.field.addedMoney);
                    }
                    yield return new WaitForSeconds(_researchRespawnTime);
                }
            }
            else
            {
                yield return null;
            }
        }
    }
}
