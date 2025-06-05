using System;
using UnityEngine;

namespace Core
{
  public class Exit : MonoBehaviour
  {
    private void Update()
    {
      if (Input.GetKeyDown(KeyCode.Escape))
      {
        ExitGame();
      }
    }

    public void ExitGame()
    {
      Application.Quit();
      #if UNITY_EDITOR
      UnityEditor.EditorApplication.isPlaying = false;
      #endif
    }
  }
}
