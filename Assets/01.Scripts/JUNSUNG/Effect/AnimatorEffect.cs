using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorEffect : Effect
{
    private WaitForSeconds wfs;

    private void Awake()
    {
        Debug.Log(GetComponent<Animator>().runtimeAnimatorController.animationClips[0].length);
        wfs = new WaitForSeconds(GetComponent<Animator>().runtimeAnimatorController.animationClips[0].length);
    }

    public override void Init()
    {
        StartCoroutine(Push());
    }

    protected override IEnumerator Push()
    {
        yield return wfs;
        PoolManager.Instance.Push(this);
    }
}
