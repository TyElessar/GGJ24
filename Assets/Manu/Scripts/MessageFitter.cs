using System.Collections;
using UnityEngine;
using TMPro;

public class MessageFitter : MonoBehaviour {

  [SerializeField] private TextMeshProUGUI tmp_;
  [SerializeField] private Bounds textBounds_;

  void Start(){
    textBounds_ = tmp_.bounds;
    Debug.Log(textBounds_);
  }


}
