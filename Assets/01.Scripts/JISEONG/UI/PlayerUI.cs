using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerUI : GameUI
{
    public Label normalUnitLabel;
    public Label eliteUnitLabel;
    public Label bossName;
    public Label stageLabel;

    private int normalMaxValue;
    private int eliteMaxValue;
    
    public int currentNormal;
    public int currentElite;
    public PlayerUI(TemplateContainer container) : base(container)
    {
        normalUnitLabel = root.Q<Label>("normalUnitLabel");
        eliteUnitLabel = root.Q<Label>("eliteUnitLabel");
        bossName = root.Q<Label>("bossLabel");
        stageLabel = root.Q<Label>("title");
    }

    public void SetNormalUnitLabel(int curValue)
    {
        normalUnitLabel.text = $"NormalUnit : {curValue} / {normalMaxValue}";
    }

    public void SetEliteUnitLabel(int curValue)
    {
        eliteUnitLabel.text = $"EliteUnit : {curValue} / {eliteMaxValue}";
    }

    public void SetBossName(string value)
    {
        bossName.text = "Boss : " + value;
    }

    public void SettingStage(int value,int normalValue, int eliteValue)
    {
        stageLabel.text = $"STAGE {value}";
        normalMaxValue = normalValue;
        eliteMaxValue = eliteValue;
    }

    public override void Show()
    {
        container.style.display = DisplayStyle.Flex;
    }

    public override void Hide()
    {
        container.style.display = DisplayStyle.None;
    }
}
