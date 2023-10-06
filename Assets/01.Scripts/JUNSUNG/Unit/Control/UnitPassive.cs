using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitPassive : UnitComponent
{
    private List<UnitPassiveType> passives = new List<UnitPassiveType>();

    public override void Init(UnitController _controller)
    {
        base.Init(_controller);
        Transform container = transform.Find("PassiveContainer");

        foreach(Transform child in container)
        {
            if(child.TryGetComponent<UnitPassiveType>(out UnitPassiveType passive))
            {
                passives.Add(passive);
                passive.Init(controller);
            }
        }
    }

    protected override void UnitUpdate()
    {
        for(int i = 0; i < passives.Count; ++i)
        {
            if (passives[i].CanActivePassive())
            {
                Debug.Log(1);
                passives[i].Passive();
            }
        }
    }
}
