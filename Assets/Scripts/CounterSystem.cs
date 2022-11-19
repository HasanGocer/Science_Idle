using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterSystem : MonoSingleton<CounterSystem>
{

    [System.Serializable]
    public class Determination
    {
        public int up, stay, down;
    }
    public Determination determination;

    public void CounterPlus(int count)
    {
        GameManager.Instance.counterPoint += count;
        GameManager.Instance.SetCounterPoint();
        if (GameManager.Instance.counterPoint < 0)
        {
            GameManager.Instance.counterPoint = 0;

        }
        Buttons.Instance.counterPointText.text = GameManager.Instance.counterPoint.ToString();
    }

    public void CounterFinish()
    {
        while (true)
        {
            int limit = Random.Range(0, (determination.up + determination.down + determination.stay));

            if (limit <= determination.down)
            {
                MoneySystem.Instance.MoneyTextRevork(GameManager.Instance.counterPoint / limit);
                GameManager.Instance.counterPoint = 0;
                GameManager.Instance.SetCounterPoint();
                Buttons.Instance.counterPointText.text = GameManager.Instance.counterPoint.ToString();
                break;
            }
            else if (limit <= determination.stay)
            {
                MoneySystem.Instance.MoneyTextRevork(GameManager.Instance.counterPoint);
                GameManager.Instance.counterPoint = 0;
                GameManager.Instance.SetCounterPoint();
                Buttons.Instance.counterPointText.text = GameManager.Instance.counterPoint.ToString();
                break;
            }
            else if (limit <= determination.up)
            {
                GameManager.Instance.counterPoint += limit * (GameManager.Instance.counterPoint / (determination.up * determination.down));
            }
        }
        GameManager.Instance.counterPoint = 0;
        GameManager.Instance.SetCounterPoint();
        Buttons.Instance.counterPointText.text = GameManager.Instance.counterPoint.ToString();
    }
}
