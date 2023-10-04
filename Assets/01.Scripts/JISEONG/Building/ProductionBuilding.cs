using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductionBuilding : BaseBuilding, IDamageable
{
    public void GetDamaged(float damage, out bool isKill)
    {
        isKill = true;
    }

    public override void OnClicked()
    {
        
    }

    public override void StopWorking()
    {
        
    }

    public override void Upgrade()
    {
        
    }
}
