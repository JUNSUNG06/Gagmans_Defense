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

    //기무지성이 추가한거
    private List<UnitController> units = new List<UnitController>();
    public LayerMask groundLayer;
    public LayerMask enemyLayer;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0)) // 마우스 좌클릭시 클릭된 레이어가 클릭 인터페이스가 있는지 확인하고 클릭 인터페이스 실행
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            units.Clear();
            if(hit.transform.TryGetComponent<IClickable>(out IClickable clickable)) // 인터페이스 존재하면 클릭 가능한 물체 (건물, 유닛) 몬스터 X
            {
                clickable.OnClicked(); // 이걸 실행하면 건물은 UI가 뜨고 유닛은 자신이 선택되었을 때 선택된 표시가 떠야함 어째서 유닛은 이걸 상속받지 아니한가???
                if(hit.transform.TryGetComponent<UnitController>(out UnitController unit)) // 만약 선택된게 유닛이라면 추후 움직임을 위해 담아줘야함
                {
                    units.Add(unit);
                }
            }
        }
        else if (Input.GetKey(KeyCode.Mouse0))
        {

        }
        else if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            
        }
        if (Input.GetKeyDown(KeyCode.Mouse1)) // 마우스 우클릭시 선택된 유닛들이 움직여야함
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if(hit.transform.gameObject.layer == groundLayer)
            {
                foreach(UnitController unit in units)
                {
                    unit.Target = null;
                    unit.GetComponent<UnitMovement>().SetTargetPos(hit.point);
                }
            }
            else if(hit.transform.gameObject.layer == enemyLayer)
            {
                foreach(UnitController unit in units)
                {
                    unit.Target = hit.transform;
                }
            }
        }

        //if (Input.GetMouseButtonDown(0) && !UIManager.Instance.isUIOpen)
        //{
        //    bool findUnit = false;
        //    RaycastHit2D[] hits = Physics2D.RaycastAll(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        //    foreach (RaycastHit2D hit in hits)
        //    {
        //        if (hit.transform.TryGetComponent<UnitController>(out UnitController unit))
        //        {
        //            if (unit.info.unitType == UnitType.Hero || unit.info.unitType == UnitType.Soldier)
        //            {
        //                UIManager.Instance.GetUI<SubUnitUI>().Show(unit);

        //                if (Unit == unit && lastClickTime + doubleClickInterval > Time.time && unit.info.unitType == UnitType.Hero)
        //                {
        //                    UIManager.Instance.GetUI<SubUnitUI>().Hide();
        //                    UIManager.Instance.GetUI<UnitUI>().Show(Unit);
        //                }

        //                Unit = unit;
        //                OnUnitSelect?.Invoke(unit);
        //                lastClickTime = Time.time;
        //            }
        //            else if (unit.info.unitType == UnitType.Enemy)
        //            {
        //                if (Unit != null)
        //                {
        //                    Unit.Target = unit.transform;
        //                }
        //            }

        //            findUnit = true;
        //            break;
        //        }
        //    }

        //    if (!findUnit)
        //    {
        //        if (Unit != null)
        //        {
        //            Unit.Target = null;
        //            Unit.GetComponent<UnitMovement>().SetTargetPos(hits[0].point);
        //        }
        //    }
        //}
    }

    public void InvokeOnUnitSelectAction()
    {
        OnUnitSelect?.Invoke(Unit);
    }
}
