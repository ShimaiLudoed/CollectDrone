using Data;
using System;
using UnityEngine;
using Zenject;

namespace Player
{
  public class Score : MonoBehaviour
  {
    [SerializeField] private int redScore;
    [SerializeField] private int blueScore;
    private TextData _textData;

    [Inject]
    public void Construct(TextData textData)
    {
      _textData = textData;
    }

    private void Start()
    {
      UpdateText();
    }

    public void AddBlueScore()
    {
      blueScore++;
      UpdateText();
    }

    public void AddRedScore()
    {
      redScore++;
      UpdateText();
    }
    private void UpdateText()
    {
      _textData.RedResources.text = "Red Score: " + redScore.ToString();
      _textData.BlueResources.text = "Blue Score: " + blueScore.ToString();
    }
  }
}
