using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MessageGenerator : MonoBehaviour {

  [SerializeField] private TextAsset chaterino_;
  [SerializeField] private TextAsset user_;
  [SerializeField] private TextAsset possitive_;
  [SerializeField] private TextAsset neutral_;
  [SerializeField] private TextAsset negative_;
  [SerializeField] private TextAsset color_;

  [SerializeField] private GameObject messagePrefab_;
  [SerializeField] private List<GameObject> messageList_;
  private int maxMessages_;

  private string[] userPoolText_;
  private string[] positivePoolText_;
  private string[] neutralPoolText_;
  private string[] negativePoolText_;
  private string[] chaterinoPoolText_;
  private string[] colorPoolText_;

  private List<string> userFinalPoolList_;

  void Awake(){
    //Read and parse from the text files
    chaterinoPoolText_ = chaterino_.text.Split(';');
    userPoolText_ = user_.text.Split(';');
    positivePoolText_ = possitive_.text.Split(';');
    neutralPoolText_ = neutral_.text.Split(';');
    negativePoolText_ = negative_.text.Split(';');
    colorPoolText_ = color_.text.Split(';');

    //Get the total number of possible message
    maxMessages_ = chaterinoPoolText_.Length + neutralPoolText_.Length + positivePoolText_.Length + negativePoolText_.Length;

    //Initialize list
    messageList_ = new List<GameObject>();
    userFinalPoolList_ = new List<string>();

    //Create a user pool
    for(int i = 0; i < userPoolText_.Length; ++i){
      userFinalPoolList_.Add(GetUserNickname(i));
    }

    //This is for testing only
    for(int i = 0; i < userFinalPoolList_.Count; ++i){
      GameObject go = Instantiate(messagePrefab_);
      Transform child_tr = go.transform.GetChild(0);
      child_tr.gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = userFinalPoolList_[i] + chaterinoPoolText_[0];
      messagePrefab_.SetActive(false);
      DontDestroyOnLoad(go);
      messageList_.Add(go);
    }

  } 

  public GameObject GetMessage(){
    foreach(GameObject go in messageList_){
      if(!go.activeInHierarchy){
        go.SetActive(true);
        return go;
      }
    }

    return null;
  }

  private string GetUserNickname(int index){
    string color = "<color=" + colorPoolText_[Random.Range(0, colorPoolText_.Length - 1)] + ">";
    string nick = color + userPoolText_[index] + "</color>";
    return nick;
  }

}
