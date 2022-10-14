using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableBuy : MonoSingleton<TableBuy>
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
        ActiveTables.Add(PasiveTables[ItemData.Instance.field.tableCount - 1]);
        ActiveTablesBool.Add(false);
        ActiveTables[ItemData.Instance.field.tableCount - 1].SetActive(true);
        GameManager.Instance.SetTableCount();
    }
}
