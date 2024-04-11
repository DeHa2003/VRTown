using Lessons.Architecture;
using TMPro;
using UnityEngine;

public class FootballScoreVisualize : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textScoreCommandA;
    [SerializeField] private TextMeshProUGUI textScoreCommandB;

    private IDataFootballInteractor footballInteractor;

    public void Initalize()
    {
        footballInteractor = Game.GetInterface<IDataFootballInteractor, FootballInteractor>();
    }

    public void Activate()
    {
        footballInteractor.OnChangedScoreCommandA += VisualizeScoreCommandA;
        footballInteractor.OnChangedScoreCommandB += VisualizeScoreCommandB;
    }

    public void Deactivate()
    {
        footballInteractor.OnChangedScoreCommandA -= VisualizeScoreCommandA;
        footballInteractor.OnChangedScoreCommandB -= VisualizeScoreCommandB;
    }

    private void VisualizeScoreCommandA(int value)
    {
        textScoreCommandA.text = value.ToString();
    }

    private void VisualizeScoreCommandB(int value)
    {
        textScoreCommandB.text = value.ToString();
    }
}
