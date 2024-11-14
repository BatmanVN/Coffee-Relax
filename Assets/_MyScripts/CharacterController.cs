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
    private void OnValidate() => anim = GetComponentInChildren<Animator>();
    private void OnEnable()
    {
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
    private void Update()
    {
        player_movements();
    }
    void player_movements()
    {
        if (/*!do_makeUp &&*/ game_run)
        {
            //player move forward
            transform.Translate(transform.forward * speed_player * Time.deltaTime);

            // player move right & left
            if (Input.GetMouseButtonDown(0))
            {
                presspos = Input.mousePosition;
            }

            if (Input.GetMouseButton(0)/* && is_tap*/)
            {
                //actualpos = Input.mousePosition;

                //mvm = new Vector3(Input.GetAxis("Mouse X"), 0f, 0f) * Time.smoothDeltaTime * horizontal_speed;
                //Vector3 tmp = list_brushes[0].position;

                //tmp.x += mvm.x;
                //tmp.x = Mathf.Clamp(tmp.x, -3, 3);
                //list_brushes[0].position = tmp;

                //presspos = actualpos;

                actualpos = Input.mousePosition;

                //mvm = new Vector3(Input.GetAxis("Mouse X"), 0f, 0f) * Time.smoothDeltaTime * horizontal_speed;
                Vector3 tmp = transform.position;

                float xdiff = (actualpos.x - presspos.x) * Time.smoothDeltaTime * horizontal_speed;

                tmp.x += xdiff;
                tmp.x = Mathf.Clamp(tmp.x, -3, 3);
                transform.position = tmp;

                presspos = actualpos;
            }

            if (Input.GetMouseButtonUp(0))
            {
                mvm = Vector3.zero;
            }

        }

    }
    public void ChangeStatusAnim(object[] datas)
    {
        if(datas == null || datas.Length < 1 || !(datas[0] is string animChange)) return;
        if(animChange != animName)
            anim.ResetTrigger(animName);
        animName = animChange;
        anim.SetTrigger(animName);
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
        Observer.RemoveObserver(ListAction.ChangeAnim,ChangeStatusAnim);
        Observer.RemoveObserver(ListAction.GameRun,StatusGame);
        Observer.RemoveObserver(ListAction.GameRun, EndRoad);
    }
}
