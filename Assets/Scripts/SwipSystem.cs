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
<<<<<<< HEAD
                    break;

                case TouchPhase.Moved:
                    moved = true;

=======
                    Debug.Log("Began");
                    
                    break;

                case TouchPhase.Moved:

                    Debug.Log("Moved");
                    moved = true;
>>>>>>> 38988c5c1f7f2aa7b4b34089e6eaf1cdc800a45f
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
        if (moved)
        {
            if (finish - start > 0)
            {
                if (!MoveCamera.Instance.move)
                {
                    MoveCamera.Instance.ResearchCameraNewPos();
                    _leftGame.SetActive(true);
                    _rightGame.SetActive(false);
                }
            }
            else
            {
                if (!MoveCamera.Instance.move)
                {
                    MoveCamera.Instance.MoneyCameraNewPos();
                    _leftGame.SetActive(false);
                    _rightGame.SetActive(true);
                }
            }
        }
    }
}
