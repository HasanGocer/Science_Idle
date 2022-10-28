using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MyDoPath : MonoSingleton<MyDoPath>
{
    [System.Serializable]
    public struct Balls
    {
        public float length;
        public List<GameObject> BallsGO;
        public Vector3[] BallsV3;
    }
    public Balls Ball;
    public Balls[] BallTower;

    public int runnerCount;
    public float runnerTime;

    public void PlanePlacement()
    {
        BallTower = new Balls[ItemData.Instance.field.moneyPlane];
        for (int i1 = 0; i1 < ItemData.Instance.field.moneyPlane; i1++)
        {
            BallTower[i1].length = 0;
            BallTower[i1].BallsV3 = new Vector3[Ball.BallsGO.Count + 1];
            for (int i2 = 0; i2 < Ball.BallsGO.Count - 1; i2++)
            {
                BallTower[i1].length += Vector3.Distance(Ball.BallsGO[i2].transform.position, Ball.BallsGO[i2 + 1].transform.position);
                BallTower[i1].BallsV3[i2] = new Vector3(Ball.BallsGO[i2].transform.position.x, Ball.BallsGO[i2].transform.position.y + BuyPlane.Instance.moneyPlaneDistance * ItemData.Instance.field.moneyPlane, Ball.BallsGO[i2].transform.position.z);
                if (i2 == Ball.BallsGO.Count - 2)
                {
                    BallTower[i1].BallsV3[i2 + 1] = new Vector3(Ball.BallsGO[i2 + 1].transform.position.x, Ball.BallsGO[i2 + 1].transform.position.y + BuyPlane.Instance.moneyPlaneDistance * ItemData.Instance.field.moneyPlane, Ball.BallsGO[i2 + 1].transform.position.z);
                    BallTower[i1].BallsV3[i2 + 2] = new Vector3(RunnerManager.Instance._runnerPos.transform.position.x, RunnerManager.Instance._runnerPos.transform.position.y + BuyPlane.Instance.moneyPlaneDistance * ItemData.Instance.field.moneyPlane, RunnerManager.Instance._runnerPos.transform.position.z);
                }
            }
            //BallTower[i1].length += Vector3.Distance(Ball.BallsGO[Ball.BallsV3.Length - 2].transform.position, RunnerManager.Instance._runnerPos.transform.position);
            //BallTower[i1].BallsV3[Ball.BallsV3.Length - 1] = RunnerManager.Instance._runnerPos.transform.position;
        }
    }

    //Kullanýlmýyor
    /*
    public void StartRun()
    {
        for (int i = 0; i < ItemData.Instance.field.runnerCount; i++)
        {
            GameObject obj = ObjectPool.Instance.GetPooledObject(RunnerManager.Instance._OPrunnerCount);
            RunnerManager.Instance.Runner.Add(obj);
            runnerTime = length[obj.GetComponent<PathSelection>().pathSelection] * ItemData.Instance.field.runnerSpeed;

            Vector3[] pos = new Vector3[Balls[obj.GetComponent<PathSelection>().pathSelection].Count];
            for (int i1 = 0; i1 < pos.Length; i1++)
            {
                pos[i1] = BallsWP[obj.GetComponent<PathSelection>().pathSelection, i1];
            }
            obj.transform.DOPath(pos, runnerTime, PathType.CatmullRom).SetEase(Ease.InOutSine).Loops();
        }
    }*/

    public void StartNewRunner(GameObject obj, bool downPlane)
    {
        if (downPlane)
        {
            runnerTime = Ball.length * (MyDoPath.Instance.runnerCount);
            obj.transform.DOPath(Ball.BallsV3, runnerTime, PathType.CatmullRom, PathMode.Full3D, 20, Color.black).SetEase(Ease.Linear).SetLoops(1000);
        }
        else
        {
            runnerTime = Ball.length * (ItemData.Instance.field.runnerSpeed % MyDoPath.Instance.runnerCount);
            obj.transform.DOPath(Ball.BallsV3, runnerTime, PathType.CatmullRom, PathMode.Full3D, 20, Color.black).SetEase(Ease.Linear).SetLoops(1000);
        }
    }

    public void AddedNewWay()
    {
        BallTower = new Balls[ItemData.Instance.field.moneyPlane + 1];
        BallTower[ItemData.Instance.field.moneyPlane].length = 0;
        BallTower[ItemData.Instance.field.moneyPlane].BallsV3 = new Vector3[Ball.BallsGO.Count + 1];
        for (int i2 = 0; i2 < Ball.BallsGO.Count - 1; i2++)
        {
            BallTower[ItemData.Instance.field.moneyPlane].length += Vector3.Distance(Ball.BallsGO[i2].transform.position, Ball.BallsGO[i2 + 1].transform.position);
            BallTower[ItemData.Instance.field.moneyPlane].BallsV3[i2] = new Vector3(Ball.BallsGO[i2].transform.position.x, Ball.BallsGO[i2].transform.position.y + BuyPlane.Instance.moneyPlaneDistance * ItemData.Instance.field.moneyPlane, Ball.BallsGO[i2].transform.position.z);
            if (i2 == Ball.BallsGO.Count - 2)
                BallTower[ItemData.Instance.field.moneyPlane].BallsV3[i2 + 1] = Ball.BallsGO[i2 + 1].transform.position;
        }
        BallTower[ItemData.Instance.field.moneyPlane].length += Vector3.Distance(Ball.BallsGO[Ball.BallsV3.Length - 2].transform.position, RunnerManager.Instance._runnerPos.transform.position);
        BallTower[ItemData.Instance.field.moneyPlane].BallsV3[Ball.BallsV3.Length - 1] = RunnerManager.Instance._runnerPos.transform.position;
        ItemData.Instance.factor.moneyPlane++;
        GameManager.Instance.SetMoneyPlane();
    }
}
