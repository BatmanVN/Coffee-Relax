using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrownPlayer : MonoBehaviour
{
    public Animator anim;
    public List<Transform> positions;
    public Vector3[] path;
    public PathMode path_mode;
    public PathType path_type;
    public float duration;
    public bool isThrowed;
    // Start is called before the first frame update
    private void OnEnable()
    {
        foreach (Transform posChild in transform)
        {
            positions.Add(posChild);
        }
    }
    void Start()
    {
        convert_transform_to_vectors();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Const.playerTag))
        {
            if (!isThrowed)
            {
                anim.SetTrigger(Const.throwTrapAnim);
                Observer.Notify(ListAction.Vibrate);

                Observer.Notify(ActionInGame.PlayerFly, path, duration, path_type, path_mode);
                isThrowed = true;
            }
            Debug.Log(other.gameObject.name);
        }
    }
    void convert_transform_to_vectors()
    {
        path = new Vector3[positions.Count];

        for (int i = 0; i < positions.Count; i++)
        {
            path[i] = new Vector3(positions[i].position.x, positions[i].position.y, positions[i].position.z + 0.5f);
        }
    }
}
