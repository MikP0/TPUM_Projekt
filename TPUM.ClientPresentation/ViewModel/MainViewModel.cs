using System;
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

        private string _UriPeer = "ws://localhost:8081/";

        private ReactiveMessenger _ReactiveMessenger;

        private IDisposable _ViewObserver;


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
            //DoCommand = new RelayCommand(SetConnection);
            DoCommand = new RelayCommand(SetConnectionInter);
            //DoNextCommand = new RelayCommand(GetProducts);
            DoNextCommand = new RelayCommand(GetProductsInter);

            _ProductService = new ProductService();
            _Products = new ObservableCollection<ProductDTO>(_ProductService.GetProducts().Result);
            _CurrentProduct = null;

            _ClientService = new ClientService();

            _ConnectionService = new ConnectionService(_UriPeer);

            _ResultText = "No connection";
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

        public async void SetPricesTimer()
        {
            SetReactiveTimer(TimeSpan.FromSeconds(2));
        }

        public void SetReactiveTimer(TimeSpan period)
        {
            _cyclicTimer = new CyclicService(period);
            _tickObservable = Observable.FromEventPattern<CyclicEvent>(_cyclicTimer, "Tick");
            _observer = _tickObservable.Subscribe(x => UpdateProducts());

            _cyclicTimer.Start();
        }

        public async void SetConnection()
        {
            await _ConnectionService.CreateConnection();
            ResultText = "Connected";

            _ReactiveMessenger = new ReactiveMessenger(_ConnectionService);
            _ViewObserver = _ReactiveMessenger.Subscribe(x => UpdateProducts());
        }

        public void SetConnectionInter()
        {
           _ConnectionService.CreateConnectionInter();
           ResultText = "Connected";
        }

        public async void GetProducts()
        {
            await _ConnectionService.SendTask("GetAllProducts");
        }

        public void GetProductsInter()
        {
            _ConnectionService.SendMessegeInter("GetAllProducts");
        }

        public void UpdateProducts()
        {
            Products = new ObservableCollection<ProductDTO>(_ProductService.GetProducts().Result);
        }
    }
}
