using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchBobin : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            MoneySystem.Instance.ResearchTextRevork((int)((ItemData.Instance.field.addedMoney * GetComponentInParent<BobinManager>().bobinCount)));
            StartCoroutine(PointText.Instance.CallPointResearchText(transform.gameObject));
        }
    }
}
