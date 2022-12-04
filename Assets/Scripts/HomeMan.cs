using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeMan : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Task1()
    {
        SceneManager.LoadScene("Task1");
    }
    public void Task2()
    {
        SceneManager.LoadScene("Task2");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
