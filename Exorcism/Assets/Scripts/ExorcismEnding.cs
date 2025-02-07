using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExorcismEnding : MonoBehaviour
{

    public GameObject buttons;
    public GameObject win;
    public GameObject lose;

    // Start is called before the first frame update
    void Start()
    {
        buttons.SetActive(true);
    }

    public void Fail()
    {
        buttons.SetActive(false);
        lose.SetActive(true);
    }

    public void Win()
    {
        buttons.SetActive(false);
        win.SetActive(true);
    }

    public void Reset()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
