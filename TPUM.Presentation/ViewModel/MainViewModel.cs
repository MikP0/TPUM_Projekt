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
using System.Linq;

namespace TPUM.Presentation.ViewModel
{
    internal class MainViewModel : BaseViewModel
    {
        public ICommand DoCommand { get; }
        public ICommand DoNextCommand { get; }

        private List<ProductDTO> _Products;
        private ProductDTO _CurrentProduct;
        private ProductService _ProductService;

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

            _ProductService = new ProductService();
            _Products = _ProductService.GetProducts().ToList();
            _CurrentProduct = Products[0];
        }



        private void DoSomething()
        {
            SetNewTimerInBackground(TimeSpan.FromSeconds(3));
        }

        private void DoNextSomething()
        {
            //MessageBox.Show(_accumulator.ToString());
            //MessageBox.Show(_CurrentProduct.Name);

            Products.Remove(_CurrentProduct);
            RaisePropertyChanged();
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
            var protuctTemp = _Products;

            foreach (ProductDTO product in protuctTemp)
            {
                // _ProductService.GetProduct(product.Id).Price += 1.0f;
                product.Price += 1;
                //RaisePropertyChanged("Products");
            }

            _Products = protuctTemp;

            //_Products = _ProductService.GetProducts().ToList();
             RaisePropertyChanged("_Products");

            //_accumulator++; 
        }
    }
}
