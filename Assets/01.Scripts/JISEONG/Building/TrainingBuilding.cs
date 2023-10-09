using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TrainingBuilding : BaseBuilding
{
    
    [SerializeField] private Transform unitMakeTrm; // 훈련소 문 위치
    [SerializeField] private Transform unitbeginningTrm; // 훈련한 후 처음으로 걸어갈 위치
    private Queue<TrainingSlotDataSO> trainingQueue = new Queue<TrainingSlotDataSO>();
    private bool isWork;
    private void Start()
    {
        currentLevel = buildingDataSO.minBuildingLevel;
        Upgrade();
        isWork = false;
    }
    public void RegistrationUnit(TrainingSlotDataSO data) // 유닛 등록
    {
        trainingQueue.Enqueue(data);
        if (isWork == false) 
        {
            isWork = true;
            StartCoroutine(TrainingUnit());
        }
    }

    private IEnumerator TrainingUnit()
    {
        float currentTime = 0;
        while (true)
        {
            if (trainingQueue.Count < 1) // 더 이상 훈련할 유닛이 없다면 중단
            {
                isWork = false;
                break;
            }
            if (currentTime >= trainingQueue.Peek().trainingTime) //큐에 들어있는 첫번째 요소에 접근해서 처리 
            {
                TrainingSlotDataSO unitData = trainingQueue.Dequeue();
                //trainingCost 빼줘야함
                //traingUnit 생성해야함
                currentTime = 0;
            }

            currentTime += Time.deltaTime;
            yield return null;
        }
    }

    public override void Upgrade()
    {
        currentLevel++;
        if(currentLevel >= maxLevel)
        {
            //건물을 더 이상 강화할 수 없다면 버튼 비활성화 해야함
        }
        UpgradeEvent?.Invoke();
    }

    public override void StopWorking()
    {
        StopAllCoroutines();
    }

    public override void OnClicked()
    {
        UIManager.Instance.GetUI<TrainingUI>().Show();
    }
}
