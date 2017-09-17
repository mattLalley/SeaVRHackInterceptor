using System;
using UnityEngine;

public class TutorialController : MonoBehaviour
{
    public event Action TutorialComplete;

    public void Activate()
    {
        if (TutorialComplete != null)
        {
            TutorialComplete();
        }
    }

}