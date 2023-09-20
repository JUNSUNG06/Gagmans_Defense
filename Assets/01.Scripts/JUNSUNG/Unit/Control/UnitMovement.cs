using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMovement : UnitComponent, IAffectedStatus
{
    private const float DefaultMoveSpeed = 2;

    [SerializeField]
    private float moveSpeed = 5f;
    private bool movable = true;
    private Vector2 targetPos;
    private Vector2 moveDir;

    public Vector2 TargetPos => targetPos;

    public override void Init()
    {
        base.Init();
        targetPos = transform.position;
    }

    protected override void UnitUpdate()
    {
        Debug.Log(controller);
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

        transform.Translate(moveDir * moveSpeed * Time.deltaTime);
    }

    public void Stop()
    {
        targetPos = transform.position;
    }

    public void OnStatusChange(StatusType type, int value)
    {
        if (type == StatusType.MoveSpeed)
            moveSpeed = DefaultMoveSpeed * value;
    }
}
