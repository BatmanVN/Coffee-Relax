using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private float sensitivity = 0.5f;
    protected Rigidbody rb;
    public bool game_run, is_finish;
    public float speed_player, horizontal_speed;
    protected Vector2 firstClick, currentHandPoint, pressSlowMotion;
    protected Vector3 mvm;
    public float time;

    public string animName = Const.runAnim;
    private void OnEnable()
    {
        Observer.AddObserver(ListAction.SetAimmator, SetAnimator);
        Observer.AddObserver(ListAction.ChangeAnim, ChangeStatusAnim);
        Observer.AddObserver(ListAction.GameRun, StatusGame);
        Observer.AddObserver(ListAction.FinishGame, RotateWin);
        Observer.AddObserver(ListAction.FinishMove, move_player_to_center_finish_level);
    }
    private void Start()
    {
#if UNITY_EDITOR
        horizontal_speed = 15f;
        speed_player = 10f;
#endif
        rb = GetComponent<Rigidbody>();
    }
    // Thêm biến để điều chỉnh độ nhạy

    private void Update()
    {
        player_movements2();
    }
    protected void player_movements1()
    {
        if (game_run)
        {
            // Player move forward
            transform.Translate(transform.forward * speed_player * Time.deltaTime);

            // Player move right & left
            if (Input.GetMouseButtonDown(0))
            {
                firstClick = Input.mousePosition;
            }

            if (Input.GetMouseButton(0))
            {
                currentHandPoint = Input.mousePosition;

                Vector3 tmp = transform.position;

                // Tính toán độ chênh lệch x
                float xdiff = (currentHandPoint.x - firstClick.x) * Time.smoothDeltaTime * horizontal_speed * sensitivity;

                //tmp.x += xdiff;
                tmp.x = Mathf.Lerp(tmp.x, tmp.x + xdiff, Time.deltaTime * horizontal_speed);
                tmp.x = Mathf.Clamp(tmp.x, -3f, 3f); // Giảm khoảng giới hạn nếu cần
                transform.position = tmp;


                firstClick = currentHandPoint;
            }

            if (Input.GetMouseButtonUp(0))
            {
                mvm = Vector3.zero;
            }
        }
    }

    protected void player_movements2()
    {
        if (game_run)
        {
            // Player move forward
            transform.Translate(transform.forward * speed_player * Time.deltaTime);

            // Player move right & left
            if (Input.GetMouseButtonDown(0))
            {
                firstClick = Input.mousePosition;
            }

            if (Input.GetMouseButton(0))
            {
                currentHandPoint = Input.mousePosition;

                Vector3 targetX = transform.position;
                // Tính toán độ chênh lệch x
                float xdiff = (currentHandPoint.x - firstClick.x) * Time.smoothDeltaTime * horizontal_speed * sensitivity;

                // Tính toán vị trí mới
                targetX.x += xdiff;
                targetX.x = Mathf.Clamp(targetX.x, -3f, 3f); // Giới hạn phạm vi di chuyển

                // Sử dụng DoTween để di chuyển mượt mà
                /*transform.DOKill();*/ // Dừng tất cả tween trước đó nếu có
                transform.DOLocalMoveX(targetX.x, time);/*.SetEase(Ease.InOutQuad);*/ // Di chuyển nhân vật đến vị trí targetX trong 0.2 giây

                firstClick = currentHandPoint; // Cập nhật vị trí nhấn chuột
            }

            if (Input.GetMouseButtonUp(0))
            {
                mvm = Vector3.zero;
            }
        }
    }

    public void RotateWin(object[] datas)
    {
        transform.DORotate(new Vector3(0, transform.eulerAngles.y + 180, 0), 0.1f).SetEase(Ease.Linear)
            .OnComplete(() =>
        {
            anim.SetTrigger(Const.victoryAnim);
        });
        speed_player = 0f;
    }

    public void SetAnimator(object[] datas)
    {
        if (datas == null || datas.Length < 1 || !(datas[0] is Animator animPlayer)) return;
        anim = animPlayer;
    }

    public void ChangeStatusAnim(object[] datas)
    {
        if (datas == null || datas.Length < 1 || !(datas[0] is string animChange)) return;
        if (anim != null)
        {
            if (animChange != animName)
                anim.ResetTrigger(animName);
            animName = animChange;
            anim.SetTrigger(animName);
        }
    }
    public void move_player_to_center_finish_level(object[] datas)
    {
            transform.DOMoveX(0f, .4f);
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
        Observer.RemoveObserver(ListAction.FinishMove,move_player_to_center_finish_level);
        Observer.RemoveObserver(ListAction.SetAimmator, SetAnimator);
        Observer.RemoveObserver(ListAction.ChangeAnim, ChangeStatusAnim);
        Observer.RemoveObserver(ListAction.GameRun, StatusGame);
        Observer.RemoveObserver(ListAction.GameRun, RotateWin);
    }
}
