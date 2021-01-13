using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    string scenePath = null;

    bool loading = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void LoadScene()
    {
        SceneManager.LoadScene(scenePath);
    }

    public void LoadSceneAsyncSingle()
    {
        if (!loading)
        {
            loading = true;
            SceneManager.LoadSceneAsync(scenePath, LoadSceneMode.Single);
        }
    }
}
