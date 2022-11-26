using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBarOption : MonoSingleton<SpeedBarOption>
{
    public bool touchInScreen;
    bool firstTouch;
    Touch touch;

    void Update()
    {
        if (Input.touchCount > 0 && MoveCamera.Instance.rightSidePos)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                firstTouch = true;
                StartCoroutine(TrueFalse());
            }
            if (touch.phase == TouchPhase.Ended)
                firstTouch = false;
        }
    }

    IEnumerator TrueFalse()
    {
        if (!PlayerPrefs.HasKey("firstGameTap"))
        {
            PlayerPrefs.SetInt("firstGameTap", 1);
            Buttons.Instance.tapTutorial.SetActive(false);
        }
        touchInScreen = true;
        yield return new WaitForSeconds(0.6f);
        if (!firstTouch)
            touchInScreen = false;
    }
}
