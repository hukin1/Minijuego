using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject pausa;
    void Start()
    {
        
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)&& pausa!=null)
        {
            pausa.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void volver()
    {
        Time.timeScale = 1;
        pausa.SetActive(false);
    }
    public void cambioScene(int i)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(i);
    }
    public void Exit()
    {
       Application.Quit();
    }
}
