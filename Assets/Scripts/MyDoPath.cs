using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MyDoPath : MonoBehaviour
{
    List<Vector3> HG = new List<Vector3>();
    private void Start()
    {
        GetComponent<DOTweenPath>().wps = HG;
    }
}
