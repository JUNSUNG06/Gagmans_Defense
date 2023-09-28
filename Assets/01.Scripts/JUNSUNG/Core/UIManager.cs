using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    private Dictionary<Type, GameUI> uiDictionary = new Dictionary<Type, GameUI>();
    public GameUI currentUI;
    private UIDocument document;
    private VisualElement root;

    public VisualTreeAsset inventoryUI;
    private InventoryUI inventory;

    public VisualTreeAsset unitUI;
    private UnitUI unit;

    public VisualTreeAsset trainingUI;
    private TrainingUI training;

    public VisualTreeAsset pubUI;
    private PubUI pub;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        document = GetComponent<UIDocument>();
        root = document.rootVisualElement.Q<VisualElement>("root");
        
        inventory = new InventoryUI(CreateWIndowUI(inventoryUI));
        uiDictionary.Add(typeof(InventoryUI), inventory);
        inventory.Hide();

        unit = new UnitUI(CreateWIndowUI(unitUI));
        uiDictionary.Add(typeof(UnitUI), unit);
        unit.Hide();

        training = new TrainingUI(CreateWIndowUI(trainingUI));
        uiDictionary.Add(typeof(TrainingUI), training);
        training.Hide();

        pub = new PubUI(CreateWIndowUI(pubUI));
        uiDictionary.Add(typeof(PubUI), pub);
        pub.Hide();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I)) 
        {
            Show(typeof(InventoryUI));
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            Show(typeof(UnitUI));
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            Show(typeof(TrainingUI));
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            Show(typeof(PubUI));
        }
    }

    public void Show(Type type)
    {
        Hide();

        uiDictionary[type].Show();
    }

    public void Hide()
    {
        foreach (var ui in uiDictionary)
        {
            ui.Value.Hide();
        }
    }

    private TemplateContainer CreateWIndowUI(VisualTreeAsset ui)
    {
        TemplateContainer inventoryTemp = ui.Instantiate();
        inventoryTemp.style.width = Length.Percent(100);
        inventoryTemp.style.height = Length.Percent(100);
        inventoryTemp.style.position = Position.Absolute;
        root.Add(inventoryTemp);

        return inventoryTemp;
    }
}
