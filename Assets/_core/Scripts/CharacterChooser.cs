using System;
using UnityEngine;
using UnityEngine.UI;

public class CharacterChooser : MonoBehaviour
{
    
    [SerializeField] private GameObject _dogButton;
    [SerializeField] private GameObject _catButton;
    [SerializeField] private Image _backgroundPanel;
    [SerializeField] private Sprite _backgroundImage;
    public event Action CharacterChooserComplete;

    private bool _active;
    
    private void Start()
    {
        _active = false;
    }

    public void Activate()
    {
//        _backgroundPanel.sprite = 
        _dogButton.SetActive(true);
        _catButton.SetActive(true);
        _active = true;
    }

    public void ChooseCats()
    {
        Debug.Log("Cats choosen");
        GameManager.Instance.PlayerTeam = AppManager.PlayerTeam.Cats;
        CharacterChoosen();
    }

    public void ChooseDogs()
    {
        Debug.Log("Dogs choosen");
        GameManager.Instance.PlayerTeam = AppManager.PlayerTeam.Cats;
        CharacterChoosen();
    }
    
    private void CharacterChoosen()
    {
        _active = false;
        _dogButton.SetActive(false);
        _catButton.SetActive(false);
        CharacterChooserComplete();
    }
}