using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    public float distance = 10.0f;
    public float height = 5.0f;
    public float heightDamping = 2.0f;
    public float rotationDamping = 3.0f;

    public float X = -2;
    public float Z = -13;

    private void LateUpdate()
    {
        if (player == null) return;
        float wantedRotationAngle = player.eulerAngles.y;
        float wantedHeight = player.position.y + height;
        float currentRotationAngle = transform.eulerAngles.y;
        float currentHeight = transform.position.y;

        currentRotationAngle = Mathf.LerpAngle(currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);
        currentRotationAngle = Mathf.Lerp(currentHeight, wantedHeight, heightDamping* Time.deltaTime);

        int currentRotation = 1;

        transform.position -= currentRotation * Vector3.forward * distance;
        // 相机高度和偏移
        transform.position = new Vector3(player.position.x + X, currentHeight, player.position.z+Z);
        // 看向角色
        transform.LookAt(player);
    }
}
