using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CharacterController : MonoBehaviour
{
    public Animator anim;
    [SerializeField] private float sensitivity;
    protected Rigidbody rb;
    public bool game_run, is_finish;
    public float speed_player, horizontal_speed;
    protected Vector2 firstClick, currentHandPoint, pressSlowMotion;
    protected Vector3 mvm;
    public float time;
    public bool isFly;
    public string animName = Const.runAnim;
    private void OnEnable()
    {
        Observer.AddObserver(ListAction.SetAimmator, SetAnimator);
        Observer.AddObserver(ListAction.ChangeAnim, ChangeStatusAnim);
        Observer.AddObserver(ListAction.GameRun, StatusGame);
        Observer.AddObserver(ListAction.FinishGame, RotateWin);
        Observer.AddObserver(ListAction.FinishMove, move_player_to_center_finish_level);
        Observer.AddObserver(ActionInGame.PlayerFly, Move_player_to_center_fly);
    }
    private void Start()
    {
        enabled = true;
#if UNITY_EDITOR
        horizontal_speed = 35f;
        speed_player = 5f;
#endif
        rb = GetComponent<Rigidbody>();
    }
    // Thêm biến để điều chỉnh độ nhạy

    private void Update()
    {
        player_movements2();
    }

    protected void player_movements2()
    {
        if (game_run)
        {
            // Player move forward
            transform.Translate(transform.forward * speed_player * Time.deltaTime);

            if (!is_finish && !isFly)
            {
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
    }

    public void RotateWin(object[] datas)
    {
        //transform.DORotate(new Vector3(0, transform.eulerAngles.y + 180, 0), 0.1f).SetEase(Ease.Linear)
        //    .OnComplete(() =>
        //{
        transform.SetParent(MoneyTower.inst.gameObject.transform);
        transform.localRotation = Quaternion.Euler(0, 0, 0);
        anim.SetTrigger(Const.flyIdleAnim);
        Observer.Notify(ActionInGame.MoneyTower, anim);
        //});
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
        is_finish = true;
        anim.SetTrigger(Const.walkAnim);
        speed_player = 5f;
        transform.DOKill();
        transform.DOLocalMoveX(-.2f, .1f);
    }

    public void Move_player_to_center_fly(object[] datas)
    {
        if (datas == null || datas.Length < 4) return;

        // Khởi tạo các biến
        //Vector3[] path = null;
        float duration = 0f;
        PathMode path_mode = PathMode.Full3D;
        PathType path_type = PathType.CatmullRom;

        // Kiểm tra và gán giá trị từ mảng datas
        if (!(datas[0] is Vector3[] paths)) return;
        if (datas[1] is float dur) duration = dur;
        if (datas[2] is PathMode mode) path_mode = mode;
        if (datas[3] is PathType type) path_type = type;

        // Nếu bất kỳ biến nào không được gán đúng, dừng lại
        if (paths == null || duration <= 0f) return;

        // Logic di chuyển
        isFly = true;
        anim.SetTrigger(Const.flyAnim);
        //speed_player = 5f;
        transform.DOKill();
        transform.DOPath(paths, duration, path_type, path_mode, 10, Color.red)
           .OnComplete(() =>
           {
               anim.SetTrigger(Const.runAnim);
               isFly = false;
           });
        Debug.Log("Fly");
    }

    public void StatusGame(object[] datas)
    {
        if (datas == null || datas.Length < 1 || !(datas[0] is bool active)) return;
        game_run = active;
    }
    public void OnDestroy()
    {
        Observer.RemoveObserver(ListAction.FinishMove, move_player_to_center_finish_level);
        Observer.RemoveObserver(ListAction.SetAimmator, SetAnimator);
        Observer.RemoveObserver(ListAction.ChangeAnim, ChangeStatusAnim);
        Observer.RemoveObserver(ListAction.GameRun, StatusGame);
        Observer.RemoveObserver(ListAction.GameRun, RotateWin);
        Observer.RemoveObserver(ActionInGame.PlayerFly, Move_player_to_center_fly);
    }
}
