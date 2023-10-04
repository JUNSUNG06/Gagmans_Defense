using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductionBuilding : BaseBuilding, IClickable, IDamageable
{
    public void GetDamaged(float damage, out bool isKill)
    {
        isKill = true;
    }

    public void OnClicked()
    {
        
    }

    public override void StopWorking()
    {
        
    }

    public override void Upgrade()
    {
        
    }
}
