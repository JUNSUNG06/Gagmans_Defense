using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitTime : UnitDecision
{
    public float waitTime = 1f;
    private float currentTime = 0;

    public override bool Decision()
    {
        if(currentTime > waitTime)
        {
            currentTime = 0;
            return true;
        }

        return false;
    }

    private void Update()
    {
        currentTime += Time.deltaTime;
    }
}
