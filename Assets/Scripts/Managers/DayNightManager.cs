using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using MEC;

public class DayNightManager : MonoBehaviour
{
    public static DayNightManager Instance;

    #region EVENTS
    public delegate void OnNewDayEventHandler();
    public static event OnNewDayEventHandler OnNewDay;
    #endregion

    #region UI REFERENCES
    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI _dayText;
    [SerializeField] private TextMeshProUGUI _timeText;
    [SerializeField] private TextMeshProUGUI _timeSignText;
    #endregion

    private string[] _timeSignString = new string[2] { "AM", "PM" };

    #region DAY SETTINGS
    [Header("Day Settings")]
    [SerializeField] private int _currentDay;
    public int CurrentDay
    {
        get { return _currentDay; }
        set
            {
                _currentDay = value;
                UpdateDays();
                OnNewDay?.Invoke();
            }
    }
    [SerializeField] private int _currentTime;
    public int CurrentTime
    {
        get { return _currentTime; }
        set
        {
            _currentTime = value;

            if (_currentTime == 12 || _currentTime == 0) UpdateTimeSign();

            if(_currentTime > 24)
            {
                _currentTime = 0;
                CurrentDay++;
            }
            UpdateTime();

        }
    }
    [SerializeField] private float _inGameHour;

    #endregion

    #region UNITY FUNCTIONS
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateDays();
        UpdateTime();
        UpdateTimeSign();

        Timing.RunCoroutine( _TimeCycleCoroutine().CancelWith(this.gameObject) );
    }
    #endregion

    #region Coroutines

    private IEnumerator<float> _TimeCycleCoroutine()
    {
        while(true)
        {
            yield return Timing.WaitForSeconds(_inGameHour);

            CurrentTime++;
        }
    }
   
    #endregion

    #region UI Functions
    /// <summary>
    /// Displays day value into textcomponent.
    /// </summary>
    private void UpdateDays() => _dayText.SetText( _currentDay.ToString());
    /// <summary>
    /// Displays time value into textcomponent.
    /// </summary>
    private void UpdateTime() => _dayText.SetText( _currentDay.ToString() );
    /// <summary>
    /// Displays timeSign value into textcomponent.
    /// </summary>
    private void UpdateTimeSign() => _dayText.SetText( _currentTime <= 12 ? _timeSignString[0]: _timeSignString[1] );
    #endregion
}
