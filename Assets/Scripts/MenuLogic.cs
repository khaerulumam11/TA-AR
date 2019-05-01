using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuLogic : MonoBehaviour
{
    public GameObject menuPanel;
    public GameObject tentangPanel;

    public string namaScene;
    // Start is called before the first frame update
    void Start()
    {
        menuPanel.SetActive(true);
        tentangPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGameClicked() {
        Application.LoadLevel(1);
    }

    public void TentangClicked() {
        tentangPanel.SetActive(true);
        menuPanel.SetActive(false);
    }

    public void QuitGameClick() {
        Application.Quit();
    }

    public void BackToMenuClick() {
        menuPanel.SetActive(true);
        tentangPanel.SetActive(false);
    }

    public void PindahScene() {

        Scene sceneIni = SceneManager.GetActiveScene();
        if (sceneIni.name != namaScene) {
            SceneManager.LoadScene(namaScene);
        }
    }
}
