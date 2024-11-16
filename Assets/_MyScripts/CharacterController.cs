using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private Animator anim;
    protected Rigidbody rb;
    public bool game_run/*, do_makeUp*/, is_finish;
    public float speed_player, horizontal_speed;
    protected Vector2 presspos, actualpos, pressSlowMotion;
    protected Vector3 mvm;


    public string animName = Const.runAnim;
    private void OnEnable()
    {
        Observer.AddObserver(ListAction.SetAimmator, SetAnimator);
        Observer.AddObserver(ListAction.ChangeAnim, ChangeStatusAnim);
        Observer.AddObserver(ListAction.GameRun, StatusGame);
        Observer.AddObserver(ListAction.FinishGame,EndRoad);
    }
    private void Start()
    {
#if UNITY_EDITOR
        horizontal_speed = 1f;
#endif
        rb = GetComponent<Rigidbody>();
    }
    // Thêm biến để điều chỉnh độ nhạy
    [SerializeField] private float sensitivity = 0.5f;
    private void Update()
    {
        player_movements();
    }
    void player_movements()
    {
        if (game_run)
        {
            // Player move forward
            transform.Translate(transform.forward * speed_player * Time.deltaTime);

            // Player move right & left
            if (Input.GetMouseButtonDown(0))
            {
                presspos = Input.mousePosition;
            }

            if (Input.GetMouseButton(0))
            {
                actualpos = Input.mousePosition;

                Vector3 tmp = transform.position;

                // Tính toán độ chênh lệch x
                float xdiff = (actualpos.x - presspos.x) * Time.smoothDeltaTime * horizontal_speed * sensitivity;

                tmp.x += xdiff;
                tmp.x = Mathf.Clamp(tmp.x, -2.5f, 2.5f); // Giảm khoảng giới hạn nếu cần
                transform.position = tmp;

                presspos = actualpos;
            }

            if (Input.GetMouseButtonUp(0))
            {
                mvm = Vector3.zero;
            }
        }
    }


    public void SetAnimator(object[] datas)
    {
        if (datas == null || datas.Length < 1 || !(datas[0] is Animator animPlayer)) return;
        anim = animPlayer;
    }

    public void ChangeStatusAnim(object[] datas)
    {
        if(datas == null || datas.Length < 1 || !(datas[0] is string animChange)) return;
        if (anim != null)
        {
            if (animChange != animName)
                anim.ResetTrigger(animName);
            animName = animChange;
            anim.SetTrigger(animName);
        }
    }

    public void StatusGame(object[] datas)
    {
        if (datas == null || datas.Length < 1 || !(datas[0] is bool active)) return;
        game_run = active;
    }
    public void EndRoad(object[] datas)
    {
        if (datas == null || datas.Length < 1 || !(datas[0] is bool active)) return;
        is_finish = active;
    }
    public void OnDestroy()
    {
        Observer.RemoveObserver(ListAction.SetAimmator, SetAnimator);
        Observer.RemoveObserver(ListAction.ChangeAnim,ChangeStatusAnim);
        Observer.RemoveObserver(ListAction.GameRun,StatusGame);
        Observer.RemoveObserver(ListAction.GameRun, EndRoad);
    }
}
