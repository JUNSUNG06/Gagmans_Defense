using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    private Dictionary<Type, GameUI> uiDictionary = new Dictionary<Type, GameUI>();
    private GameUI currentUI;
    public GameUI CurrentUI { get => currentUI; set => currentUI = value; }

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

    public VisualTreeAsset equipChangeUI;
    private EquipChangeUI equipChange;

    public bool isUIOpen = false;

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

        training = new TrainingUI(CreateWIndowUI(trainingUI));
        uiDictionary.Add(typeof(TrainingUI), training);
        training.Hide();

        pub = new PubUI(CreateWIndowUI(pubUI));
        uiDictionary.Add(typeof(PubUI), pub);
        pub.Hide();

        equipChange = new EquipChangeUI(CreateWIndowUI(equipChangeUI));
        uiDictionary.Add(typeof(EquipChangeUI), equipChange);
        equipChange.Hide();

        unit = new UnitUI(CreateWIndowUI(unitUI));
        uiDictionary.Add(typeof(UnitUI), unit);
        unit.Hide();
    }

    //private void Start()
    //{
    //    UnitUI unitUi = UI[typeof(UnitUI)] as UnitUI;
    //    TestPlayer.Instance.OnUnitSelect += unitUi.Show;
    //}

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I)) 
        {
            Hide();
            uiDictionary[typeof(InventoryUI)].Show();
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            Hide();
            uiDictionary[typeof(TrainingUI)].Show();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            Hide();
            uiDictionary[typeof(PubUI)].Show();
        }
    }

    public void Hide()
    {
        foreach (var ui in uiDictionary)
        {
            ui.Value.Hide();
        }

        isUIOpen = false;
    }

    public T GetUI<T>() where T : GameUI
    {
        return uiDictionary[typeof(T)] as T;
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
