using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TrainingBuilding : BaseBuilding
{
    
    [SerializeField] private Transform unitMakeTrm; // �Ʒü� �� ��ġ
    [SerializeField] private Transform unitbeginningTrm; // �Ʒ��� �� ó������ �ɾ ��ġ
    private Queue<TrainingSlotDataSO> trainingQueue = new Queue<TrainingSlotDataSO>();
    private bool isWork;

    private int currentLevel; 
    private int maxLevel;
    private void Start()
    {
        currentLevel = buildingDataSO.minBuildingLevel;
        Upgrade();
        isWork = false;
    }
    public void RegistrationUnit(TrainingSlotDataSO data) // ���� ���
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
            if (trainingQueue.Count < 1) // �� �̻� �Ʒ��� ������ ���ٸ� �ߴ�
            {
                isWork = false;
                break;
            }
            if (currentTime >= trainingQueue.Peek().trainingTime) //ť�� ����ִ� ù��° ��ҿ� �����ؼ� ó�� 
            {
                TrainingSlotDataSO unitData = trainingQueue.Dequeue();
                //trainingCost �������
                //traingUnit �����ؾ���
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
            //�ǹ��� �� �̻� ��ȭ�� �� ���ٸ� ��ư ��Ȱ��ȭ �ؾ���
        }
        UpgradeEvent?.Invoke();
    }

    public override void StopWorking()
    {
        StopAllCoroutines();
    }
}
