using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRoad : Singleton<LineRoad>
{
    public CharacterController character;
    public PlayerFly playerFly;
    //[SerializeField] private HookControl hookControl;
    public List<Transform> positions;
    public Vector3[] path;
    public PathMode path_mode;
    public PathType path_type;
    public float duration;
    public bool isFly;
    //private void OnEnable()
    //{
    //    foreach (Transform posChild in transform)
    //    {
    //        positions.Add(posChild);
    //    }
    //}

    private void Start()
    {
        convert_transform_to_vectors();
        character = GameObject.FindGameObjectWithTag(Const.playerTag).GetComponent<CharacterController>();
        playerFly = GameObject.FindGameObjectWithTag(Const.playerTag).GetComponent<PlayerFly>();
    }

    //private void OnTriggerEnter(Collider line)
    //{
    //    if (line.CompareTag(Const.playerTag))
    //    {
    //        if (!isFly)
    //        {
    //            Observer.Notify(ActionInGame.ControlHook, path, duration, path_type, path_mode);
    //            isFly = true;
    //            //character.enabled = false;
    //            //playerFly.enabled = true;
    //            character.anim.SetTrigger(Const.flyAnim);
    //            character.gameObject.transform.DOPath(path, duration, path_type, path_mode, 10, Color.red).OnComplete(() =>
    //            {
    //                character.anim.SetTrigger(Const.runAnim);
    //                //character.enabled = true;
    //                //playerFly.enabled = false;
    //                character.gameObject.transform.DORotate(new Vector3(0, 0, 0), 0.1f);
    //                this.enabled = false;
    //            });
    //        }
    //    }
    //}

    void convert_transform_to_vectors()
    {
        path = new Vector3[positions.Count];

        for (int i = 0; i < positions.Count; i++)
        {
            path[i] = new Vector3(positions[i].position.x, positions[i].position.y, positions[i].position.z + 0.5f);
        }
    }
}
