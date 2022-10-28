using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchBobin : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            GameManager.Instance.researchPoint += (int)((ItemData.Instance.field.addedMoney * GetComponentInParent<BobinManager>().bobinCount));
            GameManager.Instance.SetResearchPoint();
            Buttons.Instance.ResearchPointText.text = GameManager.Instance.researchPoint.ToString();
            StartCoroutine(PointText.Instance.CallPointResearchText(transform.gameObject));
        }
    }
}
