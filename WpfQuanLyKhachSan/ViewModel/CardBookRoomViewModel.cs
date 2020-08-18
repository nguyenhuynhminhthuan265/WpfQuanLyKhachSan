using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfQuanLyKhachSan.Model;
using WpfQuanLyKhachSan.Repository;

namespace WpfQuanLyKhachSan.ViewModel
{
    class CardBookRoomViewModel
    {
        private CardBookRoomRepository cardBookRoomRepository = new CardBookRoomRepository();
        public List<CardBookRoom> FindAll()
        {
            List<CardBookRoom> cardBookRooms = cardBookRoomRepository.FindAll();

            return cardBookRooms;
        }


        public void Add(CardBookRoom item)
        {
            cardBookRoomRepository.Add(item);
        }

        public CardBookRoom FindById(int id)
        {
            return cardBookRoomRepository.FindById(id);

        }

        public void Update(CardBookRoom item)
        {
            cardBookRoomRepository.Update(item);
        }

        
    }
}
