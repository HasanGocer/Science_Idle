using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchBobin : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            GameManager.Instance.money += (int)ItemData.Instance.field.addedMoney;
            Buttons.Instance.moneyText.text = GameManager.Instance.money.ToString();
        }
    }
}
