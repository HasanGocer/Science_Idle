using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSystem : MonoBehaviour
{
    [SerializeField] private int _maxRandom›nteger;

    public void HG()
    {

    }

    IEnumerator RandomEvenent(int maxRandom›nteger)
    {
        int range = Random.Range(0, maxRandom›nteger);

        if (range < 10)
        {
            HG();
        }
        else if (range < 20)
        {
            HG();
        }

        yield return null;
    }
}
