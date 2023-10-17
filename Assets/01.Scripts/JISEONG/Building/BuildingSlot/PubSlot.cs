using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PubSlot
{
    private Transform unitMakeTrm; // 주점 문 위치
    private Transform unitbeginningTrm; // 생성한 후 처음으로 걸어갈 위치

    private int slotNumber;
    private List<UnitSO> slotDatas;
    private UnitSO currentSlotData;

    private int drawTime;
    private int currentTime;
    private float currentTimef;
    private float checkTime;

    private Action OnBuyButton;

    private PubSlotUI pubSlotUI;
    public PubSlot(PubSlotUI slotUI, List<UnitSO> unitSOs, int _drawTime, Transform makeTrm, Transform beginningTrm)
    {
        unitMakeTrm = makeTrm;
        unitbeginningTrm = beginningTrm;
        pubSlotUI = slotUI;
        checkTime = 1f;
        slotDatas = unitSOs;
        drawTime = _drawTime;
        DrawSlotData();
        OnBuyButton += MakeUnit;
        pubSlotUI.Setting(OnBuyButton);
        pubSlotUI.SettingTimerText(currentTime);
    }
    private void DrawSlotData() 
    {
        
        int selectIndex = UnityEngine.Random.Range(0, slotDatas.Count);
        currentSlotData = slotDatas[selectIndex];
        currentTime = drawTime;
        pubSlotUI.SettingBtn(currentSlotData.unitCost);
        pubSlotUI.SettingImage(currentSlotData.profile);
        pubSlotUI.SettingTimerText(currentTime);
    }

    private void MakeUnit()
    {
        currentTimef = 0;
        UnitManager.Instance.SpawnUnit(currentSlotData.unitType, currentSlotData.unitName, unitMakeTrm.position);
        DrawSlotData();
    }

    public void Update()
    {
        checkTime -= Time.deltaTime;
        currentTimef += Time.deltaTime;
        float percent = currentTimef / drawTime;
        pubSlotUI.SettingProgressBar(percent * 100);
        if(checkTime <= 0)
        {
            currentTime--;
            checkTime = 1f;
            pubSlotUI.SettingTimerText(currentTime);
            if(currentTime <= 0)
            {
                currentTimef = 0;
                currentTime = drawTime;
                DrawSlotData();
            }
        }
    }
}
