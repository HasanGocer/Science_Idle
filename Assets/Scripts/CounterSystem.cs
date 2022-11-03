using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterSystem : MonoBehaviour
{
    public float auctionTime;

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
        Buttons.Instance.counterPointText.text = GameManager.Instance.counterPoint.ToString();
    }

    public IEnumerator CounterFinish()
    {
        while (true)
        {
            yield return new WaitForSeconds(auctionTime);
            int limit = Random.Range(0, (determination.up + determination.down + determination.stay));

            if (limit <= determination.down)
            {
                GameManager.Instance.money += (GameManager.Instance.counterPoint / limit);
                break;
            }
            else if (limit <= determination.stay)
            {
                GameManager.Instance.money += GameManager.Instance.counterPoint;
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
