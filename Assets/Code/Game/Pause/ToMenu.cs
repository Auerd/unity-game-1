using UnityEngine;
using UnityEngine.SceneManagement;

public class ToMenu : MonoBehaviour
{
    // Go to menu
    public void OnClick()
    {
        SceneTransition.SwitchToScene("Menu");
    }
}
