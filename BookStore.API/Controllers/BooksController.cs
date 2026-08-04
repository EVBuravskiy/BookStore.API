using BookStore.API.Contracts;
using BookStore.BL.Services;
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
    }
}
