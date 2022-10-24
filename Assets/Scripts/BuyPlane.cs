using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyPlane : MonoSingleton<BuyPlane>
{
    public List<GameObject> MoneyPlanes = new List<GameObject>();
    public List<GameObject> ResearchPlanes = new List<GameObject>();
    [SerializeField] private List<Material> MoneyMaterials = new List<Material>();
    [SerializeField] private List<Material> ResearchMaterials = new List<Material>();
    [SerializeField] private GameObject moneyPlaneTempaltePosition, researchPlaneTempaltePosition;
    [SerializeField] private int OPMoneyPlaneCount, OPResearchPlaneCount;
    public int moneyPlaneDistance, researchPlaneDistance;
    public bool runnerCountMaxBool, runnerSpeedMaxBool, BobinCountMaxBool;
    public bool tableCountMaxBool;

    public int researchPlaneCount;

    public void StartPlanePlacement()
    {
        for (int i1 = 0; i1 < MyDoPath.Instance.Ways - 1; i1++)
        {
            GameObject obj = ObjectPool.Instance.GetPooledObject(OPMoneyPlaneCount);
            obj.transform.position = new Vector3(moneyPlaneTempaltePosition.transform.position.x, (moneyPlaneDistance * i1) + moneyPlaneTempaltePosition.transform.position.y, moneyPlaneTempaltePosition.transform.position.z);
            obj.GetComponent<MeshRenderer>().material = MoneyMaterials[MyDoPath.Instance.Ways];
            obj.GetComponent<BobinManager>().PlaneFullBobinPlacemennt();
            obj.GetComponent<BobinManager>().PlaneCount = i1;
            MoneyPlanes.Add(obj);
        }

        for (int i1 = 0; i1 < researchPlaneCount; i1++)
        {
            GameObject obj = ObjectPool.Instance.GetPooledObject(OPMoneyPlaneCount);
            obj.transform.position = new Vector3(moneyPlaneTempaltePosition.transform.position.x, (moneyPlaneDistance * i1) + moneyPlaneTempaltePosition.transform.position.y, moneyPlaneTempaltePosition.transform.position.z);
            obj.GetComponent<MeshRenderer>().material = MoneyMaterials[MyDoPath.Instance.Ways];
            obj.GetComponent<BobinManager>().PlaneFullBobinPlacemennt();
            obj.GetComponent<BobinManager>().PlaneCount = i1;
            MoneyPlanes.Add(obj);
        }
    }

    public void AddNewMoneyPlane()
    {
        GameObject obj = ObjectPool.Instance.GetPooledObject(OPMoneyPlaneCount);
        obj.transform.position = new Vector3(moneyPlaneTempaltePosition.transform.position.x, moneyPlaneTempaltePosition.transform.position.y + moneyPlaneDistance, moneyPlaneTempaltePosition.transform.position.z);
        MyDoPath.Instance.AddedNewWay();
        obj.GetComponent<MeshRenderer>().material = MoneyMaterials[MyDoPath.Instance.Ways];
        obj.GetComponent<BobinManager>().PlaneCount = MyDoPath.Instance.Ways;
        MoneyPlanes.Add(obj);
    }

    public void AddNewResearchPlane()
    {
        GameObject obj = ObjectPool.Instance.GetPooledObject(OPMoneyPlaneCount);
        obj.transform.position = new Vector3(researchPlaneTempaltePosition.transform.position.x, researchPlaneTempaltePosition.transform.position.y + researchPlaneDistance, moneyPlaneTempaltePosition.transform.position.z);
        obj.GetComponent<MeshRenderer>().material = ResearchMaterials[researchPlaneCount];
        ResearchPlanes.Add(obj);
    }
}
