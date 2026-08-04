namespace BookStore.API.Contracts
{
    public record BookResponse(
        Guid ID,
        string Title,
        string Description,
        decimal Price
        );
}
