using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableBuy : MonoBehaviour
{
    public List<GameObject> ActiveTables = new List<GameObject>();
    public List<GameObject> PasiveTables = new List<GameObject>();
    public List<bool> ActiveTablesBool = new List<bool>();
    public int barPrice = 2;
    public int TableTemplateCount = 6;
    public int PlaneCount;
    public int TableCount;

    public void TablePlacement()
    {
        for (int i = 0; i < TableCount; i++)
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
            ItemData.Instance.factor.tableCount++;
            Vibration.Vibrate(35);
            SoundSystem.Instance.CallBuyFieldEffect();
            ItemData.Instance.TableCount();
            GameManager.Instance.SetTableCount();
            Buttons.Instance.tableAddedText.text = ItemData.Instance.fieldPrice.tableCount.ToString();
            if (ItemData.Instance.field.tableCount % TableTemplateCount != 0)
            {
                ActiveTables.Add(PasiveTables[(ItemData.Instance.field.tableCount % TableTemplateCount) - 1]);
                ActiveTablesBool.Add(false);
                ActiveTables[(ItemData.Instance.field.tableCount % TableTemplateCount) - 1].SetActive(true);
            }
            else
            {
                ActiveTables.Add(PasiveTables[TableTemplateCount - 1]);
                ActiveTablesBool.Add(false);
                ActiveTables[TableTemplateCount - 1].SetActive(true);
            }

            if (ItemData.Instance.maxFactor.tableCount == ItemData.Instance.factor.tableCount)
            {
                ItemData.Instance.maxFactor.tableCount += TableTemplateCount;
                BuyPlane.Instance.tableCountMaxBool = true;
                Buttons.Instance.tableAddedButton.enabled = false;
                Buttons.Instance.tableAddedText.text = "Full";
                BuyPlane.Instance.NewResearchPlaneButton();
            }
            StartCoroutine(Buttons.Instance.StartBarAyEnum());
        }
    }
}
