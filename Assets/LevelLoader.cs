using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && SceneManager.GetActiveScene().buildIndex == 0 || SceneManager.GetActiveScene().buildIndex == 3){

            LoadNextLevel();
        }
    }

    public void LoadNextLevel(){
        if(SceneManager.GetActiveScene().buildIndex == 0){
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        }
        if(SceneManager.GetActiveScene().buildIndex == 3){
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex - 1));
        }
        if(SceneManager.GetActiveScene().buildIndex == 2){
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        }
    }

    IEnumerator LoadLevel(int levelIndex){
        yield return new WaitForSeconds(4);
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(levelIndex);
    }
}
