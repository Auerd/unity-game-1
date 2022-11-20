using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToPlay : MonoBehaviour
{
    public void OnClick()
    {
        SceneTransition.SwitchToScene("Game");
    }
}
