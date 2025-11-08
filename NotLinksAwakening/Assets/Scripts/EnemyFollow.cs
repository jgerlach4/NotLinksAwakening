using UnityEngine;
using UnityEngine.Windows;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField] private float speed = 3.0f;

    private GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //if ()
        //{
        //    GetComponent<SpriteRenderer>().flipX = false;
        //    m_facingDirection = 1;
        //}
        //else if (inputX < 0)
        //{
        //    GetComponent<SpriteRenderer>().flipX = true;
        //    m_facingDirection = -1;
        //}
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
}
