using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneySystem : MonoSingleton<MoneySystem>
{
    [SerializeField] private int _billion = 1000000000, _million = 1000000, _thousand = 1000;

    public void MoneyTextRevork(int plus)
    {
        GameManager.Instance.money += plus;

        if (GameManager.Instance.money >= _billion)
        {
            int money = GameManager.Instance.money / 100000000;
            float Floatmoney = (float)money / 10;
            Buttons.Instance.moneyText.text = Floatmoney.ToString() + " B";
        }
        else if (GameManager.Instance.money >= _million)
        {
            int money = GameManager.Instance.money / 100000;
            float Floatmoney = (float)money / 10;
            Buttons.Instance.moneyText.text = Floatmoney.ToString() + " M";
        }
        else if (GameManager.Instance.money >= _thousand)
        {
            int money = GameManager.Instance.money / 100;
            float Floatmoney = (float)money / 10;
            Buttons.Instance.moneyText.text = Floatmoney.ToString() + " K";
        }
        else
        {
            Buttons.Instance.moneyText.text = GameManager.Instance.money.ToString();
        }
        GameManager.Instance.SetMoney();
    }

    public void ResearchTextRevork(int plus)
    {
        GameManager.Instance.researchPoint += plus;

        if (GameManager.Instance.researchPoint >= _billion)
        {
            int researchPoint = GameManager.Instance.researchPoint / 100000000;
            float FloatresearchPoint = (float)researchPoint / 10;
            Buttons.Instance.ResearchPointText.text = FloatresearchPoint.ToString() + " B";
        }
        else if (GameManager.Instance.researchPoint >= _million)
        {
            int researchPoint = GameManager.Instance.researchPoint / 100000;
            float FloatresearchPoint = (float)researchPoint / 10;
            Buttons.Instance.ResearchPointText.text = FloatresearchPoint.ToString() + " M";
        }
        else if (GameManager.Instance.researchPoint >= _thousand)
        {
            int researchPoint = GameManager.Instance.researchPoint / 100;
            float FloatresearchPoint = (float)researchPoint / 10;
            Buttons.Instance.ResearchPointText.text = FloatresearchPoint.ToString() + " K";
        }
        else
        {
            Buttons.Instance.ResearchPointText.text = GameManager.Instance.researchPoint.ToString();
        }
        GameManager.Instance.SetResearchPoint();
    }
}
