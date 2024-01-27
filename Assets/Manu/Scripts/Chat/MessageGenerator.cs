using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class MessageGenerator : MonoBehaviour {

  [SerializeField] private GameObject textMessagePrefab_;
  [SerializeField] private GameObject emoteMessagePrefab_;

  private List<GameObject> messageList_;
  private int maxMessages_;

  enum TextFile {
    kUser = 0,
    kNegative = 1,
    kPositive = 2,
    kNeutral = 3,
    kColor = 4,
    kShitpost = 5,
  }

  private List<string[]> textPool_;
  private List<Sprite> emotePool_;
  private List<string> userPool_;

  private string[] textPath_ = {"Usuarios", "Negativo", "Positivo", "Neutro", "Colores", "Chaterino"};
  private string[] emotePath_ = {"cry", "bye", "troll", "wide", "sit", "sus", "pog", "nerdge", "madge", "stare", "me", "saul", "culiao", "nuke"};

  void InitializeTextResources(string path){
    TextAsset file = Resources.Load<TextAsset>(path);
    textPool_.Add(file.text.Split(';'));
  }

  void InitializeEmoteResources(string path){
    Sprite sprite = Resources.Load<Sprite>(path);
    emotePool_.Add(sprite);
  }

  void Awake(){
    //Initialize list
    messageList_ = new List<GameObject>();
    userPool_ = new List<string>();
    emotePool_ = new List<Sprite>();
    textPool_ = new List<string[]>();

    for(int i = 0; i < textPath_.Length; ++i){
      string path = "TextFiles/" + textPath_[i];
      InitializeTextResources(path);
    }

    for(int i = 0; i < emotePath_.Length; ++i){
      string path = "Emotes/" + emotePath_[i];
      InitializeEmoteResources(path);
    }

    //Get the total number of possible message
    maxMessages_ = textPool_[(int)TextFile.kUser].Length 
                 + textPool_[(int)TextFile.kNeutral].Length 
                 + textPool_[(int)TextFile.kPositive].Length 
                 + textPool_[(int)TextFile.kNegative].Length;

    //Create a user pool
    for(int i = 0; i < textPool_[(int)TextFile.kUser].Length; ++i){
      GetUserNickname(i);
    }

    This is for testing only --- Emote
    for(int i = 0; i < textPool_[(int)TextFile.kUser].Length; ++i){
      GameObject go = Instantiate(textMessagePrefab_);
      Transform child_tr = go.transform.GetChild(0);
      var temp = child_tr.gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = userPool_[i] + textPool_[(int)TextFile.kShitpost][0];
      go.SetActive(false);
      DontDestroyOnLoad(go);
      messageList_.Add(go);
    }

    //This is for testing only --- Emote
    for(int i = 0; i < userPool_.Count; ++i){
      GameObject go = Instantiate(emoteMessagePrefab_);
      var image = go.gameObject.GetComponent<Image>();
      image.sprite = emotePool_[Random.Range(0, emotePool_.Count - 1)];
      go.SetActive(false);
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

  private void GetUserNickname(int index){
    string color = "<color=" + textPool_[(int)TextFile.kColor][Random.Range(0, textPool_[(int)TextFile.kColor].Length - 1)] + ">";
    string nick = color + textPool_[(int)TextFile.kUser][index] + "</color> ";
    userPool_.Add(nick);
  }


}
