using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableBuy : MonoBehaviour
{
    public List<GameObject> ActiveTables = new List<GameObject>();
    public List<GameObject> PasiveTables = new List<GameObject>();
    public List<bool> ActiveTablesBool = new List<bool>();
    public int barPrice = 2;

    public void TablePlacement()
    {
        for (int i = 0; i < ItemData.Instance.field.tableCount; i++)
        {
            ActiveTables.Add(PasiveTables[i]);
            ActiveTablesBool.Add(false);
            ActiveTables[i].SetActive(true);
        }
    }

    public void TableBuyWithButton()
    {
        if (ItemData.Instance.maxFactor.tableCount >= ItemData.Instance.factor.tableCount)
        {
            ActiveTables.Add(PasiveTables[ItemData.Instance.field.tableCount - 1]);
            ActiveTablesBool.Add(false);
            ActiveTables[ItemData.Instance.field.tableCount - 1].SetActive(true);
            GameManager.Instance.SetTableCount();
            if (ItemData.Instance.maxFactor.tableCount == ItemData.Instance.factor.tableCount)
            {
                ItemData.Instance.factor.tableCount++;
                GameManager.Instance.SetTableCount();
                ItemData.Instance.TableCount();
                Buttons.Instance.tableAddedText.text = ItemData.Instance.fieldPrice.tableCount.ToString();
                BuyPlane.Instance.tableCountMaxBool = true;
                BuyPlane.Instance.NewResearchPlaneButton();
            }
        }

    }
}
