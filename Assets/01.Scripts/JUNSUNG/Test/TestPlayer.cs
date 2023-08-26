using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayer : MonoBehaviour
{
    public UnitStateMachine Unit;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            
            if(hit.transform.TryGetComponent<UnitStateMachine>(out UnitStateMachine unit))
            {
                Unit = unit;
            }
            else
            {
                if(Unit != null)
                {
                    Unit.GetComponent<UnitMovement>().SetTargetPos(hit.point);
                }
            }
        }
    }
}
