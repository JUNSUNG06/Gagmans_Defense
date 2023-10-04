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
    private Vector3 unitMakePos; // 주점 문 위치
    private Vector3 unitbeginningPos; // 생성한 후 처음으로 걸어갈 위치

    [SerializeField] private int drawTime;
    private int currentTime;
    private void Start()
    {
        currentTime = drawTime;
    }
    public void ActivatePubSlot(int _slotNumber, Vector3 makePos, Vector3 beginningPos) //슬롯이 잠겨있다가 건물이 레벨업하면 레벨에 맞는 인덱스에 슬롯이 동작해야함
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
        //currentSlotData 유닛 생성하기
        playerManager.SpawnUnit(currentSlotData.unitType, currentSlotData.name, unitMakePos); // 임시로 짜둔거 playerManager 어디서 받아야 하는지 알아야함
        //currentSlotData 돈 소모하기
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

    private IEnumerator Timer() //시간이 지나면 새로운 Data 선택하기
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
