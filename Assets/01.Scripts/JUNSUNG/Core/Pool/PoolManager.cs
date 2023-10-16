using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance;

    private Dictionary<string, Pool> pools = new Dictionary<string, Pool>();

    [SerializeField]
    private PoolingListSO initPoolingList;

    private void Awake()
    {
        if(Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        
        CreatePoolingObjects(initPoolingList);
    }

    private void Start()
    {
    }

    public void CreatePoolingObjects(PoolingListSO poolingList)
    {
        for(int i = 0; i < poolingList.poolingObjs.Count; i++)
        {
            string objName = poolingList.poolingObjs[i].obj.name;

            if(!pools.ContainsKey(objName))
            {
                Pool _pool = new Pool(poolingList.poolingObjs[i].obj, transform, poolingList.poolingObjs[i].CreateCount);
                pools.Add(objName, _pool);
            }
        }
    }


    public PoolableMono Pop(string name, Vector2 pos)
    {
        PoolableMono obj = null;

        if(pools.ContainsKey(name))
        {
            obj = pools[name].Pop();
            obj.transform.position = pos;
        }

        return obj;
    }

    public void Push(PoolableMono obj)
    {
        if(pools.ContainsKey(obj.name))
        {
            pools[obj.name].Push(obj);
        }
    }
}
