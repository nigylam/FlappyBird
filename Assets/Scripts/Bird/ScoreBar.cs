using TMPro;
using UnityEngine;

public class ScoreBar : MonoBehaviour
{
    [SerializeField] private ScoreCounter _counter;
    [SerializeField] private TextMeshProUGUI _text;

    private void OnEnable()
    {
        _counter.Changed += OnScoreChanged;
    }

    private void OnDisable()
    {
        _counter.Changed -= OnScoreChanged;
    }

    private void OnScoreChanged(int scores)
    {
        _text.text = scores.ToString();
    }
}
