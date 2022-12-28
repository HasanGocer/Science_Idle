using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarSystem : MonoSingleton<BarSystem>
{
    [SerializeField] private Image _bar;
    public bool isFinish;
    [SerializeField] private bool _goRight = true;
    public int barMoneyFactor;
    [SerializeField] private GameObject startPos, finishPos;
    float amount = 0;

    public void BarStopButton(int count)
    {
        isFinish = false;
        amount = 0;
        BarFactorPlacement(amount);
        if (count != 0)
            ContractSystem.Instance.finishCountText.text = (count * barMoneyFactor).ToString();
        MoneySystem.Instance.MoneyTextRevork(count * barMoneyFactor);
    }

    public IEnumerator BarImageFillAmountIenum()
    {
        isFinish = true;
        while (isFinish)
        {
            amount += Time.deltaTime / 4;
            if (_goRight)
            {
                _bar.transform.position = Vector2.Lerp(startPos.transform.position, finishPos.transform.position, amount);
            }
            else
            {
                _bar.transform.position = Vector2.Lerp(finishPos.transform.position, startPos.transform.position, amount);
            }
            yield return new WaitForEndOfFrame();

            if (amount >= 1)
            {
                amount = 0;
                if (_goRight)
                    _goRight = false;
                else
                    _goRight = true;
            }
        }
    }

    private void BarFactorPlacement(float barAmount)
    {
        if (barAmount < 0.2f)
            barMoneyFactor = 1;
        else if (barAmount < 0.4f)
            barMoneyFactor = 2;
        else if (barAmount < 0.6f)
            barMoneyFactor = 3;
        else if (barAmount < 0.8f)
            barMoneyFactor = 2;
        else
            barMoneyFactor = 1;
    }
}
