using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseThrownTrap : MonoBehaviour
{
    public Animator anim;
    public List<Transform> positions;
    public Vector3[] path;
    public PathMode path_mode;
    public PathType path_type;
    public float duration;
    public bool isThrowed;

    protected virtual void OnEnable()
    {
        foreach (Transform posChild in transform)
        {
            positions.Add(posChild);
        }
    }
    protected virtual void Start()
    {
        convert_transform_to_vectors();
    }

    protected virtual void convert_transform_to_vectors()
    {
        path = new Vector3[positions.Count];

        for (int i = 0; i < positions.Count; i++)
        {
            path[i] = new Vector3(positions[i].position.x, positions[i].position.y, positions[i].position.z + 0.5f);
        }
    }

}
