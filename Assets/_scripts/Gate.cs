using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public Rigidbody[] lockglass_broken;
    public GameObject locked_glass , unlock_glass;
    public float power_break;
    public bool is_IceCream, is_Coffee;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Const.cupTag))
        {
            Observer.Notify(ListAction.Vibrate);
            //UiManager.instance._vibrate();
            //lipstick
            if (is_IceCream)
            {
                //check the gate



                //if (!Controller_Brush.instance.lipstick_)
                //{

                //    active lispstick
                //    Controller_Brush.instance.lipstick_ = true;

                //    get all brush object in scene
                //    CupGroup[] all_brush_obj = FindObjectsOfType<CupGroup>();

                //    break glass
                //    break_glass();

                //    show lipstik in all brush objects
                //    foreach (var br in all_brush_obj)
                //    {
                //        br.show_lipstick();
                //    }
                //}
                // add element to make up group
                other.transform.GetChild(2).gameObject.SetActive(true);
                other.GetComponent<CupGroup>().animate_group_brush();

                // active lipstick on brush Group
                //other.GetComponent<BrushGroup>().has_lipstick = true;
            }
            //mascara
            else if (is_Coffee)
            {
                //check the gate
                //// khass nzid lipstick awal itel fi group
                //if (!Controller_Brush.instance.mascara_)
                //{

                //    //active lispstick
                //    Controller_Brush.instance.mascara_ = true;

                //    //get all brush object in scene
                //    CupGroup[] all_brush_obj = FindObjectsOfType<CupGroup>();

                //    //break glass
                //    break_glass();

                //    // show lipstik in all brush objects
                //    foreach (var br in all_brush_obj)
                //    {
                //        //br.show_mascara();
                //    }
                //}
                // add element to make up group
                other.transform.GetChild(1).gameObject.SetActive(true);
                other.GetComponent<CupGroup>().animate_group_brush();

                // active mascara on brush Group
                //other.GetComponent<BrushGroup>().has_mascara = true;

            }
            
        }
    }

    void break_glass()
    {
        // innactive glass
        locked_glass.SetActive(false);

        //active glass broken
        unlock_glass.SetActive(true);

        // break glass
        for (int i = 0; i < lockglass_broken.Length; i++)
        {
            lockglass_broken[i].isKinematic = false;

            Vector3 shoot = new Vector3(Random.Range(-2, 2), Random.Range(2, 5), Random.Range(2, 6));
            lockglass_broken[i].AddForce(shoot * power_break, ForceMode.Impulse);
        }
    }
}
