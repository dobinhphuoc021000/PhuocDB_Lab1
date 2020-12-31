using System;
using System.Collections.Generic;

namespace PhuocDB_Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            ManageBook manage = new ManageBook();
            byte? choice = null;
            do
            {
                Console.WriteLine("\t\t\t\t 1. add new book");
                Console.WriteLine("\t\t\t\t 2. update a book");
                Console.WriteLine("\t\t\t\t 3. delete a book");
                Console.WriteLine("\t\t\t\t 4. list all books by name ascending order");
                Console.WriteLine("\t\t\t\t 5. list books of which price is in given range");
                Console.WriteLine("\t\t\t\t 6. quit");
                Console.Write("\t\t\t\t Input your choice: ");
                choice = Convert.ToByte(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        #region add new book
                        manage.addNewBook();
                        break;
                    #endregion
                    case 2:
                        #region update a book
                        manage.updateBook();
                        break;
                    #endregion
                    case 3:
                        #region delete a book
                        manage.deleteBook();
                        break;
                    #endregion
                    case 4:
                        #region list all books by name ascending order
                        manage.ascendingSort();
                        break;
                    #endregion
                    case 5:
                        #region list books of which price is in given range
                        manage.printRange();
                        break;
                    #endregion
                    case 6:
                        #region save to File
                        manage.WriteData();
                        return;
                    #endregion
                    default:
                        Console.WriteLine("This option can not support!");
                        break;
                }
            }
            while (choice != 6);
        }
    }
}
