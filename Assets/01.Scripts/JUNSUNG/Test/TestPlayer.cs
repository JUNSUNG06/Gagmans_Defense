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

    //�⹫������ �߰��Ѱ�
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

        if (Input.GetKeyDown(KeyCode.Mouse0)) // ���콺 ��Ŭ���� Ŭ���� ���̾ Ŭ�� �������̽��� �ִ��� Ȯ���ϰ� Ŭ�� �������̽� ����
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            units.Clear();
            if(hit.transform.TryGetComponent<IClickable>(out IClickable clickable)) // �������̽� �����ϸ� Ŭ�� ������ ��ü (�ǹ�, ����) ���� X
            {
                clickable.OnClicked(); // �̰� �����ϸ� �ǹ��� UI�� �߰� ������ �ڽ��� ���õǾ��� �� ���õ� ǥ�ð� ������ ��°�� ������ �̰� ��ӹ��� �ƴ��Ѱ�???
                if(hit.transform.TryGetComponent<UnitController>(out UnitController unit)) // ���� ���õȰ� �����̶�� ���� �������� ���� ��������
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
        if (Input.GetKeyDown(KeyCode.Mouse1)) // ���콺 ��Ŭ���� ���õ� ���ֵ��� ����������
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
