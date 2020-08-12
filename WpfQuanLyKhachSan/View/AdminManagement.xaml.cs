using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup.Localizer;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfQuanLyKhachSan.Model;
using WpfQuanLyKhachSan.ViewModel;

namespace WpfQuanLyKhachSan.View
{
    /// <summary>
    /// Interaction logic for AdminRoom.xaml
    /// </summary>
    public partial class AdminManagement : Page
    {
        private RoomViewModel roomViewModel = new RoomViewModel();
        private TypeRoomViewModel typeRoomViewModel = new TypeRoomViewModel();

        public event PropertyChangedEventHandler PropertyChanged;



        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private Room obj;
        public string NameRoom
        {
            get { return obj.NameRoom; }
            set
            {
                if (value != obj.NameRoom)
                {
                    obj.NameRoom = value;
                    OnPropertyChanged("NameRoom");
                }
            }
        }
        private void RoomsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            Console.WriteLine("===>>>>>>>>>>>>>>>>>>> " + $"{sender}");

            obj = RoomsGrid.SelectedItem as Room;
            string name = obj.NameRoom;
            Console.WriteLine("==================>>>>>>>>>>> room selected: " + $"{obj.Id} " + $"{name}");

            RoomTypeCb.ItemsSource = typeRoomViewModel.findAll();

        }
        public AdminManagement()
        {
            InitializeComponent();
            List<Room> rooms = roomViewModel.findAll();

            RoomsGrid.ItemsSource = rooms;
            RoomTypeCb.ItemsSource = typeRoomViewModel.findAll();

        }

        public void LoadContent()
        {
            new View.AdminManagement();
        }

        private void Row_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void CRUDItem(object sender, RoutedEventArgs e)
        {
            var action = (e.Source as Button).Content.ToString();
            Console.WriteLine("=================>>>>>>>>>>>>CRUD Click: " + $"{action}");

            /*MessageBox.Show(keyword);*/
            string _nameRoom = NameRoomCRUD.Text;
            string _noteRoom = NoteRoomCRUD.Text;
            float _priceRoom = float.Parse(PriceRoomCRUD.Text);

            /*TypeRoom _typeRoomId = (TypeRoom)RoomTypeCb.SelectedItem;*/ // gives you the required string
            var _typeRoomId = 1;
            if (RoomTypeCb.SelectedItem != null)
            {
                _typeRoomId = (RoomTypeCb.SelectedItem as TypeRoom).Id;
            }
            else
            {
                _typeRoomId = 1;
            }

            switch (action)
            {
                case "Add":
                    int _idAdd = 0;
                    /*  _nameRoom = NameRoomCRUD.Text;
                      _noteRoom = NoteRoomCRUD.Text;
                      _priceRoom = float.Parse(PriceRoomCRUD.Text);


                     *//*TypeRoom _typeRoomId = (TypeRoom)RoomTypeCb.SelectedItem;*//* // gives you the required string
                      _typeRoomId = (RoomTypeCb.SelectedItem as TypeRoom).Id;*/
                    Console.WriteLine("=================>>>>>>>>>>>>Name Room add: " + $"{_nameRoom}");
                    Console.WriteLine("=================>>>>>>>>>>>>Note Room add: " + $"{_noteRoom}");
                    Console.WriteLine("=================>>>>>>>>>>>>Price Room add: " + $"{_priceRoom}");
                    Console.WriteLine("=================>>>>>>>>>>>>TypeRoomId Room add: " + $"{_typeRoomId}");

                    Room room = new Room()
                    {
                        Id = _idAdd,
                        NameRoom = _nameRoom,
                        Note = _noteRoom,
                        TypeRoomId = _typeRoomId
                    };

                    roomViewModel.Add(room);


                    break;

                case "Update":
                    int _idUpdate = int.Parse(IdRoomCRUD.Text);
                    Console.WriteLine("==============>>>>>>>>>>>>> ID UPDATE ROOM: " + $"{_idUpdate}");

                    Console.WriteLine("=================>>>>>>>>>>>>Name Room Update: " + $"{_nameRoom}");
                    Console.WriteLine("=================>>>>>>>>>>>>Note Room Update: " + $"{_noteRoom}");
                    Console.WriteLine("=================>>>>>>>>>>>>Price Room Update: " + $"{_priceRoom}");
                    Console.WriteLine("=================>>>>>>>>>>>>TypeRoomId Room Update: " + $"{_typeRoomId}");

                    Room roomUpdate = new Room()
                    {
                        Id = _idUpdate,
                        NameRoom = _nameRoom,
                        Note = _noteRoom,
                        TypeRoomId = _typeRoomId
                    };

                    roomViewModel.Update(roomUpdate);

                    break;


                case "Delete":
                    int _idDelete = (RoomsGrid.SelectedItem as Room).Id;
                    Console.WriteLine("=================>>>>>>>>>>>>> id delete: " + $"{_idDelete}");

                    string message = "Are you sure?";
                    string caption = "Confirmation";
                    MessageBoxButton buttons = MessageBoxButton.YesNo;
                    MessageBoxImage icon = MessageBoxImage.Question;
                    if (MessageBox.Show(message, caption, buttons, icon) == MessageBoxResult.Yes)
                    {
                        roomViewModel.UpdateIsDeleted(_idDelete);
                        LoadContent();
                    }
                    else
                    {
                        // Cancel code here  
                    }


                    break;

            }



        }








        /*private RelayCommand _addRoomCommand;
        private RelayCommand _updateRoomCommand;
        private RelayCommand _deleteRoomCommand;
        private RelayCommand<object> _resetFilterRoomCommand;
        private RelayCommand _roomsGridSelectionChangedCommand;
        private RelayCommand _roomsFilterChangedCommand;

        public ICommand AddRoomCommand =>
            _addRoomCommand ??
            (_addRoomCommand = new RelayCommand(
                () =>
                {
                    Context.Rooms.Add(new Room
                    {
                        Number = RoomInfo.Number,
                        Type = RoomInfo.Type
                    });
                    Context.SaveChanges();
                },
                () =>
                {
                    if (string.IsNullOrEmpty(RoomInfo.Number) || RoomInfo.Type == RoomTypes.None)
                    {
                        return false;
                    }
                    return true;
                }));

        public ICommand UpdateRoomCommand =>
            _updateRoomCommand ??
            (_updateRoomCommand = new RelayCommand(
                () =>
                {
                    SelectedRoom.Number = RoomInfo.Number;
                    SelectedRoom.Type = RoomInfo.Type;
                    Context.SaveChanges();
                },
                () =>
                {
                    if (SelectedRoom == null) return false;
                    if (string.IsNullOrEmpty(RoomInfo.Number) || RoomInfo.Type == RoomTypes.None)
                    {
                        return false;
                    }
                    return true;
                }));

        public ICommand DeleteRoomCommand =>
            _deleteRoomCommand ??
            (_deleteRoomCommand = new RelayCommand(
                () =>
                {
                    Context.Rooms.Remove(SelectedRoom);
                    Context.SaveChanges();
                },
                () => SelectedRoom != null));*/
    }
}
