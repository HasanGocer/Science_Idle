using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemData : MonoSingleton<ItemData>
{
    [System.Serializable]
    public class Field
    {
        public int runnerCount, bobinCount, merge;
        public float runnerSpeed, addedMoney;
    }

    public Field field;
    public Field standart;
    public Field factor;
    public Field constant;
    public Field maxFactor;
    public Field max;
    public Field fieldPrice;

    private void Start()
    {
        field.runnerSpeed = standart.runnerSpeed - (factor.runnerSpeed * constant.runnerSpeed);
        fieldPrice.runnerSpeed = fieldPrice.runnerSpeed * factor.runnerSpeed;
        MyDoPath.Instance.pat.duration = ItemData.Instance.field.runnerSpeed * MyDoPath.Instance.length[0];
        field.addedMoney = standart.addedMoney + (factor.addedMoney * constant.addedMoney);
        fieldPrice.addedMoney = fieldPrice.addedMoney * factor.addedMoney;
        field.runnerCount = standart.runnerCount + (factor.runnerCount * constant.runnerCount);
        fieldPrice.runnerCount = fieldPrice.runnerCount * factor.runnerCount;
        field.bobinCount = standart.bobinCount + (factor.bobinCount * constant.bobinCount);
        fieldPrice.bobinCount = fieldPrice.bobinCount * factor.bobinCount;
        field.merge = standart.merge + (factor.merge * constant.merge);
        fieldPrice.merge = fieldPrice.merge * factor.merge;

        if (field.runnerSpeed < max.runnerSpeed)
        {
            field.runnerSpeed = max.runnerSpeed;
        }

        if (field.addedMoney > max.addedMoney)
        {
            field.addedMoney = max.addedMoney;
        }

        if (field.runnerCount > max.runnerCount)
        {
            field.runnerCount = max.runnerCount;
        }

        if (field.bobinCount > max.bobinCount)
        {
            field.bobinCount = max.bobinCount;
        }

        if (field.merge > max.merge)
        {
            field.merge = max.merge;
        }
    }

    public void RunnerSpeed()
    {
        field.runnerSpeed = standart.runnerSpeed - (factor.runnerSpeed * constant.runnerSpeed);

        if (field.runnerSpeed < max.runnerSpeed)
        {
            field.runnerSpeed = max.runnerSpeed;
        }
    }

    public void AddedMoney()
    {
        field.addedMoney = standart.addedMoney + (factor.addedMoney * constant.addedMoney);

        if (field.addedMoney > max.addedMoney)
        {
            field.addedMoney = max.addedMoney;
        }
    }

    public void RunnerCount()
    {
        field.runnerCount = standart.runnerCount + (factor.runnerCount * constant.runnerCount);

        if (field.runnerCount > max.runnerCount)
        {
            field.runnerCount = max.runnerCount;
        }
    }

    public void BobinCount()
    {
        field.bobinCount = standart.bobinCount + (factor.bobinCount * constant.bobinCount);

        if (field.bobinCount > max.bobinCount)
        {
            field.bobinCount = max.bobinCount;
        }
    }

    public void Merge()
    {
        field.merge = standart.merge + (factor.merge * constant.merge);

        if (field.merge > max.merge)
        {
            field.merge = max.merge;
        }
    }
}
