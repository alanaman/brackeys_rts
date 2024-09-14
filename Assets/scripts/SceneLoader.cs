using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader
{


    //public enum Scene
    //{
    //    Main1,
    //}


    private static string targetScene;


    public static void Load(string targetScene)
    {
        SceneLoader.targetScene = targetScene;

        SceneManager.LoadScene("LoadingScene");
    }

    public static void LoaderCallback()
    {
        SceneManager.LoadScene(targetScene);
    }

}