using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : MonoSingleton<ItemData>
{
    [System.Serializable]
    public class Field
    {
        public int runnerCount, bobinCount, tableCount, moneyPlane, researchPlane;
        public float runnerSpeed, addedMoney, addedResearchPoint, barSpeed;
    }

    [System.Serializable]
    public class FiledBool
    {
        public bool runnerCount, bobinCount, tableCount, moneyPlane, researchPlane, runnerSpeed, addedMoney, addedResearchPoint, barSpeed;
    }

    public Field field;
    public Field standart;
    public Field factor;
    public Field constant;
    public Field maxFactor;
    public Field max;
    public Field fieldPrice;
    public FiledBool maxBool;

    public void ItemPlacement()
    {
        field.runnerSpeed = standart.runnerSpeed - (factor.runnerSpeed * constant.runnerSpeed);
        fieldPrice.runnerSpeed = fieldPrice.runnerSpeed * factor.runnerSpeed;
        if (field.runnerSpeed > maxFactor.runnerSpeed)
        {
            maxFactor.runnerSpeed = ((field.runnerSpeed / MyDoPath.Instance.runnerCount) + 1) * MyDoPath.Instance.runnerCount;
        }

        field.runnerCount = standart.runnerCount + (factor.runnerCount * constant.runnerCount);
        fieldPrice.runnerCount = fieldPrice.runnerCount * factor.runnerCount;
        if (field.runnerCount > maxFactor.runnerCount)
        {
            maxFactor.runnerCount = ((field.runnerCount / MyDoPath.Instance.runnerCount) + 1) * MyDoPath.Instance.runnerCount;
        }
        field.bobinCount = standart.bobinCount + (factor.bobinCount * constant.bobinCount);
        fieldPrice.bobinCount = fieldPrice.bobinCount * factor.bobinCount;
        if (field.bobinCount > maxFactor.bobinCount)
        {
            maxFactor.bobinCount = ((field.bobinCount / MyDoPath.Instance.runnerCount) + 1) * MyDoPath.Instance.runnerCount;
        }
        field.tableCount = standart.tableCount + (factor.tableCount * constant.tableCount);
        fieldPrice.tableCount = fieldPrice.tableCount * factor.tableCount;
        if (field.tableCount > maxFactor.tableCount)
        {
            maxFactor.tableCount = ((field.tableCount / MyDoPath.Instance.runnerCount) + 1) * MyDoPath.Instance.runnerCount;
        }



        field.addedMoney = standart.addedMoney + (factor.addedMoney * constant.addedMoney);
        fieldPrice.addedMoney = fieldPrice.addedMoney * factor.addedMoney;
        field.addedResearchPoint = standart.addedResearchPoint + (factor.addedResearchPoint * constant.addedResearchPoint);
        fieldPrice.addedResearchPoint = fieldPrice.addedResearchPoint * factor.addedResearchPoint;
        field.barSpeed = standart.barSpeed - (factor.barSpeed * constant.barSpeed);
        fieldPrice.barSpeed = fieldPrice.barSpeed * factor.barSpeed;
        field.moneyPlane = standart.moneyPlane + (factor.moneyPlane * constant.moneyPlane);
        fieldPrice.moneyPlane = fieldPrice.moneyPlane * factor.moneyPlane;
        field.researchPlane = standart.researchPlane + (factor.researchPlane * constant.researchPlane);
        fieldPrice.researchPlane = fieldPrice.researchPlane * factor.researchPlane;

        if (field.runnerCount > max.runnerCount && maxBool.runnerCount)
        {
            field.runnerCount = max.runnerCount;
        }

        if (field.bobinCount > max.bobinCount && maxBool.bobinCount)
        {
            field.bobinCount = max.bobinCount;
        }

        if (field.tableCount > max.tableCount && maxBool.tableCount)
        {
            field.tableCount = max.tableCount;
        }

        if (field.runnerSpeed < max.runnerSpeed && maxBool.runnerSpeed)
        {
            field.runnerSpeed = max.runnerSpeed;
        }

        if (field.addedMoney > max.addedMoney && maxBool.addedMoney)
        {
            field.addedMoney = max.addedMoney;
        }

        if (field.addedResearchPoint > max.addedResearchPoint && maxBool.addedResearchPoint)
        {
            field.addedResearchPoint = max.addedResearchPoint;
        }

        if (field.barSpeed < max.barSpeed && maxBool.barSpeed)
        {
            field.barSpeed = max.barSpeed;
        }

        if (field.moneyPlane < max.moneyPlane && maxBool.moneyPlane)
        {
            field.moneyPlane = max.moneyPlane;
        }

        if (field.researchPlane < max.researchPlane && maxBool.researchPlane)
        {
            field.researchPlane = max.researchPlane;
        }

        Debug.Log("1");
        MyDoPath.Instance.PlanePlacement();
        Debug.Log("2");
        BuyPlane.Instance.StartPlanePlacement();
        Debug.Log("3");
        StartCoroutine(RunnerManager.Instance.StartRunner());
        Debug.Log("4");
        Buttons.Instance.TextStart();
        Debug.Log("5");
        Buttons.Instance.ButtonStart();
        Debug.Log("6");
    }

    public void RunnerCount()
    {
        field.runnerCount = standart.runnerCount + (factor.runnerCount * constant.runnerCount);

        if (field.runnerCount > max.runnerCount && maxBool.runnerCount)
        {
            field.runnerCount = max.runnerCount;
        }
    }

    public void BobinCount()
    {
        field.bobinCount = standart.bobinCount + (factor.bobinCount * constant.bobinCount);

        if (field.bobinCount > max.bobinCount && maxBool.bobinCount)
        {
            field.bobinCount = max.bobinCount;
        }
    }

    public void TableCount()
    {
        field.tableCount = standart.tableCount + (factor.tableCount * constant.tableCount);

        if (field.tableCount > max.tableCount && maxBool.tableCount)
        {
            field.tableCount = max.tableCount;
        }
    }

    public void RunnerSpeed()
    {
        field.runnerSpeed = standart.runnerSpeed - (factor.runnerSpeed * constant.runnerSpeed);

        if (field.runnerSpeed < max.runnerSpeed && maxBool.runnerSpeed)
        {
            field.runnerSpeed = max.runnerSpeed;
        }
    }

    public void AddedMoney()
    {
        field.addedMoney = standart.addedMoney + (factor.addedMoney * constant.addedMoney);

        if (field.addedMoney > max.addedMoney && maxBool.addedMoney)
        {
            field.addedMoney = max.addedMoney;
        }
    }

    public void AddedResearchPoint()
    {
        field.addedResearchPoint = standart.addedResearchPoint + (factor.addedResearchPoint * constant.addedResearchPoint);

        if (field.addedResearchPoint > max.addedResearchPoint && maxBool.addedResearchPoint)
        {
            field.addedResearchPoint = max.addedResearchPoint;
        }
    }

    public void BarSpeed()
    {
        field.barSpeed = standart.barSpeed - (factor.barSpeed * constant.barSpeed);

        if (field.barSpeed < max.barSpeed && maxBool.barSpeed)
        {
            field.barSpeed = max.barSpeed;
        }
    }

    public void MoneyPlane()
    {
        field.moneyPlane = standart.moneyPlane + (factor.moneyPlane * constant.moneyPlane);

        if (field.moneyPlane > max.moneyPlane && maxBool.moneyPlane)
        {
            field.moneyPlane = max.moneyPlane;
        }
    }

    public void ResearchPlane()
    {
        field.researchPlane = standart.researchPlane + (factor.researchPlane * constant.researchPlane);

        if (field.researchPlane > max.researchPlane && maxBool.researchPlane)
        {
            field.researchPlane = max.researchPlane;
        }
    }
}
