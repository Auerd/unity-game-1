using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class TextButtonManager : MonoBehaviour
{
    Animator animator;
    TextMeshProUGUI textMeshPro;
    Button button;
    SectionManager sectionManager;

    void Start()
    {
        animator = GetComponent<Animator>();
        textMeshPro = GetComponent<TextMeshProUGUI>();
        button = GetComponent<Button>();
        textMeshPro.alpha = 0;
        GoButtonOff();
        sectionManager = GetComponentInParent<SectionManager>();
#if UNITY_EDITOR
        if (sectionManager == null)
        {
            Debug.LogError("Button " + transform.name + " is not in parent with SectionManager");
            EditorApplication.isPlaying = false;
        }
#endif
    }


    public void In()
    {
        animator.SetTrigger("In");
    }

    public void Out()
    {
        animator.SetTrigger("Out");
    }

    public void GoButtonOff()
    {
        button.enabled = false;
    }

    public void GoButtonOn()
    {
        button.enabled = true;
    }

    public void GoObjectOff()
    {
        gameObject.SetActive(false);
    }
}
