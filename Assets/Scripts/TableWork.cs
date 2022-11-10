using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TableWork : MonoBehaviour
{
    [SerializeField] private Image barImage;
    private bool _bar;
    public bool hide;
    public int barPrice = 2;
    [SerializeField] private GameObject workWithStickman;
    [SerializeField] private int barTime = 3;

    public IEnumerator StartBar(int i)
    {
        while (true)
        {
            if (!_bar && !hide)
            {
                _bar = true;
                MoneySystem.Instance.ResearchTextRevork(barPrice * -1);
                StartCoroutine(Bar());
                yield return new WaitForSeconds(0.1f);
                MoneySystem.Instance.MoneyTextRevork((int)ItemData.Instance.field.addedMoney);
                workWithStickman.SetActive(true);
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
            timer += Time.deltaTime / barTime;
            if (SpeedBarOption.Instance.touchInScreen)
                timer += Time.deltaTime / barTime;
            barImage.fillAmount = Mathf.Lerp(0, 1, timer);
            yield return new WaitForSeconds(Time.deltaTime);
            if (barImage.fillAmount == 1)
            {
                barImage.fillAmount = 0;
                _bar = false;
                StartCoroutine(PointText.Instance.CallPointMoneyText(transform.gameObject));
                CounterSystem.Instance.CounterPlus((int)ItemData.Instance.field.addedMoney);
                break;
            }
            if (hide)
            {
                _bar = false;
                break;
            }
        }
    }
}
