using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TrainingUI : GameUI
{
    public readonly int slotCount = 6;

    public VerticalProgressBar progressBar;
    public List<TrainingSlotUI> slots;
    private ScrollView queue;

    public TrainingUI(TemplateContainer container) : base(container)
    {
        container.name = "training";
        progressBar = root.Q<VerticalProgressBar>();
        slots = root.Query<TrainingSlotUI>().ToList();
        queue = root.Q<ScrollView>("view");
    }

    public void SetProgress(float value)
    {
        progressBar.SetPercent(value);
    }

    public void CreateWaitSlot(Sprite img)
    {
        ItemSlot wait = new ItemSlot();
        wait.SetImage(img);
        queue.contentContainer.Add(wait);
    }

    public void RemoveWaitSlot()
    {
        queue.contentContainer.Remove(queue.contentContainer.Q<ItemSlot>());
    }
}
