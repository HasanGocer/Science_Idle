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
        for (int i = 0; i < ItemData.Instance.field.runnerCount; i++)
        {
            GameObject obj = ObjectPool.Instance.GetPooledObject(_OPRunnerCount);
            obj.transform.position = _runnerPos.transform.position;
            obj.GetComponent<PathSelection>().pathSelection = 0;
            Runner.Add(obj);
            MyDoPath.Instance.StartNewRunner(obj);
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void NewStartRunner()
    {
        GameObject obj = ObjectPool.Instance.GetPooledObject(_OPRunnerCount);
        obj.transform.position = _runnerPos.transform.position;
        obj.GetComponent<PathSelection>().pathSelection = 0;
        Runner.Add(obj);
        MyDoPath.Instance.StartNewRunner(obj);
    }

    public void SpeedUp()
    {
        //Debug.Log("HG1");
        //DOTween.PauseAll();
        for (int i = 0; i < ItemData.Instance.field.runnerCount; i++)
        {
            Debug.Log("HG1");
            Runner[i].transform.DOTogglePause();
            Debug.Log("HG2");
            ObjectPool.Instance.AddObject(_OPRunnerCount, Runner[i]);
            Debug.Log("HG3");
            GameObject obj = ObjectPool.Instance.GetPooledObject(_OPRunnerCount);
            Debug.Log("HG4");
            obj.transform.position = _runnerPos.transform.position;
            Debug.Log("HG5");
            obj.GetComponent<PathSelection>().pathSelection = 0;
            Debug.Log("HG6");
            Runner[i] = obj;
            Debug.Log("HG7");
            MyDoPath.Instance.StartNewRunner(obj);
        }
    }
}
