using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MessageGenerator : MonoBehaviour {

  [SerializeField] private TextAsset chaterino_;

  [SerializeField] private GameObject messagePrefab_;
  [SerializeField] private List<GameObject> messageList_;
  private int maxMessages_;

  private string[] messagePoolText_;

  void Awake(){
    messagePoolText_ = chaterino_.text.Split(';');
    maxMessages_ = messagePoolText_.Length;

    messageList_ = new List<GameObject>();
    for(int i = 0; i < maxMessages_; ++i){
      GameObject go = Instantiate(messagePrefab_);
      Transform child_tr = go.transform.GetChild(0);
      child_tr.gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = messagePoolText_[i];
      messagePrefab_.SetActive(false);
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

}
