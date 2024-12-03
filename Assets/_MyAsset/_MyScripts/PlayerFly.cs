using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;


public class PlayerFly : BaseCharacter
{
    public float time;
    public bool isFly;
    protected override void OnEnable()
    {
        base.OnEnable();
        Observer.AddObserver(ActionInGame.PlayerFly, Move_player_to_center_fly);
    }
    void Start()
    {

    }

    void Update()
    {
        //MovementOnRail();
    }
    public void Move_player_to_center_fly(object[] datas)
    {
        if (datas == null || datas.Length < 4) return;

        // Khởi tạo các biến
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
              transform.DORotate(new Vector3(0, 0, 0), 0.1f).OnComplete(() => isFly = false);
           });
    }
    public virtual void MovementOnRail()
    {
        if (!LineRoad.Ins.isFly) return;

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
            if (xdiff > 0)
            {
                transform.DORotate(new Vector3(0,-2.5f, -50),time);
            }
            if (xdiff < 0)
            {
                transform.DORotate(new Vector3(0, 2.5f, 50), time);
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            transform.DORotate(new Vector3(0,0,0), time);
            mvm = Vector3.zero;
        }
    }
    protected override void OnDestroy()
    {
        base.OnDestroy();
        Observer.RemoveObserver(ActionInGame.PlayerFly, Move_player_to_center_fly);
    }
}