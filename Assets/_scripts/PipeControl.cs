using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum pipe_colors
{
    pink,
    red,
    yellow,
    blue,
    maron,
    green
}
public class PipeControl : MonoBehaviour
{
    public pipe_colors color;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("brush"))
        {
            UiManager.instance._vibrate();
            print("color");
            //other.GetComponent<BrushGroup>().color_brush(color);
        }
    }
}
