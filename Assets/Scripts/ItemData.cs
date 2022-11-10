using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : MonoSingleton<ItemData>
{
    [System.Serializable]
    public class Field
    {
        public int runnerCount, bobinCount, tableCount, moneyPlane, researchPlane;
        public float runnerSpeed, addedMoney, addedResearchPoint;
    }

    [System.Serializable]
    public class FiledBool
    {
        public bool runnerCount, bobinCount, tableCount, moneyPlane, researchPlane, addedMoney, addedResearchPoint;
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
        field.runnerSpeed = standart.runnerSpeed;

        field.runnerCount = standart.runnerCount + (factor.runnerCount * constant.runnerCount);
        fieldPrice.runnerCount = fieldPrice.runnerCount * factor.runnerCount;
        if (field.runnerCount > maxFactor.runnerCount)
        {
            maxFactor.runnerCount = ((field.runnerCount / MyDoPath.Instance.runnerCount) + 1) * MyDoPath.Instance.runnerCount;
            if (factor.moneyPlane * MyDoPath.Instance.runnerCount > factor.runnerCount)
            {
                int newCount = factor.runnerCount % MyDoPath.Instance.runnerCount;
                newCount += factor.moneyPlane * MyDoPath.Instance.runnerCount;
                factor.runnerCount = newCount;
                maxFactor.runnerCount = (factor.moneyPlane + 1) * MyDoPath.Instance.runnerCount;
                GameManager.Instance.SetRunnerCount();
            }
        }

        field.bobinCount = standart.bobinCount + (factor.bobinCount * constant.bobinCount);
        fieldPrice.bobinCount = fieldPrice.bobinCount * factor.bobinCount;
        if (field.bobinCount > maxFactor.bobinCount)
        {
            maxFactor.bobinCount = ((field.bobinCount / MyDoPath.Instance.runnerCount) + 1) * MyDoPath.Instance.runnerCount;
            if (factor.moneyPlane * MyDoPath.Instance.runnerCount > factor.bobinCount)
            {
                int newCount = factor.bobinCount % MyDoPath.Instance.runnerCount;
                newCount += factor.moneyPlane * MyDoPath.Instance.runnerCount;
                factor.bobinCount = newCount;
                maxFactor.bobinCount = (factor.moneyPlane + 1) * MyDoPath.Instance.runnerCount;
                GameManager.Instance.SetBobinCount();
            }
        }

        field.tableCount = standart.tableCount + (factor.tableCount * constant.tableCount);
        fieldPrice.tableCount = fieldPrice.tableCount * factor.tableCount;
        if (field.tableCount > maxFactor.tableCount)
        {
            maxFactor.tableCount = ((field.tableCount / 6) + 1) * 6;
            if (factor.moneyPlane * 6 > factor.tableCount)
            {
                int newCount = factor.tableCount % 6;
                newCount += factor.moneyPlane * 6;
                factor.tableCount = newCount;
                maxFactor.tableCount = (factor.moneyPlane + 1) * 6;
                GameManager.Instance.SetTableCount();
            }
        }



        field.addedMoney = standart.addedMoney;
        field.addedResearchPoint = standart.addedResearchPoint;
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

        if (field.moneyPlane < max.moneyPlane && maxBool.moneyPlane)
        {
            field.moneyPlane = max.moneyPlane;
        }

        if (field.researchPlane < max.researchPlane && maxBool.researchPlane)
        {
            field.researchPlane = max.researchPlane;
        }

        MyDoPath.Instance.PlanePlacement();
        BuyPlane.Instance.StartPlanePlacement();
        StartCoroutine(RunnerManager.Instance.StartRunner());
        Buttons.Instance.ButtonStart();
        Buttons.Instance.TextStart();
        MoveCamera.Instance.StartCamPos();
        StartCoroutine(Buttons.Instance.StartBarAyEnum());
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
