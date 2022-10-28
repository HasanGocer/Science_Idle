using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TableWork : MonoBehaviour
{
    [SerializeField] private Image barImage;
    private bool _bar;
    public int barPrice = 2;

    public IEnumerator StartBar(int i)
    {
        while (true)
        {
            if (!_bar)
            {
                _bar = true;
                GameManager.Instance.researchPoint -= barPrice;
                Buttons.Instance.ResearchPointText.text = GameManager.Instance.researchPoint.ToString();
                GameManager.Instance.SetResearchPoint();
                StartCoroutine(Bar());
                yield return new WaitForSeconds(ItemData.Instance.field.barSpeed);
                GameManager.Instance.money += (int)ItemData.Instance.field.addedMoney;
                GameManager.Instance.SetMoney();
                Buttons.Instance.moneyText.text = GameManager.Instance.money.ToString();
                if (GameManager.Instance.researchPoint < barPrice)
                {
                    for (int i1 = 0; i1 < BuyPlane.Instance.ResearchPlanes.Count; i1++)
                    {
                        BuyPlane.Instance.ResearchPlanes[i1].GetComponent<TableBuy>().ActiveTablesBool[i] = false;
                    }
                    break;
                }
            }
            else
                yield return null;

        }

    }

    IEnumerator Bar()
    {
        float timer = 0;
        while (true)
        {
            timer += Time.deltaTime / ItemData.Instance.field.barSpeed;
            barImage.fillAmount = Mathf.Lerp(0, 1, timer);
            yield return new WaitForSeconds(Time.deltaTime);
            if (barImage.fillAmount == 1)
            {
                barImage.fillAmount = 0;
                _bar = false;
                StartCoroutine(PointText.Instance.CallPointMoneyText(transform.gameObject));
                break;
            }
        }
    }
}
