using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PubSlot : MonoBehaviour
{
    PlayerManager playerManager;
    PlayerWallet playerWallet;
    private int slotNumber;
    [SerializeField] private List<UnitSO> slotDatas;
    private UnitSO currentSlotData;
    private Vector3 unitMakePos; // ���� �� ��ġ
    private Vector3 unitbeginningPos; // ������ �� ó������ �ɾ ��ġ

    [SerializeField] private int drawTime;
    private int currentTime;
    private void Start()
    {
        currentTime = drawTime;
    }
    public void ActivatePubSlot(int _slotNumber, Vector3 makePos, Vector3 beginningPos) //������ ����ִٰ� �ǹ��� �������ϸ� ������ �´� �ε����� ������ �����ؾ���
    {
        slotNumber = _slotNumber;
        unitMakePos = makePos;
        unitbeginningPos = beginningPos;
        StartCoroutine(Timer());
    }
    private void SetSlotUI()
    {
        UIManager.Instance.GetUI<PubUI>().SettingSlot(slotNumber, currentSlotData.unitCost);
    }
    private void SetSlotTimer()
    {
        UIManager.Instance.GetUI<PubUI>().SettingTimer(slotNumber, currentTime);
    }
    public void BuyUnit()
    {
        if(playerWallet.Money < currentSlotData.unitCost)
        {
            FailBuyMessage();
            return;
        }
        //currentSlotData ���� �����ϱ�
        playerManager.SpawnUnit(currentSlotData.unitType, currentSlotData.name, unitMakePos); // �ӽ÷� ¥�а� playerManager ��� �޾ƾ� �ϴ��� �˾ƾ���
        //currentSlotData �� �Ҹ��ϱ�
        playerWallet.Money -= currentSlotData.unitCost;
        DrawSlotData();

    }
    private void FailBuyMessage()
    {

    }
    private void DrawSlotData() 
    {
        int selectIndex = Random.Range(0, slotDatas.Count);
        currentSlotData = slotDatas[selectIndex];
        currentTime = drawTime;
        SetSlotUI();
    }

    private IEnumerator Timer() //�ð��� ������ ���ο� Data �����ϱ�
    {
        float checkTime = 1f;
        while (true) 
        {
            checkTime -= Time.deltaTime;
            if(checkTime <= 0)
            {
                currentTime--;
                checkTime = 1f;
                SetSlotTimer();

            }
            if(currentTime <= 0)
                DrawSlotData();
            yield return null;
        }
    }
}
