using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    //oyunun t�m prefeblerinin ve oyunun hangi safhas�nda oldu�u de�eri burada d�n�l�r


    public int money;
    public int researchPoint;
    public int vibration;
    public int sound;

    private void Start()
    {
        if (PlayerPrefs.HasKey("researchPoint"))
        {
            researchPoint = PlayerPrefs.GetInt("researchPoint");
        }
        else
        {
            PlayerPrefs.SetInt("researchPoint", 1000);
        }
        Buttons.Instance.ResearchPointText.text = researchPoint.ToString();


        if (PlayerPrefs.HasKey("money"))
        {
            money = PlayerPrefs.GetInt("money");
        }
        else
        {
            PlayerPrefs.SetInt("money", 1000);
        }
        Buttons.Instance.moneyText.text = money.ToString();

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
            PlayerPrefs.SetInt("runnerCount", ItemData.Instance.factor.runnerCount);
        }

        if (PlayerPrefs.HasKey("runnerSpeed"))
        {
            ItemData.Instance.factor.runnerSpeed = PlayerPrefs.GetFloat("runnerSpeed");
        }
        else
        {
            PlayerPrefs.SetFloat("runnerSpeed", ItemData.Instance.factor.runnerSpeed);
        }

        if (PlayerPrefs.HasKey("bobinCount"))
        {
            ItemData.Instance.factor.bobinCount = PlayerPrefs.GetInt("bobinCount");
        }
        else
        {
            PlayerPrefs.SetInt("bobinCount", ItemData.Instance.factor.bobinCount);
        }

        if (PlayerPrefs.HasKey("addedMoney"))
        {
            ItemData.Instance.factor.addedMoney = PlayerPrefs.GetFloat("addedMoney");
        }
        else
        {
            PlayerPrefs.SetFloat("addedMoney", ItemData.Instance.factor.addedMoney);
        }

        if (PlayerPrefs.HasKey("tableCount"))
        {
            ItemData.Instance.field.tableCount = PlayerPrefs.GetInt("tableCount");
        }
        else
        {
            PlayerPrefs.SetInt("tableCount", ItemData.Instance.field.tableCount);
        }
    }

    public void SetResearchPoint()
    {
        PlayerPrefs.SetInt("researchPoint", researchPoint);
    }

    public void SetMoney()
    {
        PlayerPrefs.SetInt("money", money);
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

    public void SetRunnerSpeed()
    {
        PlayerPrefs.SetFloat("runnerSpeed", ItemData.Instance.factor.runnerSpeed);
        ItemData.Instance.field.runnerSpeed = ItemData.Instance.standart.runnerSpeed - (ItemData.Instance.factor.runnerSpeed * ItemData.Instance.constant.runnerSpeed);
        ItemData.Instance.fieldPrice.runnerSpeed = ItemData.Instance.fieldPrice.runnerSpeed / (ItemData.Instance.factor.runnerSpeed - 1);
        ItemData.Instance.fieldPrice.runnerSpeed = ItemData.Instance.fieldPrice.runnerSpeed * ItemData.Instance.factor.runnerSpeed;
    }

    public void SetBobinCount()
    {
        PlayerPrefs.SetInt("bobinCount", ItemData.Instance.factor.bobinCount);
        ItemData.Instance.field.bobinCount = ItemData.Instance.standart.bobinCount + (ItemData.Instance.factor.bobinCount * ItemData.Instance.constant.bobinCount);
        ItemData.Instance.fieldPrice.bobinCount = ItemData.Instance.fieldPrice.bobinCount / (ItemData.Instance.factor.bobinCount - 1);
        ItemData.Instance.fieldPrice.bobinCount = ItemData.Instance.fieldPrice.bobinCount * ItemData.Instance.factor.bobinCount;
    }

    public void SetAddedMoney()
    {
        PlayerPrefs.SetFloat("addedMoney", ItemData.Instance.factor.addedMoney);
        ItemData.Instance.field.addedMoney = ItemData.Instance.standart.addedMoney + (ItemData.Instance.factor.addedMoney * ItemData.Instance.constant.addedMoney);
        ItemData.Instance.fieldPrice.addedMoney = ItemData.Instance.fieldPrice.addedMoney / (ItemData.Instance.factor.addedMoney - 1);
        ItemData.Instance.fieldPrice.addedMoney = ItemData.Instance.fieldPrice.addedMoney * ItemData.Instance.factor.addedMoney;
    }

    public void SetAddedResearchPoint()
    {
        PlayerPrefs.SetFloat("addedResearchPoint", ItemData.Instance.factor.addedResearchPoint);
        ItemData.Instance.field.addedResearchPoint = ItemData.Instance.standart.addedResearchPoint + (ItemData.Instance.factor.addedResearchPoint * ItemData.Instance.constant.addedResearchPoint);
        ItemData.Instance.fieldPrice.addedResearchPoint = ItemData.Instance.fieldPrice.addedResearchPoint / (ItemData.Instance.factor.addedResearchPoint - 1);
        ItemData.Instance.fieldPrice.addedResearchPoint = ItemData.Instance.fieldPrice.addedResearchPoint * ItemData.Instance.factor.addedResearchPoint;

    }

    public void SetTableCount()
    {
        PlayerPrefs.SetInt("tableCount", ItemData.Instance.field.tableCount);
        ItemData.Instance.field.tableCount = ItemData.Instance.standart.tableCount + (ItemData.Instance.factor.tableCount * ItemData.Instance.constant.tableCount);
        ItemData.Instance.fieldPrice.tableCount = ItemData.Instance.fieldPrice.tableCount / (ItemData.Instance.factor.tableCount - 1);
        ItemData.Instance.fieldPrice.tableCount = ItemData.Instance.fieldPrice.tableCount * ItemData.Instance.factor.tableCount;
    }

    public void SetBarSpeed()
    {
        PlayerPrefs.SetFloat("i", ItemData.Instance.field.barSpeed);
    }
}
