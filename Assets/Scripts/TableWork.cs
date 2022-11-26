using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TableWork : MonoBehaviour
{
    [SerializeField] private Image barImage;
    [SerializeField] private Image barSpeedImage;
    private bool _bar;
    public bool hide;
    public int barPrice = 2;
    [SerializeField] private GameObject workWithStickman;
    [SerializeField] private int barTime = 3;

    public IEnumerator StartBar(int i)
    {
        while (true)
        {
            if (!_bar && !hide && GameManager.Instance.contractBool)
            {
                _bar = true;
                MoneySystem.Instance.ResearchTextRevork(barPrice * -1);
                StartCoroutine(Bar());
                yield return new WaitForSeconds(0.1f);
                GameManager.Instance.contractCount--;
                if (GameManager.Instance.contractCount < 0)
                    GameManager.Instance.contractCount = 0;
                GameManager.Instance.SetContractCount();
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
            {
                timer += (Time.deltaTime * 2) / barTime;
                barSpeedImage.gameObject.SetActive(true);
            }
            else
            {
                barSpeedImage.gameObject.SetActive(false);
            }
            barImage.fillAmount = Mathf.Lerp(0, 1, timer);
            barSpeedImage.fillAmount = Mathf.Lerp(0, 1, timer);

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
