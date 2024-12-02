using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFly : MonoBehaviour
{
    [SerializeField] private float sensitivity;
    //[SerializeField] private float minX, maxX;
    public float horizontal_speed;
    protected Vector2 firstClick, currentHandPoint, pressSlowMotion;
    protected Vector3 mvm;
    public float time;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MovementOnRail();
    }

    private void MovementOnRail()
    {
        if (!LineRoad.Ins.isFly) return;

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

}