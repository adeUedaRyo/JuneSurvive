using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    [SerializeField] string sceneName;

    public void StageChange()
    {
        //指定された名前のシーンを呼び出す
        SceneManager.LoadScene(sceneName);
    }
}
