using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerControl : MonoBehaviour
{
    [Header("General")]
    [Tooltip("ì/ñ")] [SerializeField] private float speed = 10f;
    [SerializeField] private float xClamp = 10.5f;
    [SerializeField] private float yClamp = 7f;

    [Header("Rotation")]
    [SerializeField] private float xRotFactor = -5f;
    [SerializeField] private float yRotFactor = 5f;
    [SerializeField] private float zRotFactor = 4f;

    [Header("RotationOnMove")]
    [SerializeField] private float xMoveRot = 10f;
    [SerializeField] private float yMoveRot = -10f;
    [SerializeField] private float zMoveRot = -10f;

    private float xMove;
    private float yMove;
    private bool isControlEnabled = true;

    void Update()
    {
        if (isControlEnabled)
        {
            MoveShip();
            RotateShip();
        }
    }

    void OnStartDeath()
    {
        isControlEnabled = false;
    }

    void MoveShip()
    {
        xMove = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xMove * speed * Time.deltaTime;
        yMove = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yMove * speed * Time.deltaTime;

        float newPositionX = transform.localPosition.x + xOffset;
        float xClampPosition = Mathf.Clamp(newPositionX, -xClamp, this.xClamp);

        float newPositionY = transform.localPosition.y + yOffset;
        float yClampPosition = Mathf.Clamp(newPositionY, -yClamp, yClamp);

        transform.localPosition = new Vector3(xClampPosition, yClampPosition, transform.localPosition.z);
    }

    void RotateShip()
    {
        float xRot = transform.localRotation.y * xRotFactor + yMove * yMoveRot;
        float yRot = transform.localRotation.x * yRotFactor + xMove * xMoveRot;
        float zRot = xMove * zMoveRot;

        transform.localRotation = Quaternion.Euler(xRot, yRot, zRot);
    }
}
