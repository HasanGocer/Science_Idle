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
                obj.transform.position = _runnerPos.transform.position;
                obj.GetComponent<PathSelection>().pathSelection = i1;
                Runner.Add(obj);
                MyDoPath.Instance.StartNewRunner(obj, true);
                yield return new WaitForSeconds(0.3f);
            }
        }
        if (ItemData.Instance.field.runnerCount % MyDoPath.Instance.runnerCount != 0)
        {
            for (int i = 0; i < ItemData.Instance.field.runnerCount % MyDoPath.Instance.runnerCount; i++)
            {
                GameObject obj = ObjectPool.Instance.GetPooledObject(_OPRunnerCount);
                obj.transform.position = _runnerPos.transform.position;
                obj.GetComponent<PathSelection>().pathSelection = MyDoPath.Instance.Ways;
                Runner.Add(obj);
                MyDoPath.Instance.StartNewRunner(obj, false);
                yield return new WaitForSeconds(0.3f);
            }
        }
    }

    public void NewStartRunner()
    {
        if (ItemData.Instance.maxFactor.runnerCount >= ItemData.Instance.factor.runnerCount)
        {

            GameObject obj = ObjectPool.Instance.GetPooledObject(_OPRunnerCount);
            obj.transform.position = _runnerPos.transform.position;
            obj.GetComponent<PathSelection>().pathSelection = MyDoPath.Instance.Ways;
            ItemData.Instance.factor.runnerCount++;
            Runner.Add(obj);
            MyDoPath.Instance.StartNewRunner(obj, false);
            if (ItemData.Instance.factor.runnerCount == ItemData.Instance.maxFactor.runnerCount)
            {
                ItemData.Instance.maxFactor.runnerCount += MyDoPath.Instance.runnerCount;
                //max runner text
                GameManager.Instance.SetRunnerCount();
                ItemData.Instance.RunnerCount();
                Buttons.Instance.runnerAddedText.text = ItemData.Instance.fieldPrice.runnerCount.ToString();
                BuyPlane.Instance.runnerCountMaxBool = true;
            }
        }

    }

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
                obj.GetComponent<PathSelection>().pathSelection = MyDoPath.Instance.Ways;
                Runner[((ItemData.Instance.field.runnerCount / MyDoPath.Instance.runnerCount) * MyDoPath.Instance.runnerCount) + i] = obj;
                MyDoPath.Instance.StartNewRunner(obj, false);
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
        }
    }
}
