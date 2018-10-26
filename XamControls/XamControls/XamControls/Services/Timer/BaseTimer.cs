using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XamControls.Services.Timer
{
    public class BaseTimer
    {

				private int _timerTime;
				private TimeSpan _timeSpan;
				private int _valueRandom;
				private bool _repeat;
				private Random _random;
				private int _numRepeats;

				public BaseTimer(int time)
				{

						_timerTime = time;
						_timeSpan.Add(TimeSpan.FromMilliseconds(_timerTime));
						_repeat = false;
						_random = new Random();
						_numRepeats = 0;

				}

				public void StartTimer(Func<bool> finish)
				{

						Device.StartTimer(_timeSpan, finish);

				}

				public void StopTimer()
				{

						_repeat = true;

				}

    }
}
