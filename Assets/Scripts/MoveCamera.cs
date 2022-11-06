using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveCamera : MonoSingleton<MoveCamera>
{
    public Vector3 camPosMoneyTemplate;
    public Vector3 camPosResearchTemplate;
    public Vector3 moneyTempatePos, ResearchTemplatePos;
    [SerializeField] private int planeLimit;

    [SerializeField] private float _moveTime;
    public bool move;

    public IEnumerator DoMoveCamera(GameObject moveObject)
    {
        if (!move)
        {
            move = true;
            this.transform.DOMove(moveObject.transform.position, _moveTime).SetEase(Ease.InOutSine);
            yield return new WaitForSeconds(_moveTime);
            move = false;
        }
    }

    public void StartCamPos()
    {
        moneyTempatePos = SwipSystem.Instance.rightSideObject.transform.position;
        ResearchTemplatePos = SwipSystem.Instance.leftSideObject.transform.position;
        SwipSystem.Instance.rightSideObject.transform.position = new Vector3(moneyTempatePos.x, moneyTempatePos.y + camPosMoneyTemplate.y * ItemData.Instance.field.moneyPlane, moneyTempatePos.z + camPosMoneyTemplate.z * ItemData.Instance.field.moneyPlane);
        SwipSystem.Instance.leftSideObject.transform.position = new Vector3(ResearchTemplatePos.x, ResearchTemplatePos.y + camPosResearchTemplate.y * ItemData.Instance.field.researchPlane, ResearchTemplatePos.z + camPosResearchTemplate.z * ItemData.Instance.field.researchPlane);
        if (planeLimit >= ItemData.Instance.field.moneyPlane)
        {
            transform.position = new Vector3(moneyTempatePos.x, moneyTempatePos.y + camPosMoneyTemplate.y * ItemData.Instance.field.moneyPlane, moneyTempatePos.z + camPosMoneyTemplate.z * ItemData.Instance.field.moneyPlane);
        }
        else
        {
            transform.position = new Vector3(moneyTempatePos.x, moneyTempatePos.y + camPosMoneyTemplate.y * ItemData.Instance.field.moneyPlane, moneyTempatePos.z + camPosMoneyTemplate.z * planeLimit);
        }
        SwipSystem.Instance.stayMoneyPlane = true;
    }

    public void MoneyCameraNewPos()
    {
        if (planeLimit >= ItemData.Instance.field.moneyPlane)
        {
            SwipSystem.Instance.rightSideObject.transform.position = new Vector3(moneyTempatePos.x, moneyTempatePos.y + camPosMoneyTemplate.y * ItemData.Instance.field.moneyPlane, moneyTempatePos.z + camPosMoneyTemplate.z * ItemData.Instance.field.moneyPlane);
        }
        else
        {
            SwipSystem.Instance.rightSideObject.transform.position = new Vector3(moneyTempatePos.x, moneyTempatePos.y + camPosMoneyTemplate.y * ItemData.Instance.field.moneyPlane, moneyTempatePos.z + camPosMoneyTemplate.z * planeLimit);

        }
        StartCoroutine(DoMoveCamera(SwipSystem.Instance.rightSideObject));
    }

    public void ResearchCameraNewPos()
    {
        if (planeLimit >= ItemData.Instance.field.researchPlane)
        {
            SwipSystem.Instance.leftSideObject.transform.position = new Vector3(ResearchTemplatePos.x, ResearchTemplatePos.y + camPosResearchTemplate.y * ItemData.Instance.field.researchPlane, ResearchTemplatePos.z + camPosResearchTemplate.z * ItemData.Instance.field.researchPlane);
        }
        else
        {
            SwipSystem.Instance.leftSideObject.transform.position = new Vector3(ResearchTemplatePos.x, ResearchTemplatePos.y + camPosResearchTemplate.y * ItemData.Instance.field.researchPlane, ResearchTemplatePos.z + camPosResearchTemplate.z * planeLimit);
        }
        StartCoroutine(DoMoveCamera(SwipSystem.Instance.leftSideObject));
    }
}
