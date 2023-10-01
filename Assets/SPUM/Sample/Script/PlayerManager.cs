using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public UnitListSO SoldierList;
    public UnitListSO HeroList;
    public UnitListSO EnemyList;

    [Space]
    public UnitController unitBase;
    public List<GameObject> _savedUnitList = new List<GameObject>();
    public Vector2 _startPos;
    public Vector2 _addPos;
    public int _columnNum;

    //public Transform _playerPool;
    public List<UnitController> _playerList = new List<UnitController>();
    public Transform _playerObjCircle;
    public Transform _goalObjCircle;

    void Start()
    {
        Init();

        SpawnUnit(UnitType.Hero, "TestUnit", Vector3.zero);
    }

    private void Init()
    {
        _playerList.Clear();
        _savedUnitList.Clear();

        var saveArray = Resources.LoadAll<GameObject>("SPUM/SPUM_Units");

        _savedUnitList.AddRange(saveArray);
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

        GameObject ttObj = Instantiate(unitBase.gameObject) as GameObject;
        ttObj.transform.SetParent(transform);
        ttObj.transform.localScale = new Vector3(1, 1, 1);

        GameObject tObj = Instantiate(unitSO.unit) as GameObject;
        tObj.gameObject.name = "Visual";
        tObj.transform.SetParent(ttObj.transform);
        tObj.transform.localScale = new Vector3(1, 1, 1);
        tObj.transform.localPosition = Vector3.zero;

        ttObj.name = unitSO.unitName;

        UnitController tObjST = ttObj.GetComponent<UnitController>();

        _playerList.Add(tObjST);
        ttObj.GetComponent<UnitController>().Init();
        ttObj.transform.position = position;
    }
}
