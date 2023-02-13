using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextButtonManager : MonoBehaviour
{
    Animator animator;
    TextMeshProUGUI textMeshPro;
    Button button;

    private void Start()
    {
        animator = GetComponent<Animator>();
        textMeshPro = GetComponent<TextMeshProUGUI>();
        button = GetComponent<Button>();
        textMeshPro.alpha = 0;
        button.enabled = false;
    }

    public void In()
    {
        animator.SetTrigger("In");
        button.enabled = true;
    }

    public void Out()
    {
        button.enabled = false;
        animator.SetTrigger("Out");
    }
}
