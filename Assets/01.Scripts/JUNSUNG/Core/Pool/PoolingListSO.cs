using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PoolingPair
{
    public int CreateCount;
    public PoolableMono obj;
}

[CreateAssetMenu(menuName ="SO/PoolingListSO")]
public class PoolingListSO : ScriptableObject
{
    public List<PoolingPair> poolingObjs = new List<PoolingPair>();
}
