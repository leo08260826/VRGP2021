using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene1ChangeScene : MonoBehaviour
{
    public int sceneNum;
    
    public void ChangeScene()
    {
        SceneManager.LoadScene("Scene" + sceneNum.ToString());
    }
}
