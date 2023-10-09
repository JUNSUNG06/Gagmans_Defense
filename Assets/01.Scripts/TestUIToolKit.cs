using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TestUIToolKit : VisualElement
{
    public new class UxmlFactory : UxmlFactory <TestUIToolKit> { }

    public TestUIToolKit()
    {
        Debug.Log("CREATE");
    }
}
