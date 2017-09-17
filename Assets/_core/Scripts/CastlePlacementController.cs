using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.iOS;

public class CastlePlacementController : MonoBehaviour
{
    [SerializeField] private GameObject _findingPlane;
    [SerializeField] private GameObject _castlePreview;
    [SerializeField] private GameObject _castlePrefab;
    [SerializeField] private float _createHeight;
    [SerializeField] private float _findingDist = 0.5f;

    public event Action CastlePlacementComplete;
    
    public enum FocusState
    {
        Initializing,
        Finding,
        Found
    }

    private FocusState _castleFocusState;
    public FocusState CastleFocusState
    {
        get { return _castleFocusState; }
        set
        {
            _castleFocusState = value;
            _castlePreview.SetActive(_castleFocusState == FocusState.Found);
            _findingPlane.SetActive(_castleFocusState != FocusState.Found);
        }
    }

    private bool _trackingInitialized;
    private bool _castlePlaced = true;

    // Use this for initialization
    public void Activate()
    {
        CastleFocusState = FocusState.Initializing;
        _trackingInitialized = true;
        CastlePlacementComplete();
    }

    // Update is called once per frame
    void Update()
    {
        if (_castlePlaced)
        {
            return;
        }
        //use center of screen for focusing
        Vector3 center = new Vector3(Screen.width / 2, Screen.height / 2, _findingDist);
        var screenPosition = Camera.main.ScreenToViewportPoint(center);
        ARPoint point = new ARPoint
        {
            x = screenPosition.x,
            y = screenPosition.y
        };

        // prioritize reults types
        ARHitTestResultType[] resultTypes =
        {
            ARHitTestResultType.ARHitTestResultTypeExistingPlaneUsingExtent
        };

        foreach (ARHitTestResultType resultType in resultTypes)
        {
            if (HitTestWithResultType(point, resultType))
            {
                CastleFocusState = FocusState.Found;
                CheckForInput(point);
                return;
            }
        }

        //if you got here, we have not found a plane, so if camera is facing below horizon, display the focus "finding" square
        if (_trackingInitialized)
        {
            CastleFocusState = FocusState.Finding;

            //check camera forward is facing downward
            if (Vector3.Dot(Camera.main.transform.forward, Vector3.down) > 0)
            {
                //position the focus finding square a distance from camera and facing up
                _findingPlane.transform.position = Camera.main.ScreenToWorldPoint(center);

                //vector from camera to focussquare
                Vector3 vecToCamera = _findingPlane.transform.position - Camera.main.transform.position;

                //find vector that is orthogonal to camera vector and up vector
                Vector3 vecOrthogonal = Vector3.Cross(vecToCamera, Vector3.up);

                //find vector orthogonal to both above and up vector to find the forward vector in basis function
                Vector3 vecForward = Vector3.Cross(vecOrthogonal, Vector3.up);


                _findingPlane.transform.rotation = Quaternion.LookRotation(vecForward, Vector3.up);
            }
            else
            {
                //we will not display finding square if camera is not facing below horizon
                _findingPlane.SetActive(false);
            }
        }
    }

    private bool HitTestWithResultType(ARPoint point, ARHitTestResultType resultTypes)
    {
        List<ARHitTestResult> hitResults =
            UnityARSessionNativeInterface.GetARSessionNativeInterface().HitTest(point, resultTypes);
        if (hitResults.Count > 0)
        {
            foreach (var hitResult in hitResults)
            {
                _castlePreview.transform.position = UnityARMatrixOps.GetPosition(hitResult.worldTransform);
                _castlePreview.transform.rotation = UnityARMatrixOps.GetRotation(hitResult.worldTransform);
                Debug.Log(string.Format("x:{0:0.######} y:{1:0.######} z:{2:0.######}",
                    _castlePreview.transform.position.x, _castlePreview.transform.position.y,
                    _castlePreview.transform.position.z));
                return true;
            }
        }
        return false;
    }

    private void CheckForInput(ARPoint point)
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                List<ARHitTestResult> hitResults = UnityARSessionNativeInterface.GetARSessionNativeInterface().HitTest(
                    point,
                    ARHitTestResultType.ARHitTestResultTypeExistingPlaneUsingExtent);
                if (hitResults.Count > 0)
                {
                    foreach (var hitResult in hitResults)
                    {
                        Vector3 position = UnityARMatrixOps.GetPosition(hitResult.worldTransform);
                        CreateCastle(new Vector3(position.x, position.y + _createHeight, position.z));
                        break;
                    }
                }
            }
        }
    }


    void CreateCastle(Vector3 atPosition)
    {
        Instantiate(_castlePrefab, atPosition, Quaternion.identity);
        _castlePlaced = true;
        _castlePreview.SetActive(false);
        if (CastlePlacementComplete != null)
        {
            CastlePlacementComplete();

        }
    }
}