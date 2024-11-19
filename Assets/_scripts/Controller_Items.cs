using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Controller_Items : Singleton<Controller_Items>
{
    public int count_items, total_items;
    // list cup
    public List<Transform> list_item;
    protected Vector3 velocity = Vector3.zero;
    //public int currentItemTotal, afterDecreaseitem;
    public float smooth_speed, correct_smooth;

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
        //total_items++;
        if (count_items >= list_item.Count) return;
        list_item[count_items].gameObject.SetActive(true);
        foreach (CupType cupType in list_item[count_items].GetComponent<CupGroup>().cupTypes)
        {
            cupType.gameObject.SetActive(false);
            list_item[count_items].GetComponent<CupGroup>().item_Type = Item_type.Cup;
        }
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
        //total_items--;
    }
    public int GetTotalCup()
    {
        return total_items;
    }

    //public void move_all_to_center_finish_level()
    //{
    //    for (int i = 0; i < list_item.Count; i++)
    //    {
    //        list_item[i].DOMoveX(0f, .1f);
    //    }
    //}
}
