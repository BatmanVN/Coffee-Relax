
using UnityEngine;
using DG.Tweening;

public class CamFollow : Singleton<CamFollow>
{
    public Transform target; // Target to follow
    public Vector3 targetLastPos, ofsset;
    public float speed_cam;
    Tweener tween;
    public Ease ease;
    public bool is_active;


    private void OnEnable()
    {
        Observer.AddObserver(ListAction.SetCamFollow, start_follow);
    }
    void Start()
    {
        
    }
    void LateUpdate()
    {
        //transform.position = Vector3.Lerp(transform.position, ofsset, Time.deltaTime * speed_cam);
    }

    void Update()
    {
        if (!is_active) return;

        //if (targetLastPos == target.position) return;
        if (target != null)
        {
            Vector3 distance = target.position + ofsset;
            //distance.x = 0;

            tween.ChangeEndValue(distance, true).Restart();
            //targetLastPos = distance;
        }
    }

    public void start_follow(object[] datas)
    {
        if(datas == null || datas.Length <1 || !(datas[0] is Transform player)) return;
        target = player;
        if (target != null)
        {
            tween = transform.DOMove(ofsset, speed_cam).SetEase(ease).SetAutoKill(false);
            is_active = true;
        }
    }
    private void OnDestroy()
    {
        Observer.RemoveObserver(ListAction.SetCamFollow, start_follow);
    }
}