using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnSceneCall : MonoBehaviour
{
    [SerializeField] string sceneName;

    public void OnCall()
    {
        SceneManager.LoadScene(sceneName);
    }
}
