using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private GameObject _gameUI;
    private bool _active;
    
    public void Activate()
    {
        _active = true;
        _gameUI.SetActive(true);
    }

    public void Deactivate()
    {
        _active = false;
        _gameUI.SetActive(false);
    }
}