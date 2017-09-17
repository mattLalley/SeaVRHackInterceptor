using UnityEngine;

public class CastleController : MonoBehaviour
{
    private readonly int HAPPINESS_THRESHOLD = 10;
    private readonly string DOG_TREAT = "dog_treat";
    private readonly string FISH_TREAT = "fish_treat";

    private bool _active;
    private int _happiness;

    public void Activate()
    {
        _active = true;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (_active)
        {
            if (other.collider.name.Equals(DOG_TREAT) || other.collider.name.Equals(FISH_TREAT))
            {
                _happiness++;
                GameManager.Instance.SendTreatAnalyticEvent();
                if (_happiness > HAPPINESS_THRESHOLD)
                {
                    CompleteGame();
                }
            }
        }
    }

    private void CompleteGame()
    {
        GameManager.Instance.CompleteGame();
    }
}