var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

        // Criar a lista de livros
List<Book> books = new List<Book>
{
    new Book { Id = 1, Title = "Livro 1", Description = "Descrição do Livro 1" },
    new Book { Id = 2, Title = "Livro 2", Description = "Descrição do Livro 2" },
    new Book { Id = 3, Title = "Livro 3", Description = "Descrição do Livro 3" },
    new Book { Id = 4, Title = "Livro 4", Description = "Descrição do Livro 4" },
    new Book { Id = 5, Title = "Livro 5", Description = "Descrição do Livro 5" }
};

app.MapGet("/books", () =>
{
    return books;
});

app.Run();

class Book
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
}