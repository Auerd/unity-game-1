using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class DialogueTrigger : MonoBehaviour
{
    [SerializeField]
    private Dialogue dialogue;
    [SerializeField]
    private DialogueManager manager;

    private new Collider2D collider;

    private void Start()
    {
        collider = GetComponent<Collider2D>();
        collider.isTrigger = true;
    }
    private void Update()
    {

    }
}
