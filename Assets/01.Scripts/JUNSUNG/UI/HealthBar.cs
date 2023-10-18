using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class HealthBar
{
    public HealthBarUI ui;
    private GameObject owner;
    private Camera cam;

    public HealthBar(GameObject _owner, HealthBarUI _ui)
    {
        this.owner = _owner;
        ui = _ui;
        cam = Camera.main;  
    }

    public void SetBar(float percent)
    {
        ui.SetBar(percent);
    }

    public void Show()
    {
        ui.Show();
    }

    public void Hide()
    {
        ui.Hide();
    }

    public void SetPosition()
    {
        var worldPos = owner.transform.position - Vector3.up * 0.8f;
        
        var screenPos = cam.WorldToScreenPoint(worldPos);

        screenPos.z = 0f;
        ui.SetPosition(screenPos);
    }
}
