using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipSystem : MonoBehaviour
{
    Touch touch;
    float vec2Start, vec2Finish;
    bool moved;

    [SerializeField] private GameObject leftSideObject;
    [SerializeField] private GameObject rightSideObject;

    [SerializeField] private GameObject _leftGame;
    [SerializeField] private GameObject _rightGame;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Debug.Log("HG");
            touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    vec2Start = Camera.main.ScreenToWorldPoint(touch.position).x;
                    break;

                case TouchPhase.Moved:
                    moved = true;
                    break;

                case TouchPhase.Ended:
                    vec2Finish = Camera.main.ScreenToWorldPoint(touch.position).x;
                    SwipSystemFunc(vec2Start, vec2Finish, moved);
                    break;
            }
            moved = false;
        }
    }

    private void SwipSystemFunc(float start, float finish, bool moved)
    {
        if (moved)
            if (finish - start > 0)
            {
                if (!MoveCamera.Instance.move)
                {
                    StartCoroutine(MoveCamera.Instance.DoMoveCamera(rightSideObject));
                    _leftGame.SetActive(true);
                    _rightGame.SetActive(false);
                }
            }
            else
            {
                if (!MoveCamera.Instance.move)
                {
                    StartCoroutine(MoveCamera.Instance.DoMoveCamera(leftSideObject));
                    _leftGame.SetActive(false);
                    _rightGame.SetActive(true);
                }
            }
    }
}
