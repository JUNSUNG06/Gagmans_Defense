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

        Debug.Log(unitSO.controller);
        UnitController ttObj = Instantiate(unitSO.controller);

        ttObj.transform.SetParent(transform);
        ttObj.transform.localScale = new Vector3(1, 1, 1);

        GameObject tObj = Instantiate(unitSO.unit) as GameObject;
        tObj.gameObject.name = "Visual";
        tObj.transform.SetParent(ttObj.transform);
        tObj.transform.localScale = Vector3.one * unitSize;
        tObj.transform.localPosition = Vector3.zero;

        ttObj.name = unitSO.unitName;

        _playerList.Add(ttObj);
        ttObj.transform.position = position;
        ttObj.GetComponent<UnitController>().Init(unitSO);
    }
}
