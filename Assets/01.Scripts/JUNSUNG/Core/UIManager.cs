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

    public VisualTreeAsset subUnitUI;
    private SubUnitUI subUnit;

    public VisualTreeAsset trainingUI;
    private TrainingUI training;

    public VisualTreeAsset pubUI;
    private PubUI pub;

    public VisualTreeAsset equipChangeUI;
    private EquipChangeUI equipChange;

    public VisualTreeAsset playerUI;
    private PlayerUI player;

    public List<GameUI> OpendUI = new List<GameUI>();
    public bool isUIOpen => OpendUI.Count > 0;


    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        document = GetComponent<UIDocument>();
        root = document.rootVisualElement.Q<VisualElement>("root");
        
        inventory = new InventoryUI(CreateWindowUI(inventoryUI));
        uiDictionary.Add(typeof(InventoryUI), inventory);
        inventory.Hide();

        training = new TrainingUI(CreateWindowUI(trainingUI));
        uiDictionary.Add(typeof(TrainingUI), training);
        training.Hide();

        pub = new PubUI(CreateWindowUI(pubUI));
        uiDictionary.Add(typeof(PubUI), pub);
        pub.Hide();

        equipChange = new EquipChangeUI(CreateWindowUI(equipChangeUI));
        uiDictionary.Add(typeof(EquipChangeUI), equipChange);
        equipChange.Hide();

        unit = new UnitUI(CreateWindowUI(unitUI));
        uiDictionary.Add(typeof(UnitUI), unit);
        unit.Hide();

        subUnit = new SubUnitUI(CreateWindowUI(subUnitUI));
        uiDictionary.Add(typeof(SubUnitUI), subUnit);
        subUnit.Hide();

        player = new PlayerUI(CreateWindowUI(playerUI));
        uiDictionary.Add(typeof(PlayerUI), player);
        player.Show();
    }

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
            Hide();Debug.Log(123);
            uiDictionary[typeof(PubUI)].Show();
        }
    }

    public void Hide()
    {
        foreach (var ui in uiDictionary)
        {
            ui.Value.Hide();
        }
    }

    public T GetUI<T>() where T : GameUI
    {
        return uiDictionary[typeof(T)] as T;
    }

    private TemplateContainer CreateWindowUI(VisualTreeAsset ui)
    {
        TemplateContainer inventoryTemp = ui.Instantiate();
        inventoryTemp.style.width = Length.Percent(100);
        inventoryTemp.style.height = Length.Percent(100);
        inventoryTemp.style.position = Position.Absolute;
        root.Add(inventoryTemp);

        return inventoryTemp;
    }
}
