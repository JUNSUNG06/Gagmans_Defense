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
    public void ActivatePubSlot() //슬롯이 잠겨있다가 건물이 레벨업하면 레벨에 맞는 인덱스에 슬롯이 동작해야함
    {
        StartCoroutine(Timer());
    }
    private void SetSlotUI()
    {
        //버튼에 BuyUnit 연결
        //currentSlotData에 맞는 UI로 세팅하기
        //만약 비활성화 되어있다면 활성화 해야함 (비활성화는 예를들어 잠금아이콘 띄우기 같은거)
    }

    public void BuyUnit()
    {
        //currentSlotData 유닛 생성하기
        //currentSlotData 돈 소모하기
        //현재 버튼 연결 초기화 후 ShowCannotBuyText연결
        DrawSlotData();

    }
    public void ShowCannotBuyText() 
    {
        // 지금은 구매할 수 없습니다 메세지 출력하기
    }

    private void DrawSlotData() 
    {
        int selectIndex = Random.Range(0, slotDatas.Count);
        currentSlotData = slotDatas[selectIndex];
        SetSlotUI();
    }

    private IEnumerator Timer() //시간이 지나면 새로운 Data 선택하기
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
