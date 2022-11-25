using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishWindow : MonoBehaviour
{
    public static bool IsFinish = false;
    [SerializeField] private GameObject _finish;

    [SerializeField] private float _timer = 10f;
    public Text MainTimerText;
    public Text _myAllScore;

    private void Start()
    {
        MainTimerText.text = _timer.ToString();
    }

    private void Update()
    {
        if(_timer <= 0)
        {
            IsFinish = true;
            _finish.SetActive(true);
            Time.timeScale = 0f;
            
        }
        RemoveTime();
    }

    private void RemoveTime()
    {
        _timer -= Time.deltaTime;
        MainTimerText.text = Mathf.Round(_timer).ToString();
    }


}
