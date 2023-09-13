using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PubSlot : MonoBehaviour
{
    [SerializeField] private List<PubSlotDataSO> slotDatas;
    private PubSlotDataSO currentSlotData;

    [SerializeField] private float drawTime;
    private float currentTime;
    private void Start()
    {
        currentTime = drawTime;
    }
    public void ActivatePubSlot() //������ ����ִٰ� �ǹ��� �������ϸ� ������ �´� �ε����� ������ �����ؾ���
    {
        StartCoroutine(Timer());
    }
    private void SetSlotUI()
    {
        //��ư�� BuyUnit ����
        //currentSlotData�� �´� UI�� �����ϱ�
        //���� ��Ȱ��ȭ �Ǿ��ִٸ� Ȱ��ȭ �ؾ��� (��Ȱ��ȭ�� ������� ��ݾ����� ���� ������)
    }

    public void BuyUnit()
    {
        //currentSlotData ���� �����ϱ�
        //currentSlotData �� �Ҹ��ϱ�
        //���� ��ư ���� �ʱ�ȭ �� ShowCannotBuyText����
        DrawSlotData();

    }
    public void ShowCannotBuyText() 
    {
        // ������ ������ �� �����ϴ� �޼��� ����ϱ�
    }

    private void DrawSlotData() 
    {
        int selectIndex = Random.Range(0, slotDatas.Count);
        currentSlotData = slotDatas[selectIndex];
        SetSlotUI();
    }

    private IEnumerator Timer() //�ð��� ������ ���ο� Data �����ϱ�
    {
        while (true) 
        {
            currentTime -= Time.deltaTime;
            if(currentTime <= 0)
            {
                DrawSlotData();
                currentTime = drawTime;
            }
            yield return null;
        }
    }
}
