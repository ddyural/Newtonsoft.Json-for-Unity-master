using UnityEngine;
using System.Collections;
/// <summary>
/// Lets object float 
/// </summary>
public class Float : MonoBehaviour
{
    [Header("Floating Height")]
    [SerializeField] private float _height;

    [Header("Speed")]
    [SerializeField] private float _floatingSpeed;
    
    private Vector3 _targetedPoint;

    [Header("Timer")]
    private float _timer;
    private float _duration = 2f;

    private void Start()
    {
        _targetedPoint = new (0, _height,0);
        print(_targetedPoint);
    }

    private void Update()
    {
        transform.position += _targetedPoint * _floatingSpeed * Time.deltaTime;
        _timer -= Time.deltaTime;
        if (_timer <= 0)
        {
            SwitchDirection();
            ResetTimer();
        }
    }

    private void SwitchDirection()
    {
        _targetedPoint.y *= -1;
    }

    private void ResetTimer()
    {
        _timer= Time.deltaTime+ _duration;
    }
}
