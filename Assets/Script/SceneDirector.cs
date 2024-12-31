using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneDirector : MonoBehaviour
{
    public void TitleToSample()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void BackToTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public void TitleToGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}