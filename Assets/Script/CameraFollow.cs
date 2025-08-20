using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // プレイヤーのTransform
    public Vector3 offset = new Vector3(0, 2f, -10f); // カメラのオフセット（Yを高めに）

    void LateUpdate()
    {
        if (player != null)
        {
            Vector3 targetPos = player.position + offset;
            transform.position = new Vector3(targetPos.x, targetPos.y, offset.z);
        }
    }

}
