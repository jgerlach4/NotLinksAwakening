using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }

    void Attack()
    {
        Debug.Log("Player Attack!");
        // Implement attack logic here (e.g., play animation, deal damage, etc.)
    }
}
