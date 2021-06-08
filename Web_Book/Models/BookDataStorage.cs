using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web_Book.Models
{
    public class BookDataStorage
    {
        public static BookDataStorage Instance = new BookDataStorage();
        private List<ListBookModel> bookList = new List<ListBookModel>();

        public BookDataStorage()
        {
            this.bookList.Add(
                new ListBookModel
                {
                    Id = 1,
                    BookName="До зустрічі з тобою",
                    BookGenre="Роман",
                    BookAuthor= "Джоджо Мойес"

                });

            this.bookList.Add(
                new ListBookModel
                {
                    Id = 2,
                    BookName = "Квіти для Елджернона",
                    BookGenre = "Науково - фантастичний твір",
                    BookAuthor = "Деніел Кіз"

                });

            this.bookList.Add(
                new ListBookModel
                {
                    Id = 3,
                    BookName = "І не лишилося жодного",
                    BookGenre = "Детектив",
                    BookAuthor = "Агата Крісті"

                });
        }

        public List<ListBookModel> GetAllBooks()
        {
            return this.bookList;
        }

        public ListBookModel GetBookByBookId (int Id)
        {
            return this.bookList.Find(x => x.Id == Id);
        }

        public void UpdateBook(ListBookModel model)
        {
            var oldModel = this.bookList.Find(x => x.Id == model.Id);

            if(oldModel == null)
            {
                return;
            }

            this.bookList.Remove(oldModel);
            this.bookList.Add(model);
        }

        public void DeleteBook(int Id)
        {
            var model = this.bookList.Find(x => x.Id == Id);

            if (model == null)
            {
                return;
            }

            this.bookList.Remove(model);
        }

        public void AddBook(ListBookModel model)
        {
            if (this.bookList.Exists(x => x.BookName == model.BookName))
            {
                throw new InvalidOperationException();
            }

            model.Id = this.bookList.Max(x => x.Id) + 1;

            this.bookList.Add(model);
        }
    }
}