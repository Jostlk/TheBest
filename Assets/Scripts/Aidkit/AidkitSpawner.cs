using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AidkitSpawner : MonoBehaviour
{
    public List<Transform> AidkitList;
    public Aidkit AidkitPrefab;
    private Aidkit _aidkit;

    public float MinDelay;
    public float MaxDelay;
    void Update()
    {
        if (_aidkit != null) return;
        if (IsInvoking()) return;

        Invoke("CreateAidkit", Random.Range(MinDelay, MaxDelay));
    }
    public void CreateAidkit()
    {
        _aidkit = Instantiate(AidkitPrefab);
        _aidkit.transform.position = AidkitList[Random.Range(0, AidkitList.Count)].position;
    }
}
