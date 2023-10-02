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
    public Dictionary<Type, GameUI> UI => uiDictionary;
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

    private void Start()
    {
        UnitUI unitUi = UI[typeof(UnitUI)] as UnitUI;
        TestPlayer.Instance.OnUnitSelect += unitUi.Show;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I)) 
        {
            Hide();
            UI[typeof(InventoryUI)].Show();
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            Hide();
            UI[typeof(TrainingUI)].Show();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            Hide();
            UI[typeof(PubUI)].Show();
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
