using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    //oyunun tüm prefeblerinin ve oyunun hangi safhasýnda olduðu deðeri burada dönülür


    public int money;
    public int researchPoint;
    public int counterPoint;
    public int contractType, contractMaxCount, contractCount;
    public int vibration;
    public int sound;

    public bool contractBool;


    private void Start()
    {
        GameObject.FindObjectOfType<AdManager>().InitializeAds();
    }
    public void AwakeOP()
    {
        
        if (PlayerPrefs.HasKey("researchPoint"))
        {
            researchPoint = PlayerPrefs.GetInt("researchPoint");
        }
        else
        {
            PlayerPrefs.SetInt("researchPoint", 35);
            researchPoint = PlayerPrefs.GetInt("researchPoint");
        }
        MoneySystem.Instance.ResearchTextRevork(0);

        if (PlayerPrefs.HasKey("money"))
        {
            money = PlayerPrefs.GetInt("money");
        }
        else
        {
            PlayerPrefs.SetInt("money", 35);
            money = PlayerPrefs.GetInt("money");
        }
        MoneySystem.Instance.MoneyTextRevork(0);

        if (PlayerPrefs.HasKey("contractType"))
        {
            contractType = PlayerPrefs.GetInt("contractType");
        }
        else
        {
            PlayerPrefs.SetInt("contractType", 0);
        }

        if (PlayerPrefs.HasKey("contractMaxCount"))
        {
            contractMaxCount = PlayerPrefs.GetInt("contractMaxCount");
        }
        else
        {
            PlayerPrefs.SetInt("contractMaxCount", 0);
        }

        if (PlayerPrefs.HasKey("contractCount"))
        {
            contractCount = PlayerPrefs.GetInt("contractCount");
        }
        else
        {
            PlayerPrefs.SetInt("contractCount", 0);
        }

        if (PlayerPrefs.HasKey("counterPoint"))
        {
            counterPoint = PlayerPrefs.GetInt("counterPoint");
        }
        else
        {
            PlayerPrefs.SetInt("counterPoint", 0);
            counterPoint = PlayerPrefs.GetInt("counterPoint");
        }
        Buttons.Instance.counterPointText.text = counterPoint.ToString();

        if (PlayerPrefs.HasKey("contractBool"))
        {
            if (PlayerPrefs.GetInt("contractBool") == 1)
                contractBool = true;
            else
                contractBool = false;
        }
        else
        {
            PlayerPrefs.SetInt("contractBool", 0);
        }

        if (PlayerPrefs.HasKey("vibration"))
        {
            vibration = PlayerPrefs.GetInt("vibration");
        }
        else
        {
            PlayerPrefs.SetInt("vibration", 1);
        }

        if (PlayerPrefs.HasKey("sound"))
        {
            sound = PlayerPrefs.GetInt("sound");
        }
        else
        {
            PlayerPrefs.SetInt("sound", 1);
        }

        if (PlayerPrefs.HasKey("runnerCount"))
        {
            ItemData.Instance.factor.runnerCount = PlayerPrefs.GetInt("runnerCount");
        }
        else
        {
            PlayerPrefs.SetInt("runnerCount", 1);
        }

        if (PlayerPrefs.HasKey("bobinCount"))
        {
            ItemData.Instance.factor.bobinCount = PlayerPrefs.GetInt("bobinCount");
        }
        else
        {
            PlayerPrefs.SetInt("bobinCount", 1);
        }

        if (PlayerPrefs.HasKey("tableCount"))
        {
            ItemData.Instance.factor.tableCount = PlayerPrefs.GetInt("tableCount");
        }
        else
        {
            PlayerPrefs.SetInt("tableCount", 1);
        }

        if (PlayerPrefs.HasKey("moneyPlane"))
        {
            ItemData.Instance.factor.moneyPlane = PlayerPrefs.GetInt("moneyPlane");
        }
        else
        {
            PlayerPrefs.SetInt("moneyPlane", 1);
        }

        if (PlayerPrefs.HasKey("researchPlane"))
        {
            ItemData.Instance.factor.researchPlane = PlayerPrefs.GetInt("researchPlane");
        }
        else
        {
            PlayerPrefs.SetInt("researchPlane", 1);
        }

        if (PlayerPrefs.HasKey("moneyHidePlaneCount"))
        {
            PlaneHideSystem.Instance.moneyHidePlaneCount = PlayerPrefs.GetInt("moneyHidePlaneCount");
        }
        else
        {
            if (ItemData.Instance.factor.moneyPlane > PlaneHideSystem.Instance.planeLimit)
            {
                PlayerPrefs.SetInt("moneyHidePlaneCount", ItemData.Instance.factor.moneyPlane - PlaneHideSystem.Instance.planeLimit);
            }
            else
            {
                PlayerPrefs.SetInt("moneyHidePlaneCount", 0);
            }
        }

        if (PlayerPrefs.HasKey("researchHidePlaneCount"))
        {
            PlaneHideSystem.Instance.researchHidePlaneCount = PlayerPrefs.GetInt("researchHidePlaneCount");
        }
        else
        {
            if (ItemData.Instance.factor.researchPlane > PlaneHideSystem.Instance.planeLimit)
            {
                PlayerPrefs.SetInt("researchHidePlaneCount", ItemData.Instance.factor.researchPlane - PlaneHideSystem.Instance.planeLimit);
            }
            else
            {
                PlayerPrefs.SetInt("researchHidePlaneCount", 0);
            }
        }

        ItemData.Instance.ItemPlacement();
    }

    public void SetResearchPoint()
    {
        PlayerPrefs.SetInt("researchPoint", researchPoint);
    }

    public void SetMoney()
    {
        PlayerPrefs.SetInt("money", money);
    }

    public void SetContractType()
    {
        PlayerPrefs.SetInt("contractType", contractType);
    }

    public void SetContractMaxCount()
    {
        PlayerPrefs.SetInt("contractMaxCount", contractMaxCount);
    }

    public void SetContractBool()
    {
        if (contractBool == true)
            PlayerPrefs.SetInt("contractBool", 1);
        else
            PlayerPrefs.SetInt("contractBool", 0);
    }

    public void SetContractCount()
    {
        PlayerPrefs.SetInt("contractCount", contractCount);
        ContractSystem.Instance.counter.text = contractCount.ToString();
        ContractSystem.Instance.contractViewText.text = GameManager.Instance.contractCount.ToString();

        if (contractCount <= 0)
            ContractSystem.Instance.FinishContract();
    }

    public void SetCounterPoint()
    {
        PlayerPrefs.SetInt("counterPoint", counterPoint);
    }

    public void SetSound()
    {
        PlayerPrefs.SetInt("sound", sound);
    }

    public void SetVibration()
    {
        PlayerPrefs.SetInt("vibration", vibration);
    }

    public void SetRunnerCount()
    {
        PlayerPrefs.SetInt("runnerCount", ItemData.Instance.factor.runnerCount);
        ItemData.Instance.field.runnerCount = ItemData.Instance.standart.runnerCount + (ItemData.Instance.factor.runnerCount * ItemData.Instance.constant.runnerCount);
        ItemData.Instance.fieldPrice.runnerCount = ItemData.Instance.fieldPrice.runnerCount / (ItemData.Instance.factor.runnerCount - 1);
        ItemData.Instance.fieldPrice.runnerCount = ItemData.Instance.fieldPrice.runnerCount * ItemData.Instance.factor.runnerCount;
    }

    public void SetBobinCount()
    {
        PlayerPrefs.SetInt("bobinCount", ItemData.Instance.factor.bobinCount);
        ItemData.Instance.field.bobinCount = ItemData.Instance.standart.bobinCount + (ItemData.Instance.factor.bobinCount * ItemData.Instance.constant.bobinCount);
        ItemData.Instance.fieldPrice.bobinCount = ItemData.Instance.fieldPrice.bobinCount / (ItemData.Instance.factor.bobinCount - 1);
        ItemData.Instance.fieldPrice.bobinCount = ItemData.Instance.fieldPrice.bobinCount * ItemData.Instance.factor.bobinCount;
    }

    public void SetTableCount()
    {
        PlayerPrefs.SetInt("tableCount", ItemData.Instance.factor.tableCount);
        ItemData.Instance.field.tableCount = ItemData.Instance.standart.tableCount + (ItemData.Instance.factor.tableCount * ItemData.Instance.constant.tableCount);
        ItemData.Instance.fieldPrice.tableCount = ItemData.Instance.fieldPrice.tableCount / (ItemData.Instance.factor.tableCount - 1);
        ItemData.Instance.fieldPrice.tableCount = ItemData.Instance.fieldPrice.tableCount * ItemData.Instance.factor.tableCount;
    }

    public void SetMoneyPlane()
    {
        PlayerPrefs.SetInt("moneyPlane", ItemData.Instance.factor.moneyPlane);
        ItemData.Instance.field.moneyPlane = ItemData.Instance.standart.moneyPlane + (ItemData.Instance.factor.moneyPlane * ItemData.Instance.constant.moneyPlane);
        ItemData.Instance.fieldPrice.moneyPlane = ItemData.Instance.fieldPrice.moneyPlane / (ItemData.Instance.factor.moneyPlane - 1);
        ItemData.Instance.fieldPrice.moneyPlane = ItemData.Instance.fieldPrice.moneyPlane * ItemData.Instance.factor.moneyPlane;
    }

    public void SetResearchPlane()
    {
        PlayerPrefs.SetInt("researchPlane", ItemData.Instance.factor.researchPlane);
        ItemData.Instance.field.researchPlane = ItemData.Instance.standart.researchPlane + (ItemData.Instance.factor.researchPlane * ItemData.Instance.constant.researchPlane);
        ItemData.Instance.fieldPrice.researchPlane = ItemData.Instance.fieldPrice.researchPlane / (ItemData.Instance.factor.researchPlane - 1);
        ItemData.Instance.fieldPrice.researchPlane = ItemData.Instance.fieldPrice.researchPlane * ItemData.Instance.factor.researchPlane;
    }

    public void SetMoneyHidePlaneCount()
    {
        PlayerPrefs.SetInt("moneyHidePlaneCount", ItemData.Instance.factor.moneyPlane - PlaneHideSystem.Instance.planeLimit);
    }

    public void SetResearchHidePlaneCount()
    {
        PlayerPrefs.SetInt("researchHidePlaneCount", ItemData.Instance.factor.researchPlane - PlaneHideSystem.Instance.planeLimit);
    }
}
