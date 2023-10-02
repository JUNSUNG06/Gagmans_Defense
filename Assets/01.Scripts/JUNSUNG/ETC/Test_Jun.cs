using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Jun : MonoBehaviour
{
    Action action;
    Action action2;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        action2 += () => Debug.Log(1);
        action += action2;
        yield return new WaitForSeconds(1);
        Debug.Log(2);
        action -= action2;
    }

    // Update is called once per frame
    void Update()
    {
        action?.Invoke();
    }
}
