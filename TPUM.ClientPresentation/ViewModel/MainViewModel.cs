﻿using System;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using TPUM.ClientLogic;
using TPUM.ClientLogic.DTOs;
using TPUM.ClientLogic.Services;

namespace TPUM.ClientPresentation.ViewModel
{
    internal class MainViewModel : BaseViewModel
    {
        public ICommand DoCommand { get; }
        public ICommand DoNextCommand { get; }
        public ICommand ThirdCommand { get; }

        private ObservableCollection<ProductDTO> _Products;
        private ProductDTO _CurrentProduct;
        private ProductService _ProductService;

        private CyclicService _cyclicTimer;
        private IObservable<EventPattern<CyclicEvent>> _tickObservable;
        private IDisposable _observer;

        private ClientService _ClientService;
        private ObservableCollection<ClientDTO> _Clients;

        private ConnectionService _ConnectionService;

        private string _ResultText;

        private Uri _Uri;
        private string _UriPeer = "ws://localhost:8081/";

        public string ResultText
        {
            get { return _ResultText; }
            set 
            { 
                _ResultText = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<ProductDTO> Products
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

        public ObservableCollection<ClientDTO> Clients
        {
            get
            {
                return _Clients;
            }
            set
            {
                _Clients = value;
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
            DoCommand = new RelayCommand(SetConnection);
            DoNextCommand = new RelayCommand(GetProducts);
            ThirdCommand = new RelayCommand(SetPricesTimer);

            _ProductService = new ProductService();
            _Products = new ObservableCollection<ProductDTO>(_ProductService.GetProducts().Result);
            _CurrentProduct = null;

            _ClientService = new ClientService();

            _ConnectionService = new ConnectionService();

            _ResultText = "No connection";

            _Uri = new Uri(_UriPeer);
        }

        public async void SetPricesTimer()
        {
            SetReactiveTimer(TimeSpan.FromSeconds(2));
        }

        public void DeleteCurrentProduct()
        {
            Products.Remove(_CurrentProduct);

            if (Products.Count > 0)
            {
                _CurrentProduct = Products[0];
            }
            else
            {
                _CurrentProduct = null;
            }
        }

        public async void GetAllClients()
        {
            _Clients = new ObservableCollection<ClientDTO>(await _ClientService.GetUsers());
        }

        public void SetReactiveTimer(TimeSpan period)
        {
            _cyclicTimer = new CyclicService(period);
            _tickObservable = Observable.FromEventPattern<CyclicEvent>(_cyclicTimer, "Tick");
            _observer = _tickObservable.Subscribe(x => RaisePrices());

            _cyclicTimer.Start();
        }

        public async void SetConnection()
        {
            Uri _uri = new Uri("ws://localhost:8081/");
            await _ConnectionService.CreateConnection(_uri);
            ResultText = "Connected";
        }

        public async void GetProducts()
        {
            await _ConnectionService.SendTask("GetAllProducts");
            SetReactiveTimer(TimeSpan.FromSeconds(1));
        }

        public void RaisePrices()
        {
            Products = new ObservableCollection<ProductDTO>(_ProductService.GetProducts().Result);
        }
    }
}
