using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRoad : Singleton<LineRoad>
{
    public GameObject character;
    [SerializeField] private HookControl hookControl;
    public List<Transform> positions;
    public Vector3[] path;
    public PathMode path_mode;
    public PathType path_type;
    public float duration;

    private void OnEnable()
    {
        foreach (Transform posChild in transform)
        {
            positions.Add(posChild);
        }
    }

    private void Start()
    {
        convert_transform_to_vectors();
    }

    private void OnTriggerEnter(Collider line)
    {
        if (line.CompareTag(Const.playerTag))
        {
            hookControl.enabled = true;
            Observer.Notify(ActionInGame.ControlHook, path, duration, path_type, path_mode);
            character = line.GetComponent<CharacterController>().gameObject;
            character.transform.SetParent(hookControl.transform);
            character.GetComponent<CharacterController>().enabled = false;
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
