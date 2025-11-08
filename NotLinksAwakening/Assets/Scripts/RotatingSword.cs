using UnityEngine;

// Attach this to the enemy GameObject
public class RotatingSwordEnemy : MonoBehaviour
{
    [Header("Sword Settings")]
    [SerializeField] private GameObject swordPrefab;
    [SerializeField] private float rotationSpeed = 100f;
    [SerializeField] private float swordDistance = 1.5f;
    [SerializeField] private int damageAmount = 10;

    private GameObject sword;
    private Transform swordTransform;

    void Start()
    {
        // Create the sword as a child of the enemy
        if (swordPrefab != null)
        {
            sword = Instantiate(swordPrefab, transform);
            swordTransform = sword.transform;

            // Position the sword at the desired distance
            swordTransform.localPosition = new Vector3(swordDistance, 0, 0);

            // Add the damage component to the sword
            SwordDamage dmg = sword.AddComponent<SwordDamage>();
            dmg.damageAmount = damageAmount;
        }
        else
        {
            Debug.LogError("Sword prefab not assigned!");
        }
    }

    void Update()
    {
        // Rotate the sword around the enemy
        if (swordTransform != null)
        {
            swordTransform.RotateAround(transform.position, Vector3.forward, rotationSpeed * Time.deltaTime);
        }
    }
}

// Attach this script to the sword GameObject (added automatically by above script)
public class SwordDamage : MonoBehaviour
{
    [HideInInspector]
    public int damageAmount = 10;

    [SerializeField] private float damageCooldown = 0.5f;
    private float lastDamageTime = -999f;

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if we hit the player and cooldown has passed
        if (other.CompareTag("Player") && Time.time >= lastDamageTime + damageCooldown)
        {
            // Try to get a health component from the player
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
                lastDamageTime = Time.time;
            }
        }
    }
}