using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UnitManager : MonoBehaviour
{
    //public UnitListSO SoldierList;
    //public UnitListSO HeroList;
    //public UnitListSO EnemyList;

    private List<UnitSO> soldierList;
    private List<UnitSO> heroList;
    private List<UnitSO> enemyList;

    public float unitSize;
    public Color slectedColor;
    public Color unSlectedColor;

    [Space]
    public UnitController unitBase;
    public UnitController enemyBase;
    public List<UnitController> _playerList = new List<UnitController>();

    void Start()
    {
        Init();

        SpawnUnit(UnitType.Soldier, "AxSoldier", new Vector3(0, 0, 0));
        SpawnUnit(UnitType.Soldier, "Knight", new Vector3(2, 0, 0));
        SpawnUnit(UnitType.Soldier, "Wizard", new Vector3(4, 0, 0));
        SpawnUnit(UnitType.Soldier, "Healer", new Vector3(6, 0, 0));
        SpawnUnit(UnitType.Soldier, "Archer", new Vector3(8, 0, 0));
        SpawnUnit(UnitType.Soldier, "Infantry", new Vector3(10, 0, 0));

        Debug.Log(PlayerManager.Instance);
        PlayerManager.Instance.OnUnitSelect += ChangeUnitShadowSelect;
        PlayerManager.Instance.OnUnitRelease += ChangeUnitShadowUnSelect;
    }

    private void Init()
    {
        _playerList.Clear();

        soldierList = Resources.LoadAll<UnitSO>($"UnitSO/SoldierUnit").ToList();
        heroList = Resources.LoadAll<UnitSO>($"UnitSO/HeroUnit").ToList();
        enemyList = Resources.LoadAll<UnitSO>($"UnitSO/EnemyUnit").ToList();
    }

    public void SpawnUnit(UnitType type, string name, Vector3 position)
    {
        UnitSO unit = null;

        switch (type)
        {
            case UnitType.Soldier:
                unit = soldierList.Find(x => x.unitName == name);
                break;
            case UnitType.Hero:
                unit = heroList.Find(x => x.unitName == name);
                break;
            case UnitType.Enemy:
                unit = enemyList.Find(x => x.unitName == name);
                break;
        }

        if (unit == null)
            Debug.Log("없는 유닛");
        else
            CreateUnit(unit, position);
    }

    private void CreateUnit(UnitSO unitSO, Vector3 position)
    {
        if(unitSO == null) 
            return;

        UnitController ttObj = Instantiate(unitSO.controller);

        ttObj.transform.SetParent(transform);
        ttObj.transform.localScale = new Vector3(1, 1, 1);

        GameObject tObj = Instantiate(unitSO.unit) as GameObject;
        tObj.gameObject.name = "Visual";
        tObj.transform.SetParent(ttObj.transform);
        tObj.transform.localScale = Vector3.one * unitSize;
        tObj.transform.localPosition = Vector3.zero;

        ttObj.name = unitSO.unitName;
        ttObj.gameObject.layer = LayerMask.NameToLayer(unitSO.unitType.ToString());

        _playerList.Add(ttObj);
        ttObj.transform.position = position;
        ttObj.GetComponent<UnitController>().Init(unitSO, null);
    }

    private void ChangeUnitShadowSelect(UnitController unit)
    {
        unit.ChangeShadowColor(slectedColor);
    }

    private void ChangeUnitShadowUnSelect(UnitController unit)
    {
        unit.ChangeShadowColor(unSlectedColor);
    }
}
