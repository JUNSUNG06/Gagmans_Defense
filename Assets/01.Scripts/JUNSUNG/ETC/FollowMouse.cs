using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FollowMouse : MonoBehaviour
{
    public bool allowFollow = false;

    public Vector2 CameraSize = new Vector2(16, 9);
    public float FollowZoneOffset = 0.7f;
    public float Speed = 5f;

    private Camera cam;
    private Vector2 followZone;
    private Vector3 mousePos;
    private Vector2 distanceFromCam;

    private void Start()
    {
        cam = Camera.main;
        followZone = CameraSize * FollowZoneOffset;
    }

    private void LateUpdate()
    {
        if (UIManager.Instance.isUIOpen || !allowFollow)
            return;

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        distanceFromCam = mousePos - transform.position;

        if(distanceFromCam.x > followZone.x || distanceFromCam.y > followZone.y
            || distanceFromCam.x < -followZone.x || distanceFromCam.y < -followZone.y)
        {
            mousePos.z = transform.position.z;
            transform.position = Vector3.Lerp(transform.position, mousePos, Time.deltaTime * Speed);
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(Camera.main.transform.position, CameraSize * FollowZoneOffset * 2);
    }
#endif
}
