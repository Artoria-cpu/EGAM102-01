using UnityEngine.SceneManagement;
using UnityEngine;



public class ChangeSence : MonoBehaviour
{
    public string game = "game";
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void SwitchScene(string game)
    {
        SceneManager.LoadScene(game);

    }

}
