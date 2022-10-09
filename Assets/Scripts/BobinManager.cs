using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobinManager : MonoSingleton<BobinManager>
{
    public List<GameObject> bobins = new List<GameObject>();

    public void StartBobinPlacement()
    {
        for (int i = 0; i < ItemData.Instance.field.bobinCount; i++)
        {
            bobins[i].SetActive(true);
        }
    }
}
