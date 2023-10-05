using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitPassive : UnitComponent
{
    private List<UnitPassiveType> passives;

    public override void Init(UnitController _controller)
    {
        base.Init(_controller);
        transform.Find("PassiveContainer").GetComponents<UnitPassiveType>(passives);
    }

    protected override void UnitUpdate()
    {
        for(int i = 0; i < passives.Count; ++i)
        {
            if (passives[i].CanActivePassive())
                passives[i].Passive();
        }
    }
}
