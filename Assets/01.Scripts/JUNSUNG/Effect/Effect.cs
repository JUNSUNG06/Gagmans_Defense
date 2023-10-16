using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Effect : PoolableMono
{
    protected WaitUntil wait;

    public virtual void Flip(bool value) { }

    protected virtual IEnumerator Push()
    {
        yield return wait;

        PoolManager.Instance.Push(this);
    }
}
