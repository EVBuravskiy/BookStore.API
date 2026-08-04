using BookStore.API.Contracts;
using BookStore.BL.Services;
using BookStore.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.API.Controllers
{
    //Атрибут указывающий на то, что этот класс является контроллером
    [ApiController]
    //Атрибут указывающий на маршрут обработки контроллером куда передаем 
    //атрибут controller
    [Route("[controller]")]
    //Класс-контроллер, наследующийся от класса - ControllerBase
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        //Метод возвращающий все книги
        //Указываем атрибут с методом HTTP:
        [HttpGet]
        public async Task<ActionResult<List<BookResponse>>> GetBooks()
        {
            //Получаем коллекцию элементов Book
            var books = await _bookService.GetAllBooks();
            //Используя метод Select проходим по всем элементам Book
            //используя которые создаем коллекцию объектов BookResponse
            var response = books.Select(b => new BookResponse(
                b.BookID,
                b.Title,
                b.Description,
                b.Price
            ));
            //Возвращаем ответ Ok в который передаем полученную коллекцию
            return Ok(response);
        }

        //Метод возвращающий книгу по ID
        //Указываем атрибут с методом HTTP который принимает id
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Book>> GetBook(Guid id)
        {
            var book = await _bookService.GetBook(id);
            return Ok(book);
        }

        //Метод создания книги
        //Указываем атрибут с методом HTTP:
        [HttpPost]
        public async Task<ActionResult<Guid>> CreateBook([FromBody] BookRequest bookRequest)
        {
            //Используя статический метод Create в модели Book создаем пару (книга, ошибка)
            var (book, error) = Book.Create(Guid.NewGuid(), 
                bookRequest.Title, 
                bookRequest.Description, 
                bookRequest.Price);
            //Проверяем, если в результате создания книги была получена ошибка
            if (!string.IsNullOrEmpty(error))
            {
                //Возвращаем ошибку
                return BadRequest(error);
            }
            //Если же книга была создана, то вызываем сервис работы с базой данных
            //и добавляем книгу в базу данных
            var bookID = await _bookService.CreateBook(book);
            //Возвращаем ответ с ID книги
            return Ok(bookID);
        }

        //Метод обновления книги
        //Указываем атрибут с методом HTTP который принимает id
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateBook(Guid id, [FromBody] BookRequest bookRequest)
        {
            var bookID = await _bookService.UpdateBook(id, 
                bookRequest.Title, 
                bookRequest.Description, 
                bookRequest.Price);
            return Ok(bookID);
        }

        //Метод удаления книги
        //Указываем атрибут с методом HTTP который принимает id
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteBook(Guid id)
        {
            var bookID = await _bookService.DeleteBook(id);
            return Ok(bookID);
        }
    }
}
