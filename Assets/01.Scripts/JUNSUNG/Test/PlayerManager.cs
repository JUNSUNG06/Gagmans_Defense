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

    //기무지성이 추가한거
    public List<UnitController> units = new List<UnitController>();
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
        if (UIManager.Instance.isUIOpen)
            return;

        if (Input.GetKeyDown(KeyCode.Mouse0) && !UIManager.Instance.isUIOpen) // 마우스 좌클릭시 클릭된 레이어가 클릭 인터페이스가 있는지 확인하고 클릭 인터페이스 실행
        {
            RaycastHit2D hit = Physics2D.Raycast(GetWorldMousePos(), Vector2.zero);

            if (hit.transform.TryGetComponent<IClickable>(out IClickable clickable)) // 인터페이스 존재하면 클릭 가능한 물체 (건물, 유닛) 몬스터 X
            {
                clickable.OnClicked(); // 이걸 실행하면 건물은 UI가 뜨고 유닛은 자신이 선택되었을 때 선택된 표시가 떠야함 어째서 유닛은 이걸 상속받지 아니한가???
 
                if (hit.transform.TryGetComponent<UnitController>(out UnitController unit)) // 만약 선택된게 유닛이라면 추후 움직임을 위해 담아줘야함
                {
                    foreach (UnitController _unit in units)
                    {
                        if (unit == _unit && unit.info.unitType == UnitType.Soldier) //클릭한 유닛이 리스트에 있다면 선택하고 또 누른거니깐 더블클릭 작용
                        {
                            Unit = unit;
                            //여기서 유닛 인벤토리가 떠야함
                            UIManager.Instance.GetUI<SubUnitUI>().Hide();

                            UIManager.Instance.GetUI<UnitUI>().Show(unit);
                        }
                    }
                    foreach(UnitController _unit in units)
                    {
                        OnUnitRelease?.Invoke(_unit);
                    }
                    units.Clear();
                    Unit = unit;
                    OnUnitSelect?.Invoke(unit);
                    units.Add(unit);
                    UIManager.Instance.GetUI<SubUnitUI>().Show(units[0]);
                }
            }
            else //유닛이나 건물이 아니면 선택상자를 그리기 시작해야함
            {
                startMousePos = GetWorldMousePos();
                selectBox.position = startMousePos;
                selectBox.localScale = Vector3.zero;
                selectBox.gameObject.SetActive(true);
                canDrawSelectBox = true;
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
            if (startMousePos.sqrMagnitude > 0 && canDrawSelectBox)
            {
                foreach(UnitController releaseUnit in units)
                {
                    OnUnitRelease?.Invoke(releaseUnit);
                }
                units.Clear();
                Unit = null;
                Collider2D[] hits = Physics2D.OverlapAreaAll(startMousePos, endMousePos,selectBoxLayer);
                
                foreach(Collider2D unit in hits)
                {
                    UnitController _unit = unit.transform.GetComponent<UnitController>();
                    OnUnitSelect?.Invoke(_unit);
                    units.Add(_unit);
                }

                startMousePos = Vector3.zero;
                selectBox.gameObject.SetActive(false);
                UIManager.Instance.GetUI<SubUnitUI>().Hide();
            }
        }
        if (Input.GetKeyDown(KeyCode.Mouse1)) // 마우스 우클릭시 선택된 유닛들이 움직여야함
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
            else if ((1 << hit.transform.gameObject.layer | enemyLayer) == enemyLayer)
            {
                foreach (UnitController unit in units)
                {
                    unit.Target = hit.transform;
                }
            }
        }
        #region 폐기
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
