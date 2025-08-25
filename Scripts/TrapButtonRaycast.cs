using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrapButtonRaycast : MonoBehaviour
{
    [SerializeField] private int rayLength = 5;
    [SerializeField] private LayerMask layerMaskInteract;
    [SerializeField] private string excludeLayerName = null;

    private HealthSystem playerHealth; // Reference to the player's HealthSystem

    [SerializeField] private KeyCode openDoorKey = KeyCode.E;

    [SerializeField] private Image crosshair = null;
    private bool isCrosshairActive;
    private bool doOnce;

    private const string interactableTag = "TrapButton";

    private void Start()
    {
        // Find and cache the HealthSystem script on the player GameObject
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthSystem>();
    }

    private void Update()
    {
        RaycastHit hit;
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        int mask = 1 << LayerMask.NameToLayer(excludeLayerName) | layerMaskInteract.value;

        if (Physics.Raycast(transform.position, fwd, out hit, rayLength, mask))
        {
            if (hit.collider.CompareTag(interactableTag))
            {
                isCrosshairActive = true;
                doOnce = true;

                if (Input.GetKeyDown(openDoorKey))
                {
                    // Damage the player's health by 25 when the button is pressed
                    playerHealth.TakeDamage(25);
                    Debug.Log("Player took 25dmg");
                }
            }
        }
        else
        {
            if (isCrosshairActive)
            {
                CrosshairChange(false);
                doOnce = false;
            }
        }
    }

    void CrosshairChange(bool on)
    {
        if (on && !doOnce)
        {
            crosshair.color = Color.red;
        }
        else
        {
            crosshair.color = Color.white;
            isCrosshairActive = false;
        }
    }
}
