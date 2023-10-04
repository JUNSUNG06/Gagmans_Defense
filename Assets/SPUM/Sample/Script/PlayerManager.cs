﻿using System.Collections;
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

        SpawnUnit(UnitType.Hero, "TestUnit", new Vector3(5, 0, 0));
        SpawnUnit(UnitType.Enemy, "TestEnemy", new Vector3(-5, 0, 0));
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

        GameObject ttObj;

        if(unitSO.unitType == UnitType.Enemy)
            ttObj = Instantiate(enemyBase.gameObject) as GameObject;
        else
            ttObj = Instantiate(unitBase.gameObject) as GameObject;

        ttObj.transform.SetParent(transform);
        ttObj.transform.localScale = new Vector3(1, 1, 1);

        GameObject tObj = Instantiate(unitSO.unit) as GameObject;
        tObj.gameObject.name = "Visual";
        tObj.transform.SetParent(ttObj.transform);
        tObj.transform.localScale = Vector3.one * unitSize;
        tObj.transform.localPosition = Vector3.zero;

        ttObj.name = unitSO.unitName;

        UnitController tObjST = ttObj.GetComponent<UnitController>();

        _playerList.Add(tObjST);
        ttObj.GetComponent<UnitController>().Init(unitSO);
        ttObj.transform.position = position;
    }
}
