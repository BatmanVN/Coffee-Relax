using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookControl : MonoBehaviour
{
    [SerializeField] private float sensitivity;
    public float horizontal_speed;
    public float time;

    protected Vector2 firstClick, currentHandPoint, pressSlowMotion;
    private void OnEnable()
    {
        Observer.AddObserver(ActionInGame.ControlHook, ControlHook);
    }

    private void Update()
    {
        RotateHook();
    }

    protected void RotateHook()
    {
        if (Input.GetMouseButtonDown(0))
            firstClick = Input.mousePosition;

        if (Input.GetMouseButton(0))
        {
            currentHandPoint = Input.mousePosition;
            Vector3 newDirectionY = transform.position;

            float distanceClick = (currentHandPoint.x - firstClick.x) * Time.smoothDeltaTime * horizontal_speed * sensitivity;

            newDirectionY.z += distanceClick;
            transform.DOLocalRotate(new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y,newDirectionY.z),time);
            firstClick = currentHandPoint;
        }
    }

    public void ControlHook(object[] datas)
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

        transform.DOKill();
        transform.DOPath(paths, duration, path_type, path_mode, 10, Color.red)
           .OnComplete(() =>
           {
               LineRoad.Ins.character.GetComponent<CharacterController>().enabled = true;
               this.enabled = false;
           });
    }

    private void OnDestroy()
    {
        Observer.RemoveObserver(ActionInGame.ControlHook, ControlHook);
    }
}
