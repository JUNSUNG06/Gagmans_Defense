using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    public UnitController Unit;
    public GameObject player;

    public Action<UnitController> OnUnitSelect { get; set; }
    public Action<UnitController> OnUnitRelease { get; set; }

    public float doubleClickInterval = 0.3f;
    private float lastClickTime = 0;

    //�⹫������ �߰��Ѱ�
    private List<UnitController> units = new List<UnitController>();
    public LayerMask groundLayer;
    public LayerMask enemyLayer;
    public LayerMask soliderLayer;
    public LayerMask heroLayer;
    private int selectBoxLayer;
    public Transform selectBox;
    private Vector3 startMousePos;
    private Vector3 endMousePos;

    public bool canDrawSelectBox = false;
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        selectBoxLayer = soliderLayer | heroLayer;
        selectBox.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0)) // ���콺 ��Ŭ���� Ŭ���� ���̾ Ŭ�� �������̽��� �ִ��� Ȯ���ϰ� Ŭ�� �������̽� ����
        {
            RaycastHit2D hit = Physics2D.Raycast(GetWorldMousePos(), Vector2.zero);

            if (hit.transform.TryGetComponent<IClickable>(out IClickable clickable)) // �������̽� �����ϸ� Ŭ�� ������ ��ü (�ǹ�, ����) ���� X
            {
                Debug.Log(clickable);
                clickable.OnClicked(); // �̰� �����ϸ� �ǹ��� UI�� �߰� ������ �ڽ��� ���õǾ��� �� ���õ� ǥ�ð� ������ ��°�� ������ �̰� ��ӹ��� �ƴ��Ѱ�???
 
                if (hit.transform.TryGetComponent<UnitController>(out UnitController unit)) // ���� ���õȰ� �����̶�� ���� �������� ���� ��������
                {
                    foreach (UnitController _unit in units)
                    {
                        if (unit == _unit && unit.info.unitType == UnitType.Soldier) //Ŭ���� ������ ����Ʈ�� �ִٸ� �����ϰ� �� �����Ŵϱ� ����Ŭ�� �ۿ�
                        {
                            //���⼭ ���� �κ��丮�� ������
                            UIManager.Instance.GetUI<SubUnitUI>().Hide();

                            UIManager.Instance.GetUI<UnitUI>().Show(unit);
                        }
                    }
                    foreach(UnitController _unit in units)
                    {
                        OnUnitRelease?.Invoke(_unit);
                    }
                    units.Clear();
                    OnUnitSelect?.Invoke(unit);
                    units.Add(unit);
                    UIManager.Instance.GetUI<SubUnitUI>().Show(units[0]);
                }
            }
            else //�����̳� �ǹ��� �ƴϸ� ���û��ڸ� �׸��� �����ؾ���
            {
                startMousePos = GetWorldMousePos();
                selectBox.position = startMousePos;
                selectBox.localScale = Vector3.zero;
                selectBox.gameObject.SetActive(true);
                canDrawSelectBox = true;
                UIManager.Instance.GetUI<SubUnitUI>().Hide();
            }
        }
        else if (Input.GetKey(KeyCode.Mouse0))
        {
            if (startMousePos.sqrMagnitude > 0 && canDrawSelectBox)
            {
                endMousePos = GetWorldMousePos();
                selectBox.transform.localScale = new Vector3(endMousePos.x - startMousePos.x, endMousePos.y - startMousePos.y, 0);
            }
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            
            if (startMousePos.sqrMagnitude > 0)
            {
                foreach(UnitController releaseUnit in units)
                {
                    OnUnitRelease?.Invoke(releaseUnit);
                }
                units.Clear();
                Collider2D[] hits = Physics2D.OverlapAreaAll(startMousePos, endMousePos,selectBoxLayer);
                
                foreach(Collider2D unit in hits)
                {
                    UnitController _unit = unit.transform.GetComponent<UnitController>();
                    OnUnitSelect?.Invoke(_unit);
                    units.Add(_unit);
                }

                startMousePos = Vector3.zero;
                selectBox.gameObject.SetActive(false);
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse1)) // ���콺 ��Ŭ���� ���õ� ���ֵ��� ����������
        {
            RaycastHit2D hit = Physics2D.Raycast(GetWorldMousePos(), Vector2.zero);

            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Building"))
                return;

            if ((1 << hit.transform.gameObject.layer | groundLayer) == groundLayer)
            {
                foreach (UnitController unit in units)
                {
                    unit.Target = null;
                    unit.GetComponent<UnitMovement>().SetTargetPos(hit.point);
                }
            }
            else if (hit.transform.gameObject.layer == enemyLayer)
            {
                foreach (UnitController unit in units)
                {
                    unit.Target = hit.transform;
                }
            }
        }
        #region ���
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
        #endregion
    }

    public void InvokeOnUnitSelectAction()
    {
        OnUnitSelect?.Invoke(Unit);
    }

    public Vector3 GetWorldMousePos()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }
}
