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

    public void StartPlanePlacement()
    {
        for (int i1 = 0; i1 < ItemData.Instance.field.moneyPlane; i1++)
        {

            if (i1 != ItemData.Instance.field.moneyPlane - 1)
            {
                Debug.Log("1");
                GameObject obj = ObjectPool.Instance.GetPooledObject(OPMoneyPlaneCount);
                obj.transform.position = new Vector3(moneyPlaneTempaltePosition.transform.position.x, (moneyPlaneDistance * i1) + moneyPlaneTempaltePosition.transform.position.y, moneyPlaneTempaltePosition.transform.position.z);
                obj.GetComponent<MeshRenderer>().material = MoneyMaterials[i1];
                obj.GetComponent<BobinManager>().bobinCount = ItemData.Instance.field.bobinCount % MyDoPath.Instance.runnerCount + 1;
                obj.GetComponent<BobinManager>().PlaneFullBobinPlacemennt();
                MoneyPlanes.Add(obj);
            }
            else
            {
                GameObject obj = ObjectPool.Instance.GetPooledObject(OPMoneyPlaneCount);
                obj.transform.position = new Vector3(moneyPlaneTempaltePosition.transform.position.x, (moneyPlaneDistance * i1) + moneyPlaneTempaltePosition.transform.position.y, moneyPlaneTempaltePosition.transform.position.z);
                obj.GetComponent<MeshRenderer>().material = MoneyMaterials[i1];
                obj.GetComponent<BobinManager>().bobinCount = ItemData.Instance.field.bobinCount % MyDoPath.Instance.runnerCount;
                obj.GetComponent<BobinManager>().BobinPlacement();
                MoneyPlanes.Add(obj);
            }
        }

        for (int i1 = 0; i1 < ItemData.Instance.field.researchPlane; i1++)
        {
            GameObject obj = ObjectPool.Instance.GetPooledObject(OPResearchPlaneCount);
            obj.transform.position = new Vector3(researchPlaneTempaltePosition.transform.position.x, (researchPlaneDistance * i1) + researchPlaneTempaltePosition.transform.position.y, researchPlaneTempaltePosition.transform.position.z);
            obj.GetComponent<MeshRenderer>().material = ResearchMaterials[i1];
            obj.GetComponent<TableBuy>().TablePlacement();
            ResearchPlanes.Add(obj);
        }
    }

    public void AddNewMoneyPlane()
    {
        GameObject obj = ObjectPool.Instance.GetPooledObject(OPMoneyPlaneCount);
        obj.transform.position = new Vector3(moneyPlaneTempaltePosition.transform.position.x, moneyPlaneTempaltePosition.transform.position.y + moneyPlaneDistance, moneyPlaneTempaltePosition.transform.position.z);
        MyDoPath.Instance.AddedNewWay();
        obj.GetComponent<MeshRenderer>().material = MoneyMaterials[ItemData.Instance.field.moneyPlane];
        obj.GetComponent<BobinManager>().bobinCount = ItemData.Instance.field.bobinCount % MyDoPath.Instance.runnerCount + 1;
        MoneyPlanes.Add(obj);
        Buttons.Instance.moneyPlaneButton.gameObject.SetActive(false);
        Buttons.Instance.runnerSpeedButton.gameObject.SetActive(true);
        Buttons.Instance.bobinCountButton.gameObject.SetActive(true);
        Buttons.Instance.runnerAddedButton.gameObject.SetActive(true);
    }

    public void AddNewResearchPlane()
    {
        GameObject obj = ObjectPool.Instance.GetPooledObject(OPResearchPlaneCount);
        obj.transform.position = new Vector3(researchPlaneTempaltePosition.transform.position.x, researchPlaneTempaltePosition.transform.position.y + researchPlaneDistance, moneyPlaneTempaltePosition.transform.position.z);
        obj.GetComponent<MeshRenderer>().material = ResearchMaterials[ItemData.Instance.field.researchPlane];
        ItemData.Instance.factor.researchPlane++;
        GameManager.Instance.SetResearchPlane();
        ResearchPlanes.Add(obj);
        Buttons.Instance.researchPlaneButton.gameObject.SetActive(false);
        Buttons.Instance.tableAddedText.text = ItemData.Instance.field.tableCount.ToString();
        Buttons.Instance.tableAddedButton.gameObject.SetActive(true);
        Buttons.Instance.StartBarButton.gameObject.SetActive(true);
    }

    public void NewMoneyPlaneButton()
    {
        if (runnerCountMaxBool && runnerSpeedMaxBool && BobinCountMaxBool)
        {
            Buttons.Instance.moneyPlaneButton.gameObject.SetActive(true);
            Buttons.Instance.runnerSpeedText.text = ItemData.Instance.field.runnerSpeed.ToString();
            Buttons.Instance.runnerSpeedButton.gameObject.SetActive(false);
            Buttons.Instance.bobinCountText.text = ItemData.Instance.field.bobinCount.ToString();
            Buttons.Instance.bobinCountButton.gameObject.SetActive(false);
            Buttons.Instance.runnerAddedText.text = ItemData.Instance.field.runnerCount.ToString();
            Buttons.Instance.runnerAddedButton.gameObject.SetActive(false);
        }
    }
    public void NewResearchPlaneButton()
    {
        if (tableCountMaxBool)
        {
            Buttons.Instance.researchPlaneButton.gameObject.SetActive(true);
            Buttons.Instance.tableAddedButton.gameObject.SetActive(false);
            Buttons.Instance.StartBarButton.gameObject.SetActive(false);

        }
    }
}
