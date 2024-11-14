
using UnityEngine;
using DG.Tweening;

public class CamFollow : MonoBehaviour
{
    public Transform target; // Target to follow
    public Vector3 targetLastPos, ofsset;
    public float speed_cam;
    Tweener tween;
    public Ease ease;
    public bool is_active;


    private void OnEnable()
    {
        Observer.AddObserver(ListAction.SpawnPlayer, start_follow);
    }
    void Start()
    {
        
    }

    //private void FixedUpdate()
    //{
    //    if (!is_active) return;

    //    //if (targetLastPos == target.position) return;

    //    Vector3 distance = target.position + ofsset;
    //    //distance.x = 0;

    //    tween.ChangeEndValue(distance, true).Restart();

    //}
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
        if (target != null)
        {
            ofsset = transform.position - target.position;

            Vector3 distance = target.position + ofsset;
            //distance.x = 0;

            tween = transform.DOMove(distance, speed_cam).SetEase(ease).SetAutoKill(false);
            //targetLastPos = distance;

            is_active = true;
        }
    }
    private void OnDestroy()
    {
        Observer.RemoveObserver(ListAction.SpawnPlayer, start_follow);
    }
}