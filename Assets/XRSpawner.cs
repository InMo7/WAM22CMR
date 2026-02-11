using UnityEngine;
using UnityEngine.InputSystem;

public class XRSpawner : MonoBehaviour
{
    [Header("Settings")]
    public GameObject prefabToSpawn;
    public Transform spawnPoint;

    [Header("Input")]
    public InputActionReference spawnActionReference;

    private void OnEnable()
    {
        // Subscribe to the 'performed' event (when the button is pressed)
        spawnActionReference.action.Enable();
        spawnActionReference.action.performed += OnSpawnButtonPressed;
    }

    private void OnDisable()
    {
        // Unsubscribe to avoid memory leaks
        spawnActionReference.action.performed -= OnSpawnButtonPressed;
    }

    private void OnSpawnButtonPressed(InputAction.CallbackContext context)
    {
        SpawnObject();
    }

    public void SpawnObject()
    {
        if (prefabToSpawn != null && spawnPoint != null)
        {
            Instantiate(prefabToSpawn, spawnPoint.position, spawnPoint.rotation);
        }
        else
        {
            Debug.LogWarning("XRSpawner: Prefab or SpawnPoint is missing!");
        }
    }
}