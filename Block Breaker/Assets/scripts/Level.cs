using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{

    [SerializeField]int breakableBlocks;
    //cached ref
    SceneLoader Sceneloader;
    
    // Start is called before the first frame update
    private void Start()
    {
        Sceneloader = FindObjectOfType<SceneLoader>();    
    }
  public void countBlocks()
  {
      breakableBlocks++;
  }
  public void BlockDestroyed()
  {
      breakableBlocks--;
      if(breakableBlocks  <= 0)
      {
          Sceneloader.LoadNextScene();
      }
  }

}
