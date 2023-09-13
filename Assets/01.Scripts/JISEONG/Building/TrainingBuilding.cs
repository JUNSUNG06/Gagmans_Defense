using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TrainingBuilding : BaseBuilding
{
    private Queue<TrainingSlotDataSO> trainingQueue = new Queue<TrainingSlotDataSO>();
    private bool isWork;

    private float currentHp;
    private float maxHp;

    private int currentLevel;
    private int maxLevel;

    private UnityEvent DestroyEvent;
    private UnityEvent UpgradeEvent;
    private void Start()
    {
        currentLevel = buildingDataSO.minBuildingLevel;
        isWork = false;
        currentHp = maxHp;
    }
    private void RegistrationUnit(TrainingSlotDataSO data) // ���� ���
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

    public override void GetDamaged(float damage, out bool isKill)
    {
        currentHp = Mathf.Clamp(currentHp - damage, 0, maxHp);
        if (currentHp <= 0)
        {
            isKill = true;
            DestroyEvent?.Invoke();
        }
        isKill = false;
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
}
