using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RunnerManager : MonoSingleton<RunnerManager>
{
    public int _OPRunnerCount;
    public GameObject _runnerPos;

    public List<GameObject> Runner = new List<GameObject>();

    public IEnumerator StartRunner()
    {
        for (int i1 = 0; i1 < ItemData.Instance.field.runnerCount / MyDoPath.Instance.runnerCount; i1++)
        {
            for (int i2 = 0; i2 < MyDoPath.Instance.runnerCount; i2++)
            {
                GameObject obj = ObjectPool.Instance.GetPooledObject(_OPRunnerCount);
                obj.transform.position = new Vector3(_runnerPos.transform.position.x, _runnerPos.transform.position.y + (BuyPlane.Instance.moneyPlaneDistance * (i1)), _runnerPos.transform.position.z);
                Runner.Add(obj);
                MyDoPath.Instance.StartNewRunner(obj, true, i1);
                yield return new WaitForSeconds(0.3f);
            }
        }

        int runnerLimit = 0;
        if (ItemData.Instance.field.runnerCount % MyDoPath.Instance.runnerCount != 0)
        {
            runnerLimit = ItemData.Instance.field.runnerCount % MyDoPath.Instance.runnerCount;
        }
        else
        {
            runnerLimit = MyDoPath.Instance.runnerCount;
        }

        for (int i = 0; i < runnerLimit; i++)
        {
            GameObject obj = ObjectPool.Instance.GetPooledObject(_OPRunnerCount);
            obj.transform.position = new Vector3(_runnerPos.transform.position.x, _runnerPos.transform.position.y + (BuyPlane.Instance.moneyPlaneDistance * (ItemData.Instance.field.moneyPlane - 1)), _runnerPos.transform.position.z);
            Runner.Add(obj);
            if (runnerLimit == MyDoPath.Instance.runnerCount)
            {
                MyDoPath.Instance.StartNewRunner(obj, true, (ItemData.Instance.field.runnerCount / MyDoPath.Instance.runnerCount) - 1);
            }
            else
            {
                MyDoPath.Instance.StartNewRunner(obj, false, ItemData.Instance.field.runnerCount / MyDoPath.Instance.runnerCount);
            }
            yield return new WaitForSeconds(0.3f);
        }
    }

    public void NewStartRunner()
    {
        if (ItemData.Instance.maxFactor.runnerCount >= ItemData.Instance.factor.runnerCount)
        {

            GameObject obj = ObjectPool.Instance.GetPooledObject(_OPRunnerCount);
            obj.transform.position = new Vector3(_runnerPos.transform.position.x, _runnerPos.transform.position.y + (BuyPlane.Instance.moneyPlaneDistance * (ItemData.Instance.field.moneyPlane - 1)), _runnerPos.transform.position.z);
            ItemData.Instance.factor.runnerCount++;
            GameManager.Instance.SetRunnerCount();
            ItemData.Instance.RunnerCount();
            Buttons.Instance.bobinCountText.text = ItemData.Instance.fieldPrice.bobinCount.ToString();
            Runner.Add(obj);
            if (ItemData.Instance.field.runnerCount % MyDoPath.Instance.runnerCount != 0)
            {
                MyDoPath.Instance.StartNewRunner(obj, false, ItemData.Instance.field.runnerCount / MyDoPath.Instance.runnerCount);
            }
            else
            {
                MyDoPath.Instance.StartNewRunner(obj, false, (ItemData.Instance.field.runnerCount / MyDoPath.Instance.runnerCount) - 1);
            }
            if (ItemData.Instance.factor.runnerCount == ItemData.Instance.maxFactor.runnerCount)
            {
                ItemData.Instance.maxFactor.runnerCount += MyDoPath.Instance.runnerCount;
                Buttons.Instance.runnerAddedText.text = "Full";
                Buttons.Instance.runnerAddedButton.enabled = false;
                BuyPlane.Instance.runnerCountMaxBool = true;
                BuyPlane.Instance.NewMoneyPlaneButton();
            }
        }

    }
    //kullanýlmýyor
    /*
    public IEnumerator SpeedUp()
    {
        if (ItemData.Instance.field.runnerCount % MyDoPath.Instance.runnerCount != 0)
        {
            for (int i = 0; i < ItemData.Instance.field.runnerCount % MyDoPath.Instance.runnerCount; i++)
            {
                ObjectPool.Instance.AddObject(_OPRunnerCount, Runner[((ItemData.Instance.field.runnerCount / MyDoPath.Instance.runnerCount) * MyDoPath.Instance.runnerCount) + i]);
                Runner[((ItemData.Instance.field.runnerCount / MyDoPath.Instance.runnerCount) * MyDoPath.Instance.runnerCount) + i].transform.DOPause();
                GameObject obj = ObjectPool.Instance.GetPooledObject(_OPRunnerCount);
                obj.transform.position = _runnerPos.transform.position;
                Runner[((ItemData.Instance.field.runnerCount / MyDoPath.Instance.runnerCount) * MyDoPath.Instance.runnerCount) + i] = obj;
                MyDoPath.Instance.StartNewRunner(obj, false, ItemData.Instance.field.runnerCount / MyDoPath.Instance.runnerCount);
                yield return new WaitForSeconds(0.3f);
            }
            ItemData.Instance.factor.runnerSpeed++;

        }
        if (ItemData.Instance.maxFactor.runnerSpeed == ItemData.Instance.factor.runnerSpeed)
        {
            ItemData.Instance.maxFactor.runnerCount += MyDoPath.Instance.runnerCount;
            //max text aç

            GameManager.Instance.SetRunnerSpeed();
            ItemData.Instance.RunnerSpeed();
            Buttons.Instance.runnerSpeedText.text = ItemData.Instance.fieldPrice.runnerSpeed.ToString();
            BuyPlane.Instance.runnerSpeedMaxBool = true;
            BuyPlane.Instance.NewMoneyPlaneButton();
        }
    }
    */
}
