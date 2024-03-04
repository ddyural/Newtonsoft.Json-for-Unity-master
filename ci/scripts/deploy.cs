using System.Collections.Generic;
using UnityEngine;

public class LVLManagment : MonoBehaviour
{
    [System.Serializable]
    public class Level
    {
        public List<Transform> cameraPoints;
    }

    [Header("CameraPoints")]
    [SerializeField] private List<Level> _levelList;

    [SerializeField] private List<Transform> _currentLVLPositions;

    [SerializeField] private int _currentCameraPoint = 0;
    [SerializeField] private int _countCameraPoints;

    [SerializeField] private int _currentLevel = 0;
    [SerializeField] private int _countLevels;

    private void Start()
    {
        _currentLVLPositions = _levelList[_currentLevel].cameraPoints;
        _countCameraPoints = _currentLVLPositions.Count;
        _countLevels = _levelList.Count;
    }

    private void ChangeLVL()
    {
        _currentLevel++;
        if ( _currentLevel >= _countLevels ) 
        {
            _currentLevel = 0;
        }
        _currentLVLPositions = _levelList[_currentLevel].cameraPoints;

        _currentCameraPoint = 0;
        ChangePosition();
    }

    public void ChangePosition()
    {
        _currentCameraPoint++;
        if (_currentCameraPoint>=_countCameraPoints)
        {
            _currentCameraPoint = 0;
        }
        transform.position = _currentLVLPositions[_currentCameraPoint].position;
    }
}
