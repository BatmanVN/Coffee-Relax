using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListPosFinish : Singleton<ListPosFinish>
{
    public List<Transform> listPos;

    private void OnEnable()
    {
        foreach (Transform t in transform)
        {
            listPos.Add(t);
        }
    }
}
