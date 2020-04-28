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
using TPUM.Logic.DTOs;
using TPUM.Logic.Services;

namespace TPUM.Presentation.ViewModel
{
    internal class MainViewModel : BaseViewModel
    {
        public ICommand DoCommand { get; }
        public ICommand DoNextCommand { get; }


        private List<ProductDTO> _Products;
        private ProductDTO _CurrentProduct;

        //private ProductService _ProductService;

        public List<ProductDTO> Products
        {
            get
            {
                return _Products;
            }
            set
            {
                _Products = value;
                RaisePropertyChanged();
            }
        }

        public ProductDTO CurrentProduct
        {
            get
            {
                return _CurrentProduct;
            }
            set
            {
                _CurrentProduct = value;
                RaisePropertyChanged();
            }
        }


        public MainViewModel()
        {
            DoCommand = new RelayCommand(DoSomething);
            DoNextCommand = new RelayCommand(DoNextSomething);

            Products = new List<ProductDTO>();

            Products.Add(new ProductDTO());
            Products.Add(new ProductDTO());

            Products[0].Id = 1;
            Products[0].Name = "aa";
            Products[0].Author = "bb";
            Products[0].Price = 12.20f;

            Products[1].Id = 2;
            Products[1].Name = "baa";
            Products[1].Author = "abb";
            Products[1].Price = 13.20f;

            _CurrentProduct = Products[0];
        }



        private void DoSomething()
        {
            SetNewTimerInBackground(TimeSpan.FromSeconds(1));
        }

        private void DoNextSomething()
        {
            //MessageBox.Show(_accumulator.ToString());
            MessageBox.Show(_CurrentProduct.Name);
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
