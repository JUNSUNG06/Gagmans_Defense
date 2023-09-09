using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayer : MonoBehaviour
{
    public UnitController Unit;
    public GameObject player;

    private void Awake()
    {
        for(int i = 0; i < 1000; i++)
        {
            Instantiate(player);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            bool findUnit = false;
            RaycastHit2D[] hits = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            foreach(RaycastHit2D hit in hits)
            {
                if (hit.transform.TryGetComponent<UnitController>(out UnitController unit))
                {
                    if(unit.Type == UnitType.Soldier)
                    {
                        Unit = unit;
                    }
                    else if(unit.Type == UnitType.Enemy)
                    {
                        if(Unit != null)
                        {
                            Unit.Target = unit.transform;
                        }
                    }

                    findUnit = true;
                    break;
                }
            }

            if(!findUnit)
            {
                if (Unit != null)
                {
                    Unit.Target = null;
                    Unit.GetComponent<UnitMovement>().SetTargetPos(hits[0].point);
                }
            }
        }
    }
}
