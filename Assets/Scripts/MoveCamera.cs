using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveCamera : MonoSingleton<MoveCamera>
{
    public Vector3 camPosTemplate = new Vector3(0, 10, -20);
    public GameObject moneyTempatePos, ResearchTemplatePos;

    [SerializeField] private float _moveTime;
    public bool move;

    public IEnumerator DoMoveCamera(GameObject moveObject)
    {
        if (!move)
        {
            move = true;
            this.transform.DOMove(moveObject.transform.position, _moveTime).SetEase(Ease.InOutSine);
            this.transform.DORotateQuaternion(moveObject.transform.rotation, _moveTime).SetEase(Ease.InOutSine);
            yield return new WaitForSeconds(_moveTime);
            move = false;
        }
    }

    public void StartCamPos()
    {
        moneyTempatePos = SwipSystem.Instance.rightSideObject;
        ResearchTemplatePos = SwipSystem.Instance.leftSideObject;
        SwipSystem.Instance.rightSideObject.transform.position = new Vector3(moneyTempatePos.transform.position.x, moneyTempatePos.transform.position.y + camPosTemplate.y * ItemData.Instance.field.moneyPlane, moneyTempatePos.transform.position.z + camPosTemplate.z * ItemData.Instance.field.moneyPlane);
        SwipSystem.Instance.leftSideObject.transform.position = new Vector3(ResearchTemplatePos.transform.position.x, ResearchTemplatePos.transform.position.y + camPosTemplate.y * ItemData.Instance.field.moneyPlane, ResearchTemplatePos.transform.position.z + camPosTemplate.z * ItemData.Instance.field.moneyPlane);
        transform.position = moneyTempatePos.transform.position;
        transform.position = new Vector3(moneyTempatePos.transform.position.x, moneyTempatePos.transform.position.y + camPosTemplate.y * ItemData.Instance.field.moneyPlane, moneyTempatePos.transform.position.z + camPosTemplate.z * ItemData.Instance.field.moneyPlane);
    }

    public void MoneyCameraNewPos()
    {
        SwipSystem.Instance.rightSideObject.transform.position = new Vector3(moneyTempatePos.transform.position.x, moneyTempatePos.transform.position.y + camPosTemplate.y * ItemData.Instance.field.moneyPlane, moneyTempatePos.transform.position.z + camPosTemplate.z * ItemData.Instance.field.moneyPlane);
        StartCoroutine(DoMoveCamera(SwipSystem.Instance.rightSideObject));
    }

    public void ResearchCameraNewPos()
    {
        SwipSystem.Instance.leftSideObject.transform.position = new Vector3(ResearchTemplatePos.transform.position.x, ResearchTemplatePos.transform.position.y + camPosTemplate.y * ItemData.Instance.field.moneyPlane, ResearchTemplatePos.transform.position.z + camPosTemplate.z * ItemData.Instance.field.moneyPlane);
        StartCoroutine(DoMoveCamera(SwipSystem.Instance.leftSideObject));
    }
}
