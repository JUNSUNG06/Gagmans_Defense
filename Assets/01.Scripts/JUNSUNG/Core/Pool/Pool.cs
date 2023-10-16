using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool
{
    private Queue<PoolableMono> pool = new Queue<PoolableMono>();
    private PoolableMono prefab;
    private Transform parent;

    public Pool(PoolableMono _prefab, Transform _parent, int createCount = 10)
    {
        prefab = _prefab;
        parent = _parent;

        for(int i = 0; i < createCount; i++)
        {
            PoolableMono obj = GameObject.Instantiate(prefab);
            obj.transform.SetParent(parent);
            obj.name = obj.name.Replace("(Clone)", "");
            obj.gameObject.SetActive(false);
            pool.Enqueue(obj);
        }
    }

    public PoolableMono Pop()
    {
        PoolableMono obj;

        if(pool.Count <= 0)
        {
            obj = GameObject.Instantiate(prefab);
            obj.name = obj.name.Replace("(Clone)", "");
            obj.transform.SetParent(parent);
        }
        else
        {
            obj = pool.Dequeue();
        }

        obj.gameObject.SetActive(true);
        obj.Init();

        return obj;
    }

    public void Push(PoolableMono obj)
    {
        obj.gameObject.SetActive(false);
        pool.Enqueue(obj);
    }
}
