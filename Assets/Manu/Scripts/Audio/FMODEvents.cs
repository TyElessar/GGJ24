using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMODEvents : MonoBehaviour {

  public static FMODEvents Instance { get; private set; }

  void Awake(){
    DontDestroyOnLoad(this);
    if(null == Instance)
      Instance = this;
    else 
      Destroy(gameObject);
  }


}
