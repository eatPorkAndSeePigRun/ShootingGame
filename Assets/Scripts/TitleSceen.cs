using UnityEngine;
using UnityEngine.SceneManagement;

[AddComponentMenu("MyGame/TitleScreen")]
public class TitleSceen : MonoBehaviour
{
    public void OnButtonGameStart()
    {
        SceneManager.LoadScene("level1");
    }
}
