using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContractSystem : MonoSingleton<ContractSystem>
{
    [System.Serializable]
    public class Contract
    {
        public int contractTypeCount, contractCount;
    }
    public Contract[] newContract;

    public List<Sprite> contractImageTemplate = new List<Sprite>();

    public List<Image> contractImage = new List<Image>();
    public List<Button> contractButton = new List<Button>();
    public List<Text> contractText = new List<Text>();

    [SerializeField] private int _countFactor, _contractLimit, _budgetFactor;
    public Text counter;
    [SerializeField] private GameObject _contractPanel, _contractViewPanel, _finishContractPanel;
    [SerializeField] private Image contractViewImage;
    public Text contractViewText;
    [SerializeField] bool handStop;
    [SerializeField] private Text finishCountText;
    [SerializeField] Button addFinishButton, freeFinishButton;

    [SerializeField] private Image hand;

    public Button openContractButton, closeContractButton;

    public void ContractSystemStart()
    {
        openContractButton.onClick.AddListener(() => ContractPanelOpen());
        closeContractButton.onClick.AddListener(() => CloseContractPanel());
        contractButton[0].onClick.AddListener(() => ContractSelect(0));
        contractButton[1].onClick.AddListener(() => ContractSelect(1));
        contractButton[2].onClick.AddListener(() => ContractSelect(2));
        contractButton[3].onClick.AddListener(() => ContractSelect(3));
        contractButton[4].onClick.AddListener(() => ContractSelect(4));
        addFinishButton.onClick.AddListener(TouchBar);
        freeFinishButton.onClick.AddListener(FreeFinish);
    }

    public void FinishContract()
    {
        _finishContractPanel.SetActive(true);
        GameManager.Instance.contractBool = false;
        finishCountText.text = (GameManager.Instance.contractMaxCount * _budgetFactor).ToString();
        StartCoroutine(BarStart(-300, 300));
    }

    public void ContractPanelOpen()
    {
        if (!GameManager.Instance.contractBool)
        {
            _contractPanel.SetActive(true);
            NewContractView();
        }
        else
        {
            _contractViewPanel.SetActive(true);
        }
    }

    public void CloseContractPanel()
    {
        _contractViewPanel.SetActive(false);
    }

    public Contract NewContractSelect()
    {
        Contract contract = new Contract();

        int randomContractTypeCount = Random.Range(1, contractImageTemplate.Count);
        int randomContractConut = Random.Range(1, ItemData.Instance.field.tableCount * _countFactor);
        contract.contractTypeCount = randomContractTypeCount;
        contract.contractCount = randomContractConut;
        return contract;
    }

    public IEnumerator BarStart(int firstPos, int lastPos)
    {
        int factor = 1;
        while (true)
        {
            if (handStop)
            {
                factor = 2;
                StopBar(factor);
                break;
            }
            yield return new WaitForSeconds(0.3f);
            if (handStop)
            {
                factor = 3;
                StopBar(factor);
                break;
            }
            yield return new WaitForSeconds(0.4f);
            if (handStop)
            {
                factor = 2;
                StopBar(factor);
                break;
            }
            yield return new WaitForSeconds(0.3f);
        }
    }

    public void TouchBar()
    {
        handStop = true;
    }

    public void StopBar(int count)
    {
        MoneySystem.Instance.MoneyTextRevork(GameManager.Instance.contractMaxCount * _budgetFactor * count);
        _finishContractPanel.SetActive(false);
        handStop = false;
    }

    public void FreeFinish()
    {
        MoneySystem.Instance.MoneyTextRevork(GameManager.Instance.contractMaxCount * _budgetFactor);
        _finishContractPanel.SetActive(false);
    }


    public void NewContractView()
    {
        Time.timeScale = 0;
        newContract = new Contract[_contractLimit];

        for (int i = 0; i < _contractLimit; i++)
        {
            newContract[i] = NewContractSelect();
            contractText[i].text = newContract[i].contractCount.ToString();
            contractImage[i].sprite = contractImageTemplate[newContract[i].contractTypeCount];
        }
    }


    public void ContractSelect(int count)
    {
        GameManager.Instance.contractCount = newContract[count].contractCount;
        GameManager.Instance.SetContractCount();
        GameManager.Instance.contractMaxCount = newContract[count].contractCount;
        GameManager.Instance.SetContractMaxCount();
        GameManager.Instance.contractType = newContract[count].contractTypeCount;
        GameManager.Instance.SetContractType();
        Time.timeScale = 1;
        _contractPanel.SetActive(false);
        counter.text = GameManager.Instance.contractCount.ToString();
        contractViewText.text = GameManager.Instance.contractCount.ToString();
        GameManager.Instance.contractBool = true;
        contractViewImage.sprite = contractImageTemplate[newContract[count].contractTypeCount];
        contractViewText.text = GameManager.Instance.contractCount.ToString();
    }
}
