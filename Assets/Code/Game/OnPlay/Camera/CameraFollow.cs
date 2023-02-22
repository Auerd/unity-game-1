using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public float smooth;

    private void Start()
    {
        transform.position = player.transform.position;
    }

    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, player.transform.position, Time.deltaTime * smooth);
    }
}
