using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PhuocDB_Lab1
{
    class BookDTO : IComparable<BookDTO>
    {
        private string bookID;
        private string name;
        private string publisher;
        private float price;

        public BookDTO() { }
        public BookDTO(string bookID, string name, string publisher, float price)
        {
            this.bookID = bookID;
            this.name = name;
            this.publisher = publisher;
            this.Price = price;
        }

        public float Price
        {
            get => price;
            set
            {
                if (value >= 0 && value <= 1000000)
                    price = value;
            }
        }

        public string BookID
        {
            get => bookID;
            set => bookID = value;
        }
        public string Name
        {
            get => name;
            set => name = value;
        }
        public string Publisher
        {
            get => publisher;
            set => publisher = value;
        }

        public override string ToString()
        {
            return this.BookID + " | " + this.Name + " | " + this.Publisher + " | " + this.Price;
        }

        public int CompareTo(BookDTO obj)
        {
            return this.name.CompareTo(obj.name);
        }
        
    }
}
