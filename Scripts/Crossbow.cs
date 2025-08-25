using UnityEngine;

public class Crossbow : MonoBehaviour
{
    private Animator crossbowAnimator;
    public GameObject arrowPrefab;
    public Transform arrowSpawnPoint;
    public float arrowSpeed = 10f;

    private bool canShoot = true;
    public float cooldownTime = 2f; // Cooldown time in seconds

    public AudioSource crossbowShot;

    private void Start()
    {
        crossbowAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            LoadCrossbow();
        }

        if (Input.GetMouseButtonDown(0))
        {
            ReleaseBolt();
        }
    }

    // Function to fire the crossbow
    public void LoadCrossbow()
    {
        crossbowAnimator.SetBool("Fire", true);
    }

    // Function to release the bolt
    public void ReleaseBolt()
    {
        if (crossbowAnimator.GetBool("Fire") && canShoot)
        {
            crossbowAnimator.SetBool("Fire", false);
            StartCoroutine(StartCooldown());
            ShootArrow();
            crossbowShot.Play();
        }
    }

    // Function to instantiate and shoot an arrow
    private void ShootArrow()
    {
        GameObject arrow = Instantiate(arrowPrefab, arrowSpawnPoint.position, arrowSpawnPoint.rotation);
        Rigidbody arrowRigidbody = arrow.GetComponent<Rigidbody>();
        arrowRigidbody.AddForce(arrowSpawnPoint.up * arrowSpeed, ForceMode.Impulse);
    }
    private System.Collections.IEnumerator StartCooldown()
    {
        canShoot = false; // Disable shooting
        yield return new WaitForSeconds(cooldownTime);
        canShoot = true; // Enable shooting after cooldown time
    }
}
