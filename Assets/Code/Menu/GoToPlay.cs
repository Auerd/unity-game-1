using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToPlay : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene("Game");
    }
}
