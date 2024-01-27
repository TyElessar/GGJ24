using System.Collections.Generic;
using UnityEngine;

public class ChatManager : MonoBehaviour {

  [SerializeField] private MessageGenerator messageGenerator_; 
  [SerializeField] private List<GameObject> messageDisplayedList_;

  private void Start(){
    messageGenerator_ = FindObjectOfType<MessageGenerator>();
    if(null == messageGenerator_) 
      Debug.Log("No");


    messageDisplayedList_ = new List<GameObject>();
  }

  private void Update(){
    if(Input.GetButtonDown("Jump")){
      GameObject go = messageGenerator_.GetMessage();
      go.transform.SetParent(transform, false);
      messageDisplayedList_.Add(go);
    }
  }

}
