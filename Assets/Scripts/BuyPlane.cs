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
    [SerializeField] private float particalSeenTime;
    [SerializeField] private int OPPlaneParticalCount;
    [SerializeField] private float planeParticalDisctance;

    public void StartPlanePlacement()
    {
        int moneyLimit = 0;

        if (PlaneHideSystem.Instance.moneyHidePlaneCount > 0)
        {
            moneyLimit = ItemData.Instance.field.moneyPlane - PlaneHideSystem.Instance.planeLimit;
            StartCoroutine(PlaneHideSystem.Instance.HideMoneyAdded());
        }
        else
        {
            moneyLimit = 0;
        }

        int researchLimit = 0;

        if (PlaneHideSystem.Instance.researchHidePlaneCount > 0)
        {
            researchLimit = ItemData.Instance.field.researchPlane - PlaneHideSystem.Instance.planeLimit;
            StartCoroutine(PlaneHideSystem.Instance.HideResearchAdded());
        }
        else
        {
            researchLimit = 0;
        }

        for (int i1 = moneyLimit; i1 < ItemData.Instance.field.moneyPlane; i1++)
        {
            GameObject obj = ObjectPool.Instance.GetPooledObject(OPMoneyPlaneCount);
            obj.transform.position = new Vector3(moneyPlaneTempaltePosition.transform.position.x, (moneyPlaneDistance * i1) + moneyPlaneTempaltePosition.transform.position.y, moneyPlaneTempaltePosition.transform.position.z);
            if (MoneyMaterials.Count < i1)
            {
                obj.GetComponent<MeshRenderer>().material = MoneyMaterials[MoneyMaterials.Count % i1];
            }
            else
            {
                obj.GetComponent<MeshRenderer>().material = MoneyMaterials[i1];
            }

            //StartCoroutine(Partical(obj));

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
            PlaneHideSystem.Instance.MoneyPlaneHide();
            if (MoneyPlanes.Count > PlaneHideSystem.Instance.planeLimit)
                MoneyPlanes.RemoveAt(0);
        }

        for (int i1 = researchLimit; i1 < ItemData.Instance.field.researchPlane; i1++)
        {
            GameObject obj = ObjectPool.Instance.GetPooledObject(OPResearchPlaneCount);
            obj.transform.position = new Vector3(researchPlaneTempaltePosition.transform.position.x, (researchPlaneDistance * i1) + researchPlaneTempaltePosition.transform.position.y, researchPlaneTempaltePosition.transform.position.z);

            if (ResearchMaterials.Count < i1)
            {
                obj.GetComponent<MeshRenderer>().material = ResearchMaterials[ResearchMaterials.Count % i1];
            }
            else
            {
                obj.GetComponent<MeshRenderer>().material = ResearchMaterials[i1];
            }
            //StartCoroutine(Partical(obj));

            if (i1 != ItemData.Instance.field.researchPlane - 1)
            {
                obj.GetComponent<TableBuy>().TableCount = obj.GetComponent<TableBuy>().TableTemplateCount;
            }
            else
            {
                obj.GetComponent<TableBuy>().TableCount = ItemData.Instance.field.tableCount % obj.GetComponent<TableBuy>().TableTemplateCount;
            }
            obj.GetComponent<TableBuy>().TablePlacement();
            obj.GetComponent<TableBuy>().PlaneCount = i1;
            ResearchPlanes.Add(obj);
            PlaneHideSystem.Instance.ResearchPlaneHide();
            if (ResearchPlanes.Count > PlaneHideSystem.Instance.planeLimit)
                ResearchPlanes.RemoveAt(0);
        }
    }

    public void AddNewMoneyPlane()
    {
        MoneySystem.Instance.MoneyTextRevork(ItemData.Instance.fieldPrice.moneyPlane * -1);
        GameObject obj = ObjectPool.Instance.GetPooledObject(OPMoneyPlaneCount);
        obj.transform.position = new Vector3(moneyPlaneTempaltePosition.transform.position.x, moneyPlaneTempaltePosition.transform.position.y + (moneyPlaneDistance * ItemData.Instance.field.moneyPlane), moneyPlaneTempaltePosition.transform.position.z);
        obj.GetComponent<BobinManager>().PlaneCount = ItemData.Instance.factor.moneyPlane;
        MyDoPath.Instance.AddedNewWay();
        obj.GetComponent<MeshRenderer>().material = MoneyMaterials[ItemData.Instance.field.moneyPlane];
        obj.GetComponent<BobinManager>().bobinCount = 1;
        obj.GetComponent<BobinManager>().BobinBuy();
        RunnerManager.Instance.NewStartRunner();
        MoveCamera.Instance.MoneyCameraNewPos();
        StartCoroutine(Partical(obj));
        MoneyPlanes.Add(obj);
        PlaneHideSystem.Instance.MoneyPlaneHide();
        if (MoneyPlanes.Count > PlaneHideSystem.Instance.planeLimit)
            MoneyPlanes.RemoveAt(0);

        Buttons.Instance.bobinCountText.text = ItemData.Instance.fieldPrice.bobinCount.ToString();
        Buttons.Instance.runnerAddedText.text = ItemData.Instance.fieldPrice.runnerCount.ToString();
        Buttons.Instance.moneyPlaneText.text = ItemData.Instance.fieldPrice.moneyPlane.ToString();
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
        MoneySystem.Instance.ResearchTextRevork(ItemData.Instance.fieldPrice.researchPlane * -1);
        GameObject obj = ObjectPool.Instance.GetPooledObject(OPResearchPlaneCount);
        obj.transform.position = new Vector3(researchPlaneTempaltePosition.transform.position.x, researchPlaneTempaltePosition.transform.position.y + (researchPlaneDistance * ItemData.Instance.field.researchPlane), researchPlaneTempaltePosition.transform.position.z);
        obj.GetComponent<MeshRenderer>().material = ResearchMaterials[ItemData.Instance.field.researchPlane];
        ItemData.Instance.factor.researchPlane++;
        GameManager.Instance.SetResearchPlane();
        MoveCamera.Instance.ResearchCameraNewPos();
        obj.GetComponent<TableBuy>().TableCount = 1;
        StartCoroutine(Partical(obj));
        ResearchPlanes.Add(obj);
        PlaneHideSystem.Instance.ResearchPlaneHide();
        if (ResearchPlanes.Count > PlaneHideSystem.Instance.planeLimit)
            ResearchPlanes.RemoveAt(0);
        obj.GetComponent<TableBuy>().TableBuyWithButton();
        Buttons.Instance.tableAddedText.text = ItemData.Instance.fieldPrice.tableCount.ToString();
        Buttons.Instance.researchPlaneText.text = ItemData.Instance.fieldPrice.researchPlane.ToString();
        Buttons.Instance.researchPlaneButton.gameObject.SetActive(false);
        Buttons.Instance.tableAddedButton.gameObject.SetActive(true);
        Buttons.Instance.tableAddedButton.enabled = true;
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
            Buttons.Instance.researchPlaneButton.gameObject.SetActive(true);
        }
    }

    IEnumerator Partical(GameObject pos)
    {
        GameObject partical = ObjectPool.Instance.GetPooledObject(OPPlaneParticalCount);
        partical.transform.position = new Vector3(pos.transform.position.x, pos.transform.position.y + planeParticalDisctance, pos.transform.position.z);
        yield return new WaitForSeconds(particalSeenTime);
        ObjectPool.Instance.AddObject(OPPlaneParticalCount, partical);
    }
}
