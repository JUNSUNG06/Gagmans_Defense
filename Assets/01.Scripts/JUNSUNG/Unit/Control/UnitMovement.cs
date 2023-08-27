using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpped = 5f;
    private bool movable = true;
    private Vector2 targetPos;
    private Vector2 moveDir;
    private UnitController controller;

    public Vector2 TargetPos => targetPos;

    private void Awake()
    {
        controller = GetComponent<UnitController>();
    }

    private void Start()
    {
        targetPos = transform.position;
    }

    private void Update()
    {
        Transform target = controller.Target;

        if (target != null)
            SetTargetPos(target.position);
    }

    public void SetMovable(bool value)
    {
        movable = value;
    }

    public void SetTargetPos(Vector3 pos)
    {
        targetPos = pos;
        moveDir = (targetPos - (Vector2)transform.position).normalized;
    }

    public void Move()
    {
        if (!movable)
            return;

        transform.Translate(moveDir * moveSpped * Time.deltaTime);
    }

    public void Stop()
    {
        targetPos = transform.position;
    }
}
