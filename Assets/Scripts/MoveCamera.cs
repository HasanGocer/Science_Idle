using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveCamera : MonoSingleton<MoveCamera>
{
    [SerializeField] private float _moveTime;
    public bool move;

    public IEnumerator DoMoveCamera(GameObject moveObject)
    {
        if (!move)
        {
            Debug.Log("HG1");
            move = true;
            this.transform.DOMove(moveObject.transform.position, _moveTime);
            //Camera.main.transform.DORotateQuaternion(moveObject.transform.rotation, _moveTime);
            Debug.Log("HG2");
            yield return new WaitForSeconds(_moveTime);
            move = false;
            Debug.Log("HG3");
        }
    }
}
