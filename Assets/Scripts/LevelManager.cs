using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    private string gameOverScene;

    // make singleton
    void Start()
    {
        
    }

    public void EnterSublevel(string sublevelName)
    {
        // "screenshot" the hub level to keep as background
        SceneManager.LoadScene(sublevelName);
    }

}
