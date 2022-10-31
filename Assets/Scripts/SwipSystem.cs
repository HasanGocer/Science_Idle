using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipSystem : MonoSingleton<SwipSystem>
{
    Touch touch;
    float vec2Start, vec2Finish;
    bool moved;

    public GameObject leftSideObject;
    public GameObject rightSideObject;

    [SerializeField] private GameObject _leftGame;
    [SerializeField] private GameObject _rightGame;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    vec2Start = touch.position.x;
                    break;

                case TouchPhase.Moved:
                    moved = true;

                    break;

                case TouchPhase.Ended:
                    vec2Finish = touch.position.x;
                    SwipSystemFunc(vec2Start, vec2Finish, moved);
                    moved = false;
                    break;
            }

        }
    }

    private void SwipSystemFunc(float start, float finish, bool moved)
    {
        Debug.Log("1");
        if (moved)
        {
            Debug.Log("2");
            if (finish - start < 0)
            {
                Debug.Log("3");
                if (!MoveCamera.Instance.move)
                {
                    Debug.Log("4");
                    MoveCamera.Instance.ResearchCameraNewPos();
                    Debug.Log("5");
                    _leftGame.SetActive(true);
                    _rightGame.SetActive(false);
                }
            }
            else
            {
                if (!MoveCamera.Instance.move)
                {
                    Debug.Log("6");
                    MoveCamera.Instance.MoneyCameraNewPos();
                    Debug.Log("7");
                    _leftGame.SetActive(false);
                    _rightGame.SetActive(true);
                }
            }
        }
    }
}
