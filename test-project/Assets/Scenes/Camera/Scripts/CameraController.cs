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


    // —корость смещени€ камеры.
    private float lerpSpeedX = 1f;
    private float lerpSpeedY = 1f;

    // –ассто€ние между текущей и предыдущей позицией игрока, при превышении которого камера перемещаетс€ к игроку.
    // Ёто нужно, например, если если игрок незначительно смещаетс€ по оси Y когда медленно движетс€ (координата по Y смещаетс€ на сотые доли даже на идеально ровной поверхности).
    private float cameraMoveDifference = 0.01f;



    void Awake()
    {

        // Ќаходим игрока.
        player = GameObject.Find("Player");
        playerTransform = player.GetComponent<Transform>();

        // ѕолучаем текущую и последнюю позицию игрока по ос€м - в начале они равны.
        playerCurrentTransformPositionX = playerTransform.position.x;
        playerCurrentTransformPositionY = playerTransform.position.y;
        playerLastTransformPositionX = playerTransform.position.x;
        playerLastTransformPositionY = playerTransform.position.y;

        // ”станавливаем камеру.
        transform.position = new Vector3(playerCurrentTransformPositionX, playerCurrentTransformPositionY, transform.position.z);
    }





    void Update()
    {

        // ѕолучаем текущую и последнюю позицию игрока по ос€м в каждом апдейте.
        playerCurrentTransformPositionX = playerTransform.position.x;
        playerCurrentTransformPositionY = playerTransform.position.y;

        // ≈сли изменение позиции больше чем значение дл€ смещени€ камеры - смещаем камеру.
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
