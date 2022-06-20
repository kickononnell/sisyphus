using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class GameControlScript : MonoBehaviour
{
    [SerializeField] private GameObject _boulder;
    [SerializeField] private GameObject _leftHand, _rightHand;
    [SerializeField] private GameObject _leftPath, _rightPath;
    
    private Transform _bTransform, _lHTransform, _rHTransform, _lPTranform, _rPtransform;

    private float _handOffsetx; //max abs 3
    private float _lHandHeight, _rHandHeight; //max abs 1.5
    private bool _handActiveL, _handActiveR;
    private float _boulderOffset, _boulderSpeed;

    private bool _isPause;
    private float _timer;

    // Start is called before the first frame update
    void Start()
    {
        _lHandHeight = 0;
        _rHandHeight = 0;
        _handOffsetx = 0;
        _handActiveL = true;
        _handActiveR = true;

        _bTransform = _boulder.transform;
        _lHTransform = _leftHand.transform;
        _rHTransform = _rightHand.transform;
        _lPTranform = _leftPath.transform;
        _rPtransform = _rightPath.transform;

        _isPause = true;
        Time.timeScale = 1;
        Application.targetFrameRate = 30;
    }

    // Update is called once per frame
    void Update()
    {
        /* 
           if (Input.GetKeyDown(KeyCode.Escape))
           {
               if (_isPause == true)
                   ResumeGame();
               else
                   PauseGame();

               _isPause = !_isPause;
           } 
        */

        if (Input.GetKeyDown(KeyCode.A))
        {
            _handActiveL = true;
            _handActiveR = !_handActiveL;
            MoveLeftHandY();
            MoveRightHandY();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            _handActiveR = true;
            _handActiveL = !_handActiveR;
            MoveLeftHandY();
            MoveRightHandY();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveHandsX();
        }

        RotateBoulder();
        if(_boulderSpeed > 0)
        {
            _boulderSpeed -= 0.001f;
        }
    }
    void PauseGame()
    {
        Time.timeScale = 0;
    }
    void ResumeGame()
    {
        Time.timeScale = 1;
    }
    void UpdateMenu()
    {

    }
    void MoveHandsX()
    {

    }
    void MoveLeftHandY()
    {
        if (_handActiveL)
        {
            if (_lHandHeight <= 1.5)
            {
                _lHTransform.position += new Vector3(0, 0.1f, 0);
                _lHandHeight += 0.1f;
            }
        }
        else
        {
            if (_lHandHeight >= -1.5)
            {
                _lHTransform.position += new Vector3(0, -0.1f, 0);
                _lHandHeight -= 0.1f;
            }
        }
        if(_boulderSpeed < 1f)
        {
            _boulderSpeed += 0.01f;
        }
        
    }
    void MoveRightHandY()
    {
        if (_handActiveR)
        {
            if (_rHandHeight <= 1.5)
            {
                _rHTransform.position += new Vector3(0, 0.1f, 0);
                _rHandHeight += 0.1f;
            }
        }
        else
        {
            if (_rHandHeight >= -1.5)
            {
                _rHTransform.position += new Vector3(0, -0.1f, 0);
                _rHandHeight -= 0.1f;
            }
        }
        if (_boulderSpeed < 0.2f)
        {
            _boulderSpeed += 0.01f;
        }
    }
    void RotateBoulder()
    {
        if (_boulderSpeed > 0)
        {
            _boulder.transform.Rotate(new Vector3(_boulderSpeed, 0, 0));
        }
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("speedy2", _boulderSpeed/0.2f);
    }

    void OffsetBoulder()
    {

    }

}
