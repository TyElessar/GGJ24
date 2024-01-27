using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour {

  public void ChangeLevel(int i){
    SceneManager.LoadScene(i, LoadSceneMode.Single);
  }

}
