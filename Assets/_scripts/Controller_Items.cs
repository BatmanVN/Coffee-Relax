using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Controller_Items : MonoBehaviour
{
    public static Controller_Items instance;
    public int count_items, total_items;
    // list cup
    public List<Transform> list_item;
    protected Vector3 velocity = Vector3.zero;

    public float smooth_speed, correct_smooth;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform)
        {
            if (child.GetComponent<CupGroup>())
            {
                list_item.Add(child);
            }
        }
        //anim_brushes_position();
    }

    // Update is called once per frame
    void Update()
    {
        anim_items_position();
    }

    void FixedUpdate()
    {
        //player_movements();
    }


    public void CheckCupCoffee()
    {
        
    }

    void anim_items_position()
    {
            for (int i = 1; i < list_item.Count; i++)
            {
                Vector3 tmp_pos = list_item[i - 1].position;
                tmp_pos.z = list_item[i].position.z;
                list_item[i].position = Vector3.SmoothDamp(list_item[i].position, tmp_pos, ref velocity, smooth_speed + i / correct_smooth);
            }
    }

    public void Increase_item()
    {
        count_items++;
        total_items++;
        if (count_items >= list_item.Count) return;
        list_item[count_items].gameObject.SetActive(true);
        
        //    //animate group
        list_item[count_items].GetComponent<CupGroup>().animate_group_item();
    }

    public void decrease_item()
    {
        if (count_items > 0)
        {
            list_item[count_items].gameObject.SetActive(false);
            count_items--;
        }
        total_items--;
    }

    public void move_forward_in_make_up()
    {
        //Vector3 tmp = transform.position;
        //transform.position += Vector3.forward;
        Vector3 tmp = transform.position;
        tmp.z += 1f;

        transform.DOMoveZ(tmp.z, .5f);
    }

    public void move_horizontal_in_makeUp(Vector3 new_pos)
    {
        //Vector3 tmp = list_brushes[0].position;
        //tmp.x = new_pos.x;

        list_item[0].DOMoveX(new_pos.x, .3f);

        //list_brushes[0].position = tmp;
    }

    public void move_all_to_center_finish_level()
    {
        for (int i = 0; i < list_item.Count; i++)
        {
            list_item[i].DOMoveX(0f, .4f);
        }
    }
}
