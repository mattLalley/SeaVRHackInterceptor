using UnityEngine;

public class AnalyticsController : MonoBehaviour
{
    private int _numberOfLicks;
    public int NumberOfLicks
    {
        get { return _numberOfLicks; }
        set { _numberOfLicks = value; }
    }

    private int _numberOfTreats;
    public int NumberOfTreats
    {
        get { return _numberOfTreats; }
        set { _numberOfTreats = value; }
    }

    private void Start()
    {
        GameManager.Instance.LickEventOccurred += LickEventOccurred;
        GameManager.Instance.TreatEventOccurred += TreatEventOccurred;
    }
    
    public void LickEventOccurred()
    {
        _numberOfLicks++;
    }

    public void TreatEventOccurred()
    {
        _numberOfTreats++;
    }

    public void ResetAnalyticData()
    {
        _numberOfLicks = 0;
        _numberOfTreats = 0;
    }
}