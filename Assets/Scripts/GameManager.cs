using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    //oyunun tüm prefeblerinin ve oyunun hangi safhasýnda olduðu deðeri burada dönülür


    public int money;
    public int resarchPoint;
    public int vibration;
    public int sound;

    private void Start()
    {
        if (PlayerPrefs.HasKey("resarchPoint"))
        {
            money = PlayerPrefs.GetInt("resarchPoint");
        }
        else
        {
            PlayerPrefs.SetInt("resarchPoint", 0);
        }

        if (PlayerPrefs.HasKey("money"))
        {
            money = PlayerPrefs.GetInt("money");
        }
        else
        {
            PlayerPrefs.SetInt("money", 0);
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

        if (PlayerPrefs.HasKey("runnerSpeed"))
        {
            ItemData.Instance.factor.runnerSpeed = PlayerPrefs.GetFloat("runnerSpeed");
        }
        else
        {
            PlayerPrefs.SetFloat("runnerSpeed", 1);
        }

        if (PlayerPrefs.HasKey("bobinCount"))
        {
            ItemData.Instance.factor.bobinCount = PlayerPrefs.GetInt("bobinCount");
        }
        else
        {
            PlayerPrefs.SetInt("bobinCount", 1);
        }

        if (PlayerPrefs.HasKey("addedMoney"))
        {
            ItemData.Instance.factor.addedMoney = PlayerPrefs.GetFloat("addedMoney");
        }
        else
        {
            PlayerPrefs.SetFloat("addedMoney", 1);
        }

        if (PlayerPrefs.HasKey("merge"))
        {
            ItemData.Instance.factor.merge = PlayerPrefs.GetInt("merge");
        }
        else
        {
            PlayerPrefs.SetInt("merge", 1);
        }
    }

    public void SetResarchPoint()
    {
        PlayerPrefs.SetInt("resarchPoint", resarchPoint);
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
        MyDoPath.Instance.pat.duration = ItemData.Instance.field.runnerSpeed * MyDoPath.Instance.length[0];
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

    public void SetMerge()
    {
        PlayerPrefs.SetInt("merge", ItemData.Instance.factor.merge);
        ItemData.Instance.field.merge = ItemData.Instance.standart.merge + (ItemData.Instance.factor.merge * ItemData.Instance.constant.merge);
        ItemData.Instance.fieldPrice.merge = ItemData.Instance.fieldPrice.merge / (ItemData.Instance.factor.merge - 1);
        ItemData.Instance.fieldPrice.merge = ItemData.Instance.fieldPrice.merge * ItemData.Instance.factor.merge;
    }

}
