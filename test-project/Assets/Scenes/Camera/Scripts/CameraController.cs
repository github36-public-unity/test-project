using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    private GameObject player;
    private Transform playerTransform;
    private float playerCurrentTransformPositionX, playerCurrentTransformPositionY;
    private float playerLastTransformPositionX, playerLastTransformPositionY;
    private Vector3 cameraOffset;


    // �������� �������� ������.
    private float lerpSpeedX = 1f;
    private float lerpSpeedY = 1f;

    // ���������� ����� ������� � ���������� �������� ������, ��� ���������� �������� ������ ������������ � ������.
    // ��� �����, ��������, ���� ���� ����� ������������� ��������� �� ��� Y ����� �������� �������� (���������� �� Y ��������� �� ����� ���� ���� �� �������� ������ �����������).
    private float cameraMoveDifference = 0.01f;



    void Awake()
    {

        // ������� ������.
        player = GameObject.Find("Player");
        playerTransform = player.GetComponent<Transform>();

        // �������� ������� � ��������� ������� ������ �� ���� - � ������ ��� �����.
        playerCurrentTransformPositionX = playerTransform.position.x;
        playerCurrentTransformPositionY = playerTransform.position.y;
        playerLastTransformPositionX = playerTransform.position.x;
        playerLastTransformPositionY = playerTransform.position.y;

        // ������������� ������.
        transform.position = new Vector3(playerCurrentTransformPositionX, playerCurrentTransformPositionY, transform.position.z);
    }





    void Update()
    {

        // �������� ������� � ��������� ������� ������ �� ���� � ������ �������.
        playerCurrentTransformPositionX = playerTransform.position.x;
        playerCurrentTransformPositionY = playerTransform.position.y;

        // ���� ��������� ������� ������ ��� �������� ��� �������� ������ - ������� ������.
        if (Mathf.Abs(playerCurrentTransformPositionX - playerLastTransformPositionX) > cameraMoveDifference || Mathf.Abs(playerCurrentTransformPositionY - playerLastTransformPositionY) > cameraMoveDifference)
        {

            Vector2 targetCamPos = new Vector3(playerTransform.position.x + cameraOffset.x, playerTransform.position.y + cameraOffset.y, transform.position.z);

            float newX = Mathf.Lerp(transform.position.x, targetCamPos.x, lerpSpeedX);
            float newY = Mathf.Lerp(transform.position.y, targetCamPos.y, lerpSpeedY);
            transform.position = new Vector3(newX, newY, transform.position.z);

            playerLastTransformPositionX = playerCurrentTransformPositionX;
            playerLastTransformPositionY = playerCurrentTransformPositionY;
        }
    }




}
