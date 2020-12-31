using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Runtime.Serialization;
using System.IO;

namespace PhuocDB_Lab1
{
    class ManageBook: Dictionary<string, BookDTO>, Method
    {
        private static string PATH = @"data.txt";
        private static FileStream fs = new FileStream(PATH, FileMode.OpenOrCreate,
                                                        FileAccess.ReadWrite, FileShare.None);
        public ManageBook()
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                using (StreamReader rd = new StreamReader(fs))
                {
                    string line;
                    while ((line = rd.ReadLine()) != null)
                    {
                        string[] item = line.Split("-");

                        string bookID = item[0].Trim();
                        string name = item[1].Trim();
                        string publisher = item[2].Trim();
                        float price = float.Parse(item[3].Trim());

                        this.Add(bookID, new BookDTO(bookID, name, publisher, price));
                    }
                    rd.Close();
                    fs.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Can not found this file");
                Console.WriteLine(e.Message);
            }
        }

        public void WriteData()
        {
            try
            {
                using (StreamWriter wr = new StreamWriter(PATH))
                {
                    foreach (var item in this.Values)
                    {
                        string line = item.BookID + "-" + item.Name + "-" + item.Publisher + "-" + item.Price;
                        wr.WriteLine(line);
                        wr.Flush();
                    }
                    wr.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Can not found this file");
                Console.WriteLine(e.Message);
            }
        }
        private bool searchID(string bookID)
        {
            foreach (var item in this.Values)
            {
                if (bookID.Equals(item.BookID))
                {
                    Console.WriteLine("ID is already exist. Input again.");
                    return true;
                }
            }
            return false;
        }
        public void addNewBook()
        {
            string bookID, name, publisher;
            float price = 0;
            BookDTO dto;
            do
            {
                MyUtility.GetString(out bookID, "Input book ID (Bxxx): ", "ID can not empty", "ID must have format Bxxx", "(B)\\d{1,3}");
            }
            while (searchID(bookID));
            
            MyUtility.GetString(out name, "Input book name: ", "Name can not empty", "", "\\w+");
            MyUtility.GetString(out publisher, "Input book publisher: ", "Publisher can not empty", "", "\\w+");
            MyUtility.GetFloat(out price, "Input book price: ", "Price must be greater than 0", "Price must be a number");
            dto = new BookDTO(bookID, name, publisher, price);
            this.Add(bookID, dto);
        }

        private string searchBookByID(string bookID, ref BookDTO dto)
        {
            foreach (var key in this.Keys)
            {
                if (key.Equals(bookID))
                {
                    dto = this[key];
                    return "";
                }
            }
            return null;
        }
        public void updateBook()
        {
            string idSearch;
            MyUtility.GetString(out idSearch, "Input ID search (Bxxx): ", "ID can not empty", "ID must have format Bxxx", "(B)\\d{1,3}");
            BookDTO dto = new BookDTO();
            if(searchBookByID(idSearch, ref dto) != null)
            {
                string newName, newPublisher;
                float newPrice;
                Console.WriteLine(dto.ToString());
                MyUtility.GetString(out newName, "Input new name: ", "Name can not empty", "", "\\w+");
                MyUtility.GetString(out newPublisher, "Input new publisher: ", "Publisher can not empty", "", "\\w+");
                MyUtility.GetFloat(out newPrice, "Input new price: ", "Price must be greater than 0", "Price must be a number");
                dto.Name = newName;
                dto.Publisher = newPublisher;
                dto.Price = newPrice;
                Console.WriteLine("Update book by ID {0} successfull!", idSearch);
            }
            else
            {
                Console.WriteLine("Can not found book by ID {0}", idSearch);
            }
        }

        public void deleteBook()
        {
            string idSearch;
            MyUtility.GetString(out idSearch, "Input ID search (Bxxx): ", "ID can not empty", "ID must have format Bxxx", "(B)\\d{1,3}");
            BookDTO dto = new BookDTO();
            if (searchBookByID(idSearch, ref dto) != null)
            {
                this.Remove(idSearch);
                Console.WriteLine("Delete book by ID {0} successfull!", idSearch);
            }
            else
            {
                Console.WriteLine("Can not found book by ID {0}", idSearch);
            }
        }

        public void ascendingSort()
        {
            if(this.Values.Count == 0)
            {
                Console.WriteLine("List is empty");
            }
            else
            {
                var listSort = from name in this.Values
                               orderby name ascending
                               select name;
                foreach (var item in listSort)
                {
                    Console.WriteLine(item);
                }
            }
        }

        public void printRange()
        {
            float min, max;
            MyUtility.GetFloat(out min, "Input min price: ", "Price must be greater than 0", "Price must be a number");
            MyUtility.GetFloat(out max, "Input max price: ", "Price must be greater than 0", "Price must be a number");
            var bookInRange = this.Where(s => s.Value.Price >= min && s.Value.Price <= max).Select(s => new { s.Value.BookID, s.Value.Name, s.Value.Publisher, s.Value.Price});
            foreach (var item in bookInRange)
            {
                Console.WriteLine(item);
            }
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }

        public override void OnDeserialization(object sender)
        {
            base.OnDeserialization(sender);
        }
        
    }
}
