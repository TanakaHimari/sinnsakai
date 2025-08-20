using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // �v���C���[��Transform
    public Vector3 offset = new Vector3(0, 2f, -10f); // �J�����̃I�t�Z�b�g�iY�����߂Ɂj

    void LateUpdate()
    {
        if (player != null)
        {
            Vector3 targetPos = player.position + offset;
            transform.position = new Vector3(targetPos.x, targetPos.y, offset.z);
        }
    }

}
