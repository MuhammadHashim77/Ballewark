using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void One()
    {
        SceneManager.LoadScene(1);
    }
    public void Two()
    {
        SceneManager.LoadScene(2);
    }
    public void Three()
    {
        SceneManager.LoadScene(3);
    }
}
