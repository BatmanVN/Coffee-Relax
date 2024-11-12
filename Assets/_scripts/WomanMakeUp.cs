//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using DG.Tweening;

//public class WomanMakeUp : MonoBehaviour
//{
//    public Material lips_beauty , hair_beauty , head_1, head_2 , head_3;
//    public MeshRenderer hair;
//    public SkinnedMeshRenderer hair_skinned , lips, head;
//    public GameObject lipstick, mascara, brush , poop;
//    public Animator anim , plus_25_txt_1 , plus_25_txt_2;

//    public TMPro.TextMeshPro step_text;
//    public int max_steps , count_steps , count_decrease_txt;
//    public int counter;
//    bool active = true , is_clean=true;

//    Sequence sequence;
//    public Ease ease_bounce, ease_linear;
//    public float time;
//    public GameObject dollar_blast_pref , confetti_pref;
//    public Transform dollar_pos , confetti_pos;

//    // Start is called before the first frame update
//    void Start()
//    {
//        max_steps = Random.Range(2, 5);

//        step_text.text = max_steps.ToString();
//        count_decrease_txt = max_steps;
//        anim = GetComponent<Animator>();
//        //lips_makeup();
//        //hair_makeUp();
//    }

//    private void Update()
//    {
//        //if (Input.GetMouseButtonDown(0))
//        //{
//        //    lips_makeup();
//        //    hair_makeUp();
//        //    Head_MakeUp();
//        //}
//    }
//    public void lips_makeup()
//    {
//        lipstick.SetActive(true);

//        lips.materials[1].DOColor(lips_beauty.color, 5f);
//    }

//    public void hair_makeUp()
//    {
//        if(hair != null)
//            hair.material.DOColor(hair_beauty.color, 5f);
//        else
//            hair_skinned.material.DOColor(hair_beauty.color, 5f);
//    }

//    public void Head_MakeUp()
//    {
//        //if(counter == 0)
//        //{
//        //    head.material = head_2;
//        //}
//        //else if(counter == 1)
//        //{
//        //    head.material = head_3;
//        //}

//        //counter++;
//    }

//    private void OnTriggerEnter(Collider other)
//    {
//        //if (other.CompareTag("brush") && Controller_Brush.instance.is_finish && active)
//        //{
//        //    //active = false;
//        //    BrushGroup br_gp = other.GetComponent<BrushGroup>();

//        //    StartCoroutine(MakeUp_Finish_Level(br_gp.clean, br_gp.has_mascara, br_gp.has_lipstick));
//        //}
//        //else if (other.CompareTag("brush") && active)
//        //{
//        //    //active = false;
//        //    BrushGroup br_gp = other.GetComponent<BrushGroup>();

//        //    StartCoroutine(do_makeUp_animate(br_gp.clean, br_gp.has_mascara, br_gp.has_lipstick));
//        //}
//    }

//    IEnumerator do_makeUp_animate(bool cln , bool has_mascara , bool has_lipstick)
//    {
//        UiManager.instance._vibrate();
//        count_steps++;
//        count_decrease_txt--;

//        Controller_Player.instance.decrease_item();

//        if (active)
//        {
//            active = false;
//        }
//        Controller_Player.instance.do_makeUp = true;
//        Controller_Player.instance.move_horizontal_in_makeUp(transform.position);
//        brush.SetActive(true);

//        if(hair_skinned != null)
//        {
//            hair_makeUp();
//        }
        

//        if (cln)
//        {
//            if (counter == 0)
//            {
//                head.material = head_2;
//            }
//            else if (counter == 1 && has_mascara)
//            {
//                head.material = head_3;
//            }

//            counter++;
//        }
//        else
//        {
//            is_clean = false;
//            counter = 0;
//            head.material = head_1;
//            poop.SetActive(true);
//        }
//        if (has_mascara)
//        {
//            mascara.SetActive(true);
//        }
//        if (has_lipstick)
//        {
//            lipstick.SetActive(true);
//            lips_makeup();
//        }

