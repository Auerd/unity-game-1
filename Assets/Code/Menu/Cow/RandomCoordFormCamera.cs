using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCoordFormCamera : MonoBehaviour
{
    public Camera display;

    public float speed;

    public int seconds_end_move_randstart;
    public int seconds_end_move_end;

    [SerializeField]
    private Vector2 force;
    [SerializeField]
    private Vector2 point;

    private Rigidbody2D rb;

    private bool pauseEnd;
    private bool go;

    void Start()
    {
        pauseEnd = true;

        rb = GetComponent<Rigidbody2D>();

        // Sets random position and force
        rb.position = new Vector2(Random.Range(-display.pixelWidth / 2, display.pixelWidth / 2),
                                  Random.Range(-display.pixelHeight / 2, display.pixelHeight / 2));
        force = new Vector2(Random.Range(-100f, 100f) / 100,
                            Random.Range(-100f, 100f) / 100);
        force.Normalize();

        StartCoroutine(RandomForce());
    }
    // Generates new force and manage the cycle
    IEnumerator RandomForce()
    {
        while (pauseEnd)
        {
            yield return new WaitForSeconds(Random.Range(seconds_end_move_randstart,
                                                         seconds_end_move_end));
            go = true;
            StartCoroutine(ToPoint());

            yield return new WaitForSeconds(Random.Range(seconds_end_move_randstart,
                                                         seconds_end_move_end));
            go = false;

            // Creates new force
            force = new Vector2(Random.Range(-100f, 100f) / 100,
                                Random.Range(-100f, 100f) / 100);
            force.Normalize();
        }

    }
    // The cycle
    IEnumerator ToPoint()
    {
        while(true)
        {
            rb.MovePosition(rb.position + force * speed);
            yield return null;
            if (!go) yield break;
        }
    }
}
