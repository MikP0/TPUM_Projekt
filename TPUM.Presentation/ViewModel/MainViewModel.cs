using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;



using TPUM.Logic;
using System.Reactive.Linq;
using System.Reactive.Concurrency;
using System.Reactive;
using System.Diagnostics;
using System.Windows;

namespace TPUM.Presentation.ViewModel
{
    internal class MainViewModel : BaseViewModel
    {
        public ICommand DoCommand { get; }
        public ICommand DoNextCommand { get; }


        public MainViewModel()
        {
            DoCommand = new RelayCommand(DoSomething);
            DoNextCommand = new RelayCommand(DoNextSomething);
        }



        private void DoSomething()
        {
            SetNewTimerInBackground(TimeSpan.FromSeconds(1));
        }

        private void DoNextSomething()
        {
            MessageBox.Show(_accumulator.ToString());
        }


        long _accumulator = 0;
        CyclicService _cyclicTimer;
        IObservable<EventPattern<CyclicEvent>> _tickObservable;
        IDisposable _observer;

        public void SetNewTimerInBackground(TimeSpan period)
        {
            _accumulator = 0;

            _cyclicTimer = new CyclicService(period);
            _tickObservable = Observable.FromEventPattern<CyclicEvent>(_cyclicTimer, "Tick");
            _observer = _tickObservable.Subscribe(x => DoSomethingWithTimerTick());

            _cyclicTimer.Start();

            MessageBox.Show("Start");
        }

        public void DoSomethingWithTimerTick()
        {
            _accumulator++;
        }




    }
}
