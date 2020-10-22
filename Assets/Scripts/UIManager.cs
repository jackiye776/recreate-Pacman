using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void LoadLevelOne()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene(0);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void QuitGame()
    {
        Destroy(gameObject);
        SceneManager.LoadScene(1);
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if(scene.buildIndex == 0)
        {
            Button button = GameObject.FindGameObjectWithTag("QuitGame").GetComponent<Button>();
            button.onClick.AddListener(QuitGame);
        }
    }



}
