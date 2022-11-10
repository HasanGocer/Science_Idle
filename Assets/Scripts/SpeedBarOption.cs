using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBarOption : MonoSingleton<SpeedBarOption>
{
    public bool touchInScreen;
    Touch touch;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                touchInScreen = true;
            }
            if (touch.phase == TouchPhase.Ended)
            {
                touchInScreen = false;
            }
        }
    }
}
