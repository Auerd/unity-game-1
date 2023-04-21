using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class DialogueTrigger : MonoBehaviour
{
    [SerializeField]
    private Dialogue dialogue;
    
    [SerializeField]
    private Collider2D playerCollider;

    [SerializeField]
    private DialogueManager dialogueManager;

    private void Start() {
    }
    private void OnTriggerEnter2D(Collider2D collider) {
        if(collider==playerCollider) dialogueManager.currentDialogue = dialogue;
    }
    private void OnTriggerExit2D(Collider2D collider) {
        if(collider==playerCollider) dialogueManager.currentDialogue = null;
    }
}
