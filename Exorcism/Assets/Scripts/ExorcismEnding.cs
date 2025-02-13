using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExorcismEnding : MonoBehaviour
{

    public GameObject buttons;
    public GameObject win;
    public GameObject lose;

    // 8 bit fading
    public GameObject fade1;
    public GameObject fade2;
    public GameObject fade3;

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

    public void StartG()
    {
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {

        fade1.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        fade2.SetActive(true);
        yield return new WaitForSeconds(0.3f);
        fade3.SetActive(true);
        //  yield return new WaitForSeconds(0.3f);

        Debug.Log("we good");
        SceneManager.LoadScene(1);
    }

}
