using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpped;
    private bool movable = false;
    private Vector3 targetPos;

    public void SetMovable(bool value)
    {
        movable = value;
    }

    public void Move()
    {
        if (!movable)
            return;

        transform.Translate(targetPos * moveSpped * Time.deltaTime);
    }
}
