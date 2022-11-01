using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveCamera : MonoSingleton<MoveCamera>
{
    public Vector3 camPosTemplate = new Vector3(0, 10, -20);
    public GameObject moneyTempatePos, ResearchTemplatePos;
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
        moneyTempatePos = SwipSystem.Instance.rightSideObject;
        ResearchTemplatePos = SwipSystem.Instance.leftSideObject;
        SwipSystem.Instance.rightSideObject.transform.position = new Vector3(moneyTempatePos.transform.position.x, moneyTempatePos.transform.position.y + camPosTemplate.y * ItemData.Instance.field.moneyPlane, moneyTempatePos.transform.position.z + camPosTemplate.z * ItemData.Instance.field.moneyPlane);
        SwipSystem.Instance.leftSideObject.transform.position = new Vector3(ResearchTemplatePos.transform.position.x, ResearchTemplatePos.transform.position.y + camPosTemplate.y * ItemData.Instance.field.researchPlane, ResearchTemplatePos.transform.position.z + camPosTemplate.z * ItemData.Instance.field.researchPlane);
        if (planeLimit <= ItemData.Instance.field.moneyPlane)
        {
            transform.position = new Vector3(moneyTempatePos.transform.position.x, moneyTempatePos.transform.position.y + camPosTemplate.y * ItemData.Instance.field.moneyPlane, moneyTempatePos.transform.position.z + camPosTemplate.z * ItemData.Instance.field.moneyPlane);
        }
        else
        {
            transform.position = new Vector3(moneyTempatePos.transform.position.x, moneyTempatePos.transform.position.y + camPosTemplate.y * ItemData.Instance.field.moneyPlane, moneyTempatePos.transform.position.z + camPosTemplate.z * planeLimit);
        }
        SwipSystem.Instance.stayMoneyPlane = true;
    }

    public void MoneyCameraNewPos()
    {
        if (planeLimit <= ItemData.Instance.field.moneyPlane)
        {
            SwipSystem.Instance.rightSideObject.transform.position = new Vector3(moneyTempatePos.transform.position.x, moneyTempatePos.transform.position.y + camPosTemplate.y * ItemData.Instance.field.moneyPlane, moneyTempatePos.transform.position.z + camPosTemplate.z * ItemData.Instance.field.moneyPlane);
        }
        else
        {
            SwipSystem.Instance.rightSideObject.transform.position = new Vector3(moneyTempatePos.transform.position.x, moneyTempatePos.transform.position.y + camPosTemplate.y * ItemData.Instance.field.moneyPlane, moneyTempatePos.transform.position.z + camPosTemplate.z * planeLimit);

        }
        StartCoroutine(DoMoveCamera(SwipSystem.Instance.rightSideObject));
    }

    public void ResearchCameraNewPos()
    {
        if (planeLimit <= ItemData.Instance.field.moneyPlane)
        {
            SwipSystem.Instance.leftSideObject.transform.position = new Vector3(ResearchTemplatePos.transform.position.x, ResearchTemplatePos.transform.position.y + camPosTemplate.y * ItemData.Instance.field.researchPlane, ResearchTemplatePos.transform.position.z + camPosTemplate.z * ItemData.Instance.field.researchPlane);
        }
        else
        {
            SwipSystem.Instance.leftSideObject.transform.position = new Vector3(ResearchTemplatePos.transform.position.x, ResearchTemplatePos.transform.position.y + camPosTemplate.y * ItemData.Instance.field.researchPlane, ResearchTemplatePos.transform.position.z + camPosTemplate.z * planeLimit);
        }
        StartCoroutine(DoMoveCamera(SwipSystem.Instance.leftSideObject));
    }
}
