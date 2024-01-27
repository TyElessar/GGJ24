using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour {

  public static GameManager Instance;

  void Awake(){
    DontDestroyOnLoad(this);
    if(null == Instance)
      Instance = this;
    else 
      Destroy(gameObject);
  }

  void OnEnable(){
    SceneManager.sceneLoaded += OnSceneLoad;
  }

  void OnSceneLoad(Scene scene, LoadSceneMode mode){

  }

  void OnDestroy(){
    SceneManager.sceneLoaded -= OnSceneLoad;


  }

  void Update(){
    if(Input.GetMouseButton(0)){
      SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
  }

}
