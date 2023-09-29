using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TestPlayer : MonoBehaviour
{
    public static TestPlayer Instance;

    public UnitController Unit;
    public GameObject player;

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
                    if(unit.Type == UnitType.Soldier)
                    {
                        if(Unit == unit && lastClickTime + doubleClickInterval > Time.time)
                        {
                            UIManager.Instance.Show(typeof(UnitUI));    
                        }

                        Unit = unit;
                        lastClickTime = Time.time;
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
