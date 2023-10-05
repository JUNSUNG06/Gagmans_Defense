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
    private void DrawSlotData() 
    {
        int selectIndex = Random.Range(0, slotDatas.Count);
        currentSlotData = slotDatas[selectIndex];
        currentTime = drawTime;
    }
    public PubSlot()
    {

    }
    public void Start(List<UnitSO> unitSOs, int _drawTime)
    {
        checkTime = 1f;
        slotDatas = unitSOs;
        drawTime = _drawTime;
        DrawSlotData();
    }
    public void Update()
    {
        checkTime -= Time.deltaTime;
        if(checkTime <= 0)
        {
            currentTime--;
            checkTime = 1f;
            if(currentTime <= 0)
            {
                currentTime = drawTime;
                DrawSlotData();
            }
        }
    }
}
