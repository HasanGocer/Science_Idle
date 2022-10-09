using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerManager : MonoSingleton<RunnerManager>
{
    public int _OPRunnerCount;
    public GameObject _runnerPos;

    public List<GameObject> Runner = new List<GameObject>();

    public void StartRunner()
    {
        for (int i = 0; i < ItemData.Instance.field.runnerCount; i++)
        {
            GameObject obj = ObjectPool.Instance.GetPooledObject(_OPRunnerCount);
            obj.transform.position = _runnerPos.transform.position;
            obj.GetComponent<PathSelection>().pathSelection = 0;
             MyDoPath.Instance.StartNewRunner(obj);
        }
    }
}
