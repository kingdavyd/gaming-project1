using UnityEngine;
using UnityEngine.InputSystem;

public class CrossbowInput : MonoBehaviour
{
    private Crossbow crossbow;
    private InputAction cockArrowAction;
    private InputAction releaseBoltAction;

    private void Start()
    {
        crossbow = GetComponent <Crossbow>();
        cockArrowAction = new InputAction("CockArrow");
        releaseBoltAction = new InputAction("Shoot");
        cockArrowAction.performed += _ => crossbow.LoadCrossbow();
        releaseBoltAction.started += _ => crossbow.ReleaseBolt();
        cockArrowAction.Enable();
        releaseBoltAction.Enable();
    }

    private void OnDisable()
    {
        cockArrowAction.Disable();
        releaseBoltAction.Disable();
    }
}
