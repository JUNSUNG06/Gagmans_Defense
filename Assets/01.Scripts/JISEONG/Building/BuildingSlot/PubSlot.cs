using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PubSlot
{
    private int slotNumber;
    private List<UnitSO> slotDatas;
    private UnitSO currentSlotData;

    private int drawTime;
    private int currentTime;
    private float checkTime;

    private PubSlotUI pubSlotUI;
    public PubSlot(PubSlotUI slotUI, List<UnitSO> unitSOs, int _drawTime)
    {
        pubSlotUI = slotUI;
        checkTime = 1f;
        slotDatas = unitSOs;
        drawTime = _drawTime;
        DrawSlotData();
    }
    private void DrawSlotData() 
    {
        int selectIndex = Random.Range(0, slotDatas.Count);
        currentSlotData = slotDatas[selectIndex];
        currentTime = drawTime;
        pubSlotUI.SettingBtn(currentSlotData.unitCost);
    }
    public void Update()
    {
        checkTime -= Time.deltaTime;
        if(checkTime <= 0)
        {
            currentTime--;
            checkTime = 1f;
            pubSlotUI.SettingTimer(currentTime);
            if(currentTime <= 0)
            {
                currentTime = drawTime;
                DrawSlotData();
            }
        }
    }
}
