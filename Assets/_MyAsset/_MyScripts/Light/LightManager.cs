using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    public List<LightEnd> lights;
    public List<GameObject> fireWorks;
    private Coroutine fireWork;
    void Start()
    {

    }
    private void OnTriggerEnter(Collider light)
    {
        if (light.CompareTag(Const.playerTag))
        {
            lights[0].gameObject.SetActive(true);
            lights[1].gameObject.SetActive(true);
        }
        if (light.CompareTag(Const.cupTag))
        {
            fireWorks[0].SetActive(true);
            fireWorks[1].SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(Const.playerTag))
        {
            fireWork = StartCoroutine(Disable());
        }
    }
    private IEnumerator Disable()
    {
        yield return new WaitForSeconds(2f);
        this.gameObject.SetActive(false);
        StopCoroutine(fireWork);
    }
}
