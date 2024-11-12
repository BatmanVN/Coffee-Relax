using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLevel : MonoBehaviour
{
    public Transform[] positions;
    public GameObject[] women;

    Controller_Items controller_brush_script;
    bool active = true;
    //public Transform controller_trans;

    // Start is called before the first frame update
    void Start()
    {
        //manage_positions();
        //instantiate_women();
    }
    
    //When Finish
    private void OnTriggerEnter(Collider finish)
    {
        if (finish.CompareTag(Const.playerTag))
        {
            active = false;

            Observer.Notify(ListAction.FinishGame,true);

            //Controller_Brush.instance.do_makeUp = true;

            Controller_Items.instance.move_all_to_center_finish_level();

            UiManager.instance.show_multiplication(Controller_Items.instance.total_items);


            //// makeUp
            //float z_controller = controller_trans.position.z + 3f;

            //controller_trans.DOMoveZ(z_controller)
        }
    }

    //void instantiate_women()
    //{
    //    for (int i = 0; i < positions.Length; i++)
    //    {
    //        int nbr = Random.Range(0, women.Length);
    //        Instantiate(women[nbr], positions[i].position, women[nbr].transform.rotation);
    //    }
    //}

    //void manage_positions()
    //{
    //    int dist = 3;
    //    for (int i = 0; i < positions.Length; i++)
    //    {
    //        Vector3 tmp = positions[i].localPosition;
    //        tmp.z = dist;
    //        positions[i].localPosition = tmp;
    //        dist += 3;
    //    }
    //}
}
