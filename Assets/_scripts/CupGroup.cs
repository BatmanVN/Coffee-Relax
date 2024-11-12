using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class CupGroup : GameUnit
{
    Sequence sequence;
    //public makeUp_type makeUp_type;
    public Ease ease_bounce , ease_linear;
    public float time;
    //public GameObject brush;
    //public bool clean = true, has_mascara, has_lipstick;
    //public SkinnedMeshRenderer brush_top_mat, brush_down_mat;
    //public MeshRenderer mascara_mat, lipstick_mat;

    //public Material[] brush_mat_list;
    //public GameObject fly_effect, skull_effect;
    //public Material[] brush_materials, lipstick_materials, mascara_materials;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    

    public void animate_group_brush()
    {
        sequence = DOTween.Sequence();
        float pos_y_old = transform.localPosition.y;
        float pos_y_new = transform.localPosition.y + .5f;

        sequence

                    .Append(transform.DOLocalMoveY(pos_y_new, time).SetEase(ease_linear))
                    .Append(transform.DOLocalMoveY(pos_y_old, time).SetEase(ease_bounce));
    }

    //public void color_brush(pipe_colors clr)
    //{
    //    animate_group_brush();

    //    if (clr == pipe_colors.pink)
    //    {
    //        brush_top_mat.material = brush_mat_list[0];
    //    }
    //    else if (clr == pipe_colors.red)
    //    {
    //        brush_top_mat.material = brush_mat_list[1];
    //    }
    //    else if (clr == pipe_colors.yellow)
    //    {
    //        brush_top_mat.material = brush_mat_list[2];
    //    }
    //    else if (clr == pipe_colors.blue)
    //    {
    //        brush_top_mat.material = brush_mat_list[3];
    //    }
    //    else if (clr == pipe_colors.green)
    //    {
    //        // reset 
    //        skull_effect.SetActive(false);
    //        fly_effect.SetActive(false);

    //        //active skull_effect
    //        skull_effect.SetActive(true);
    //        brush_top_mat.material = brush_mat_list[4];
    //        clean = false;
    //    }
    //    else if (clr == pipe_colors.maron)
    //    {
    //        // reset 
    //        skull_effect.SetActive(false);
    //        fly_effect.SetActive(false);

    //        //active fly_effect
    //        fly_effect.SetActive(true);
    //        brush_top_mat.material = brush_mat_list[5];
    //        clean = false;
    //    }
    //}
    //public void clean_brush()
    //{
    //    animate_group_brush();

    //    // reset 
    //    skull_effect.SetActive(false);
    //    fly_effect.SetActive(false);

    //    brush_top_mat.material = brush_mat_list[6];
    //    clean = true;
    //}

    //public void upgrate_to_simple()
    //{
    //    animate_group_brush();

    //    makeUp_type = makeUp_type.simple;

    //    brush_down_mat.material = brush_materials[0];

    //    if (has_mascara)
    //    {
    //        mascara_mat.material = mascara_materials[0];
    //    }
    //    if (has_lipstick)
    //    {
    //        lipstick_mat.materials[0] = lipstick_materials[0];
    //        lipstick_mat.materials[1] = lipstick_materials[0];
    //    }
    //}

    //public void upgrate_to_dior()
    //{
    //    animate_group_brush();

    //    makeUp_type = makeUp_type.dior;

    //    brush_down_mat.material = brush_materials[1];

    //    if (has_mascara)
    //    {
    //        mascara_mat.material = mascara_materials[1];
    //    }
    //    if (has_lipstick)
    //    {
    //        print("has lips");
    //        Material[] tmp_mat = lipstick_mat.materials;
    //        tmp_mat[0] = tmp_mat[1] = lipstick_materials[1];

    //        lipstick_mat.materials = tmp_mat;
    //    }
    //}

    //public void upgrate_to_chanel()
    //{
    //    animate_group_brush();

    //    makeUp_type = makeUp_type.chanel;

    //    brush_down_mat.material = brush_materials[2];

    //    if (has_mascara)
    //    {
    //        mascara_mat.material = mascara_materials[2];
    //    }
    //    if (has_lipstick)
    //    {
    //        print("has lips");

    //        Material[] tmp_mat = lipstick_mat.materials;
    //        tmp_mat[0] = tmp_mat[1] = lipstick_materials[2];

    //        lipstick_mat.materials = tmp_mat;

    //    }
    //}

    
}
