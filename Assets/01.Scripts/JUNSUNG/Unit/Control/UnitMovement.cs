using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitMovement : UnitComponent//, IAffectedStatus
{
    private float MoveSpeed => controller.Stat.GetStatus(StatusType.MoveSpeed);
    private bool movable = true;
    private Vector2 targetPos;
    private Vector2 moveDir;

    public Vector2 TargetPos => targetPos;

    private Transform visual;

    public override void Init(UnitController _controller)
    {
        base.Init(_controller);
        targetPos = transform.position;
        visual = transform.Find("Visual").transform;
    }

    protected override void UnitUpdate()
    {
        Transform target = controller.Target;

        if (target != null)
            SetTargetPos(target.position);
    }

    public void SetMovable(bool value)
    {
        movable = value;
    }

    public void SetTargetPos(Vector2 pos)
    {
        targetPos = pos;
        moveDir = (targetPos - (Vector2)transform.position).normalized;

        if (moveDir.x > 0)
            visual.rotation = Quaternion.Euler(0, 180, 0);
        else
            visual.rotation = Quaternion.Euler(0, 0, 0);
    }

    public void Move()
    {
        if (!movable)
            return;

        transform.Translate(moveDir * MoveSpeed * Time.deltaTime);
    }

    public void Stop()
    {
        targetPos = transform.position;
    }

    //public void OnStatusChange(StatusType type, int value)
    //{
    //    if (type == StatusType.MoveSpeed)
    //        moveSpeed = DefaultMoveSpeed * value;
    //}
}
