using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAnyStateTransition : MonoBehaviour
{
    private List<UnitStateTransition> transitions = new List<UnitStateTransition>();

    public void Init(UnitController controller)
    {
        foreach(Transform child in transform)
        {
            if(child.TryGetComponent<UnitStateTransition>(out UnitStateTransition transition))
            {
                transition = child.GetComponent<UnitStateTransition>();
                transitions.Add(transition);
                transition.Init(controller);
            }
        }
    }

    public void CheckTransitions()
    {
        for(int i = 0; i < transitions.Count; i++)
        {
            transitions[i].CheckDecisions();
        }
    }
}
