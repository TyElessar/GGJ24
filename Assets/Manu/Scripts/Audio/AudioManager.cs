using UnityEngine;
using FMODUnity;

public class AudioManager : MonoBehaviour {     

  public static AudioManager Instance { get; private set; }

void Awake(){
    DontDestroyOnLoad(this);
    if(null == Instance)
      Instance = this;
    else 
      Destroy(gameObject);
  }

  public void PlayOneShot(EventReference sound, Vector3 worldPosition){
    RuntimeManager.PlayOneShot(sound, worldPosition);
  }


  //Log10(viewers)
  //


}
