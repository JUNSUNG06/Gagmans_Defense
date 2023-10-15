using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField] private List<Transform> unitMakeTrms;
    [SerializeField] private List<StageInfoSO> stageInfoSOs;

    [SerializeField] private int stageTime;
    [SerializeField] private int waitTime;

    private List<UnitInfo> currentNormalUnits;
    private List<UnitInfo> currentEliteUnits;
    private UnitSO currentBoss;

    private List<int> currentNormalUnitCnt;
    private List<int> currentEliteUnitCnt;

    private float normalUnitWaitTime;
    private float eliteUnitWaitTime;

    private int stageLevel;

    private void Start()
    {
        stageLevel = 0;
        ChangeStage();
    }
    public void SettingStage()
    {
        currentNormalUnits = stageInfoSOs[stageLevel].normalUnits;
        currentEliteUnits = stageInfoSOs[stageLevel].eliteUnits;
        currentBoss = stageInfoSOs[stageLevel].boss;
        
        float allNormalUnitCnt = 0;
        for(int i = 0; i < currentNormalUnits.Count; i++)
        {
            allNormalUnitCnt += currentNormalUnits[i].unitCnt;
            currentNormalUnitCnt.Add(currentNormalUnits[i].unitCnt);
        }
        normalUnitWaitTime = stageTime / allNormalUnitCnt;
        
        float allEliteUnitCnt = 0;
        for(int i = 0; i < currentEliteUnits.Count; i++)
        {
            allEliteUnitCnt += currentEliteUnits[i].unitCnt;
            currentEliteUnitCnt.Add(currentEliteUnits[i].unitCnt);
        }
        eliteUnitWaitTime = stageTime / allEliteUnitCnt;
    }

    public void ChangeStage()
    {
        SettingStage();
        stageLevel++;
    }

    private void RandomSpawnNormal()
    {
        int unitIndex = Random.Range(0, currentNormalUnits.Count);
        int makePosIndex = Random.Range(0, unitMakeTrms.Count);

        UnitManager.Instance.SpawnUnit(UnitType.Enemy, currentNormalUnits[unitIndex].unit.unitName, unitMakeTrms[makePosIndex].position);
    }
    private void RandomSpawnElite()
    {
        int unitIndex = Random.Range(0, currentEliteUnits.Count);
        int makePosIndex = Random.Range(0, unitMakeTrms.Count);

        UnitManager.Instance.SpawnUnit(UnitType.Enemy, currentEliteUnits[unitIndex].unit.unitName, unitMakeTrms[makePosIndex].position);
    }

    private IEnumerator Spawn()
    {
        float normalUnitTimer = 0;
        float eliteUnitTimer = 0;
        while (true)
        {
            normalUnitTimer += Time.deltaTime;
            eliteUnitTimer += Time.deltaTime;
            if(normalUnitTimer >= normalUnitWaitTime)
            {
                RandomSpawnNormal();
                normalUnitTimer = 0;
            }
            if(eliteUnitTimer >= eliteUnitWaitTime)
            {
                RandomSpawnElite();
                eliteUnitTimer = 0;
            }
            yield return null;
        }
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitTime);
        StartCoroutine(Spawn());
    }
}
