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
    public bool runnerCountMaxBool, BobinCountMaxBool;
    public bool tableCountMaxBool;

    public void StartPlanePlacement()
    {
        for (int i1 = 0; i1 < ItemData.Instance.field.moneyPlane; i1++)
        {
            GameObject obj = ObjectPool.Instance.GetPooledObject(OPMoneyPlaneCount);
            obj.transform.position = new Vector3(moneyPlaneTempaltePosition.transform.position.x, (moneyPlaneDistance * i1) + moneyPlaneTempaltePosition.transform.position.y, moneyPlaneTempaltePosition.transform.position.z);
            obj.GetComponent<MeshRenderer>().material = MoneyMaterials[i1];

            if (i1 != ItemData.Instance.field.moneyPlane - 1)
            {
                obj.GetComponent<BobinManager>().bobinCount = MyDoPath.Instance.runnerCount;
                obj.GetComponent<BobinManager>().PlaneFullBobinPlacemennt();
            }
            else
            {
                obj.GetComponent<BobinManager>().bobinCount = ItemData.Instance.field.bobinCount % MyDoPath.Instance.runnerCount;
                obj.GetComponent<BobinManager>().BobinPlacement();
            }
            obj.GetComponent<BobinManager>().PlaneCount = i1;
            MoneyPlanes.Add(obj);
        }

        for (int i1 = 0; i1 < ItemData.Instance.field.researchPlane; i1++)
        {
            GameObject obj = ObjectPool.Instance.GetPooledObject(OPResearchPlaneCount);
            obj.transform.position = new Vector3(researchPlaneTempaltePosition.transform.position.x, (researchPlaneDistance * i1) + researchPlaneTempaltePosition.transform.position.y, researchPlaneTempaltePosition.transform.position.z);
            obj.GetComponent<MeshRenderer>().material = ResearchMaterials[i1];
            if (i1 != ItemData.Instance.field.researchPlane - 1)
            {
                obj.GetComponent<TableBuy>().TableCount = MyDoPath.Instance.runnerCount;
            }
            else
            {
                obj.GetComponent<TableBuy>().TableCount = ItemData.Instance.field.bobinCount % MyDoPath.Instance.runnerCount;
            }
            obj.GetComponent<TableBuy>().TablePlacement();
            obj.GetComponent<TableBuy>().PlaneCount = i1;
            ResearchPlanes.Add(obj);
        }
    }

    public void AddNewMoneyPlane()
    {
        //bobin ve runner ver 1 adet
        GameObject obj = ObjectPool.Instance.GetPooledObject(OPMoneyPlaneCount);
        obj.transform.position = new Vector3(moneyPlaneTempaltePosition.transform.position.x, moneyPlaneTempaltePosition.transform.position.y + (moneyPlaneDistance * ItemData.Instance.field.moneyPlane), moneyPlaneTempaltePosition.transform.position.z);
        obj.GetComponent<BobinManager>().PlaneCount = ItemData.Instance.factor.moneyPlane;
        MyDoPath.Instance.AddedNewWay();
        obj.GetComponent<MeshRenderer>().material = MoneyMaterials[ItemData.Instance.field.moneyPlane];
        obj.GetComponent<BobinManager>().bobinCount = 1;
        obj.GetComponent<BobinManager>().BobinBuy();
        RunnerManager.Instance.NewStartRunner();
        MoneyPlanes.Add(obj);
        Buttons.Instance.bobinCountText.text = ItemData.Instance.fieldPrice.bobinCount.ToString();
        Buttons.Instance.runnerAddedText.text = ItemData.Instance.fieldPrice.runnerCount.ToString();
        Buttons.Instance.moneyPlaneButton.gameObject.SetActive(false);
        Buttons.Instance.bobinCountButton.gameObject.SetActive(true);
        Buttons.Instance.bobinCountButton.enabled = true;
        BuyPlane.Instance.BobinCountMaxBool = false;
        Buttons.Instance.runnerAddedButton.gameObject.SetActive(true);
        Buttons.Instance.runnerAddedButton.enabled = true;
        BuyPlane.Instance.runnerCountMaxBool = false;
    }

    public void AddNewResearchPlane()
    {
        GameObject obj = ObjectPool.Instance.GetPooledObject(OPResearchPlaneCount);
        obj.transform.position = new Vector3(researchPlaneTempaltePosition.transform.position.x, researchPlaneTempaltePosition.transform.position.y + (researchPlaneDistance * ItemData.Instance.field.researchPlane), researchPlaneTempaltePosition.transform.position.z);
        obj.GetComponent<MeshRenderer>().material = ResearchMaterials[ItemData.Instance.field.researchPlane];
        obj.GetComponent<TableBuy>().TableBuyWithButton();
        ItemData.Instance.factor.researchPlane++;
        GameManager.Instance.SetResearchPlane();
        obj.GetComponent<TableBuy>().TableCount = 1;
        ResearchPlanes.Add(obj);
        Buttons.Instance.tableAddedText.text = ItemData.Instance.fieldPrice.tableCount.ToString();
        Buttons.Instance.researchPlaneButton.gameObject.SetActive(false);
        Buttons.Instance.tableAddedButton.gameObject.SetActive(true);
        Buttons.Instance.tableAddedButton.enabled = true;
        Buttons.Instance.StartBarButton.gameObject.SetActive(true);
        Buttons.Instance.StartBarButton.enabled = true;
        BuyPlane.Instance.tableCountMaxBool = false;
    }

    public void NewMoneyPlaneButton()
    {
        if (runnerCountMaxBool && BobinCountMaxBool)
        {
            Buttons.Instance.moneyPlaneText.text = ItemData.Instance.fieldPrice.moneyPlane.ToString();
            Buttons.Instance.moneyPlaneButton.gameObject.SetActive(true);
            Buttons.Instance.bobinCountButton.gameObject.SetActive(false);
            Buttons.Instance.runnerAddedButton.gameObject.SetActive(false);
        }
    }
    public void NewResearchPlaneButton()
    {
        if (tableCountMaxBool)
        {
            Buttons.Instance.tableAddedButton.gameObject.SetActive(false);
            Buttons.Instance.StartBarButton.gameObject.SetActive(false);
            Buttons.Instance.researchPlaneButton.gameObject.SetActive(true);
        }
    }
}
