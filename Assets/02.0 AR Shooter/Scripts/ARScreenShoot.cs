using UnityEngine;
using UnityEngine.InputSystem;

public class ARScreenShoot : MonoBehaviour
{
    public InputActionReference tapAction; // Assign "Touchscreen Gestures/Tap Start Position" here
    public GameObject projectile;
    public float shotSpeed = 4f;

    void OnEnable()
    {
        //tapAction.action.performed += OnTapDetected;
        //tapAction.action.Enable();
    }

    void OnDisable()
    {
        //tapAction.action.performed -= OnTapDetected;
        //tapAction.action.Disable();
    }

    private void OnTapDetected(InputAction.CallbackContext context)
    {
        GameObject newProjectile = Instantiate(projectile);
        newProjectile.transform.position = transform.position;
        Vector3 shotVelocity = transform.forward * shotSpeed;
        newProjectile.GetComponent<Rigidbody>().linearVelocity = shotVelocity;
    }

    public void ShootWithPrefab(GameObject projectileToSpawn)
    {
        GameObject newProjectile = Instantiate(projectileToSpawn);
        newProjectile.transform.position = transform.position;
        Vector3 shotVelocity = transform.forward * shotSpeed;
        newProjectile.GetComponent<Rigidbody>().linearVelocity = shotVelocity;
    }
    
    
}
