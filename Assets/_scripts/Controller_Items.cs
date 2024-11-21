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
    public GameObject cupPrefabs;
    public int cupId;
    // Start is called before the first frame update
    private void OnEnable()
    {
        Observer.AddObserver(ListAction.GetPrefabCupID, GetPrefabID);
        Observer.AddObserver(ListAction.SpawnCupIns, SpawnCupInst);
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        anim_items_position();
    }

    void FixedUpdate()
    {

    }
    public void GetPrefabID(object[] datas)
    {
        cupId = GameControllManager.Ins.GetIDSkinCupUse();
        foreach (SkinCupItemData cup in GameControllManager.Ins.cupData.skinDatas)
        {
            if (cup.id == cupId)
            {
                cupPrefabs = cup.buckInst;
            }
        }
    }
    public void SpawnCupInst(object[] datas)
    {
        for (int i = 0; i < 26; i++)
        {
            GameObject cup = Instantiate(cupPrefabs, this.transform.position, this.transform.rotation);
            cup.transform.SetParent(this.transform);
            cup.transform.position = new Vector3(0, this.transform.position.y, this.transform.position.z + i);
            list_item.Add(cup.transform);
        }
    }
    void anim_items_position()
    {
        if (list_item.Count <= 0) return;
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
    private void OnDestroy()
    {
        Observer.RemoveObserver(ListAction.GetPrefabCupID, GetPrefabID);
        Observer.RemoveObserver(ListAction.SpawnCupIns, SpawnCupInst);
    }
}
