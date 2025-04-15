using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 targetPoint = Vector3.zero;
    public Player player;
    public float moveSpeed;
    public float lookAheadDistance = 5f, lookAheadSpeed = 3f;
    private float lookOffset;

    void Start()
    {
        targetPoint = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
    }

    void LateUpdate()
    {
        //targetPoint.x = player.transform.position.x;
        //targetPoint.y = player.transform.position.y;

        if (!player.isFalling)
        {
            targetPoint.y = player.transform.position.y;
        }

        if (player.rigid.velocity.x > 0f)
        {
            lookOffset = Mathf.Lerp(lookOffset, lookAheadDistance, lookAheadSpeed * Time.deltaTime);
        }
        if (player.rigid.velocity.x < 0f)
        {
            lookOffset = Mathf.Lerp(lookOffset, -lookAheadDistance, lookAheadSpeed * Time.deltaTime);
        }

        /* if (player.isFalling)
        {
            targetPoint.y = player.transform.position.y; Find some way to check if player is going down or up so the camera can follow the player down but not up necessarily
        } */

        targetPoint.x = player.transform.position.x + lookOffset;

        if (targetPoint.y < -1)
        {
            targetPoint.y = -1;
        }


        transform.position = Vector3.Lerp(transform.position, targetPoint, moveSpeed * Time.deltaTime);
        //transform.position = targetPoint;
    }
}
