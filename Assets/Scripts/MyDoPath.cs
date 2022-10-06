using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MyDoPath : MonoSingleton<MyDoPath>
{
    public List<float> length = new List<float>();
    public DOTweenPath pat;
    public List<GameObject> Balls = new List<GameObject>();
    private void Awake()
    {
        pat = Balls[0].GetComponent<DOTweenPath>();
    }
}
