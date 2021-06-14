using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerControl : MonoBehaviour
{
    [Header("General")]
    [Tooltip("ì/ñ")] [SerializeField] private float speed = 10f;
    [SerializeField] private float xClamp = 10.5f;
    [SerializeField] private float yClamp = 7f;
    [SerializeField] private GameObject[] guns;

    [Header("Rotation")]
    [SerializeField] private float xRotFactor = -5f;
    [SerializeField] private float yRotFactor = 5f;
    [SerializeField] private float zRotFactor = 4f;

    [Header("RotationOnMove")]
    [SerializeField] private float xMoveRot = 10f;
    [SerializeField] private float yMoveRot = -10f;
    [SerializeField] private float zMoveRot = -10f;

    ParticleSystem.EmissionModule EmissionModule; 
    private float xMove;
    private float yMove;
    private bool isControlEnabled = true;
    private bool isParticleEnabled = true;

    void Update()
    {
        if (isControlEnabled)
        {
            MoveShip();
            RotateShip();
            FireGuns();
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

    private void FireGuns()
    {
        if (CrossPlatformInputManager.GetButton("Fire"))
        {
            ActivateGuns();
        }
        else
        {
            DeactivateGuns();
        }
    }

    private void ActivateGuns()
    {
        foreach (var gun in guns)
        {
            EmissionModule = gun.GetComponent<ParticleSystem>().emission;
            isParticleEnabled = EmissionModule.enabled = true;
            print("activate" + guns.Length);
        }
    }
    private void DeactivateGuns()
    {
        foreach (var gun in guns)
        {
            EmissionModule  = gun.GetComponent<ParticleSystem>().emission;
            isParticleEnabled =  EmissionModule.enabled = false;
           
            print("deeeeeee" + guns.Length);
        }
    }
}
