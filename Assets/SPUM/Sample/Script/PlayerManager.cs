using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public UnitListSO SoldierList;
    public UnitListSO HeroList;
    public UnitListSO EnemyList;
    public float unitSize;

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
    }


    private void Init()
    {
        _playerList.Clear();

        #region
        //_savedUnitList.Clear();

        //var saveArray = Resources.LoadAll<GameObject>("SPUM/SPUM_Units");

        //_savedUnitList.AddRange(saveArray);
        #endregion
    }

    public void SpawnUnit(UnitType type, string name, Vector3 position)
    {
        switch (type)
        {
            case UnitType.Soldier:
                CreateUnit(SoldierList.GetUnit(name), position);
                break;
            case UnitType.Hero:
                CreateUnit(HeroList.GetUnit(name), position);
                break;
            case UnitType.Enemy:
                CreateUnit(EnemyList.GetUnit(name), position);
                break;
        }
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
}
