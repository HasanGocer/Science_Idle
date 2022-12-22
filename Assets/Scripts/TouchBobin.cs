using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchBobin : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            MoneySystem.Instance.ResearchTextRevork((int)((ItemData.Instance.field.addedMoney)));
            Buttons.Instance.StartButtonPrice();
            StartCoroutine(PointText.Instance.CallPointResearchText(transform.gameObject));
        }
    }
}
