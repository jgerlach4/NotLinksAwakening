using UnityEngine;

public class WorldSpaceHealthBar : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Vector3 offset = new Vector3(0, 1.5f, 0);
    [SerializeField] private Camera cam;

    void Start()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }
    }

    void LateUpdate()
    {
        if (target != null)
        {
            transform.position = target.position + offset;
            transform.rotation = cam.transform.rotation;
        }
    }
}