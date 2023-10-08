using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TestPlayer : MonoBehaviour
{
    public static TestPlayer Instance;

    public UnitController Unit;
    public GameObject player;

    public Action<UnitController> OnUnitSelect { get; set; }

    public float doubleClickInterval = 0.3f;
    private float lastClickTime = 0;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !UIManager.Instance.isUIOpen)
        {
            bool findUnit = false;
            RaycastHit2D[] hits = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            foreach(RaycastHit2D hit in hits)
            {
                if (hit.transform.TryGetComponent<UnitController>(out UnitController unit))
                {
                    if(unit.info.unitType == UnitType.Hero || unit.info.unitType == UnitType.Soldier)
                    {
                        UIManager.Instance.GetUI<SubUnitUI>().Show(unit);

                        if (Unit == unit  && lastClickTime + doubleClickInterval > Time.time && unit.info.unitType == UnitType.Hero)
                        {
                            UIManager.Instance.GetUI<SubUnitUI>().Hide();
                            UIManager.Instance.GetUI<UnitUI>().Show(Unit);
                        }

                        Unit = unit;
                        OnUnitSelect?.Invoke(unit);
                        lastClickTime = Time.time;
                    }
                    else if(unit.info.unitType == UnitType.Enemy)
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

    public void InvokeOnUnitSelectAction()
    {
        OnUnitSelect?.Invoke(Unit);
    }
}