//        yield return new WaitForSeconds(.6f);

//        GameObject gm = Instantiate(dollar_blast_pref, dollar_pos.position, dollar_blast_pref.transform.rotation);
//        Destroy(gm, 4f);

//        UiManager.instance.increase_money(25f);

//        step_text.text = count_decrease_txt.ToString();
        

//        plus_25_txt_1.Play("plus_25");
//        plus_25_txt_2.Play("plus_25");

//        if (Controller_Player.instance.count_items > 0 && count_steps < max_steps)
//        {
            
//            Controller_Player.instance.move_forward_in_make_up();
//            StartCoroutine(do_makeUp_animate(cln, has_mascara, has_lipstick));
//        }
//        else
//        {
//            //make animation to woman
//            if (is_clean)
//                anim.Play("happy");
//            else
//                anim.Play("sad");

//            woman_animation_finish();
//            print("completed");
            
//            // contniue
//            Controller_Player.instance.do_makeUp = false;
//        }
//    }

//    void woman_animation_finish()
//    {
//        sequence = DOTween.Sequence();
//        float pos_y_old = transform.position.y;
//        float pos_y_new = transform.position.y + 2.5f;

//        sequence

//                    .Append(transform.DOLocalMoveY(pos_y_new, time).SetEase(ease_linear))
//                    .Append(transform.DOLocalMoveY(pos_y_old, time).SetEase(ease_bounce))
//                    .Append(transform.DOScale(0f , .3f).SetEase(ease_linear))
//                    .OnComplete(() => Destroy(gameObject));
//    }

//    public IEnumerator MakeUp_Finish_Level(bool cln, bool has_mascara, bool has_lipstick)
//    {
//        count_steps++;
//        UiManager.instance._vibrate();

//        if (active)
//        {
            
//            Controller_Player.instance.decrease_item();
//            active = false;
//            if (Controller_Player.instance.total_items <= 0)
//            {
//                Controller_Player.instance.game_run = false;
//                Controller_Player.instance.list_item[0].gameObject.SetActive(false);
//                // panel 
//                UiManager.instance.show_win();
//                // total brush nakhodha mn finish level . nbynha mli sali 
//            }
//        }
//        brush.SetActive(true);

//        if (hair_skinned != null)
//        {
//            hair_makeUp();
//        }


//        if (cln)
//        {
//            if (counter == 0)
//            {
//                head.material = head_2;
//            }
//            else if (counter == 1 && has_mascara)
//            {
//                head.material = head_3;
//            }

//            counter++;
//        }
//        else
//        {
//            is_clean = false;
//            counter = 0;
//            head.material = head_1;
//            poop.SetActive(true);
//        }
//        if (has_mascara)
//        {
//            mascara.SetActive(true);
//        }
//        if (has_lipstick)
//        {
//            lipstick.SetActive(true);
//            lips_makeup();
//        }

//        yield return new WaitForSeconds(.2f);
        
//        plus_25_txt_1.Play("plus_25");
//        plus_25_txt_2.Play("plus_25");

//        UiManager.instance.increase_money(25f);

//        GameObject gm = Instantiate(dollar_blast_pref, dollar_pos.position, dollar_blast_pref.transform.rotation);
//        Destroy(gm, 4f);

//        Vector3 tmp = dollar_pos.position;
//        tmp.y  += 4f;

//        GameObject gm_confetti = Instantiate(confetti_pref, tmp, confetti_pref.transform.rotation);

//        if (count_steps < max_steps)
//        {
//            StartCoroutine(MakeUp_Finish_Level(cln, has_mascara, has_lipstick));
//        }
//        else
//        {
//            //make animation to woman
//            if (is_clean)
//                anim.Play("happy");
//            else
//                anim.Play("sad");
            
//        }
//    }
//}
