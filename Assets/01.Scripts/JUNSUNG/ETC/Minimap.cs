using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;   
using UnityEngine;
using UnityEngine.UIElements;

public class Minimap : MonoBehaviour
{
    private UIDocument document;
    private VisualElement map;

    public Vector2 mapSize;
    public Vector2 minimapSize;
    public CinemachineVirtualCamera cam;

    private void Awake()
    {
        document = GetComponent<UIDocument>();
        map = document.rootVisualElement.Q("map");
        
        map.RegisterCallback<PointerDownEvent>(OnPointerDownEvent, TrickleDown.TrickleDown);
    }

    private void OnPointerDownEvent(PointerDownEvent evt)
    {
        PlayerManager.Instance.canDrawSelectBox = false;
        Vector3 clickPos = evt.localPosition;
        Vector3 transPos = new Vector3(clickPos.x / minimapSize.x * mapSize.x - mapSize.x / 2f, 
            clickPos.y / minimapSize.y * mapSize.y * -1 + mapSize.y / 2f, cam.transform.position.z);

        cam.transform.position = transPos;
    }
}
