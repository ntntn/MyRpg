using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField]
    string sceneName;

    public void Load()
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);    
    }

    IEnumerator LoadLevel()
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        yield return null;
        SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
    }
}
