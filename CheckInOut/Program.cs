using CheckInOut.Models;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

List<Collaborators> collabs = new List<Collaborators>
        {
            new Collaborators { Name = "Ana Oliveira", Sector = "Desenvolvimento", Turn = "Manhã", CheckIn = DateTime.Now.AddHours(-8), CheckOut = DateTime.Now },
            new Collaborators { Name = "Carlos Souza", Sector = "Marketing", Turn = "Tarde", CheckIn = DateTime.Now.AddHours(-6), CheckOut = DateTime.Now },
            new Collaborators { Name = "Mariana Costa", Sector = "Recursos Humanos", Turn = "Manhã", CheckIn = DateTime.Now.AddHours(-7), CheckOut = DateTime.Now },
            new Collaborators { Name = "Pedro Santos", Sector = "Financeiro", Turn = "Noite", CheckIn = DateTime.Now.AddHours(-5), CheckOut = DateTime.Now },
            new Collaborators { Name = "Beatriz Almeida", Sector = "TI", Turn = "Tarde", CheckIn = DateTime.Now.AddHours(-4), CheckOut = DateTime.Now },
            new Collaborators { Name = "Roberto Lima", Sector = "Jurídico", Turn = "Manhã", CheckIn = DateTime.Now.AddHours(-6), CheckOut = DateTime.Now },
            new Collaborators { Name = "Camila Fernandes", Sector = "Atendimento", Turn = "Noite", CheckIn = DateTime.Now.AddHours(-3), CheckOut = DateTime.Now },
            new Collaborators { Name = "Lucas Martins", Sector = "Design", Turn = "Tarde", CheckIn = DateTime.Now.AddHours(-5), CheckOut = DateTime.Now },
            new Collaborators { Name = "Fernanda Oliveira", Sector = "Vendas", Turn = "Manhã", CheckIn = DateTime.Now.AddHours(-7), CheckOut = DateTime.Now },
            new Collaborators { Name = "João Silva", Sector = "Logística", Turn = "Noite", CheckIn = DateTime.Now.AddHours(-8), CheckOut = DateTime.Now }
        };

app.MapPost("/api/colaborador/cadastrar/{name}/{sector}/{turn}", (string name, string sector, string turn) =>
{
    Collaborators collab = new Collaborators();
    collab.Name = name;
    collab.Sector = sector;
    collab.Turn = turn;
    collabs.Add(collab);
    return collab;
});

app.MapPost("/api/colaborador/cadastrar", (Collaborators collab) =>
{
    collab.CreatedAt = DateTime.Now; 
    collab.Id = Guid.NewGuid().ToString();
    collabs.Add(collab);
    return Results.Created($"/api/colaborador/{collab.Id}", collab);
});

app.MapPost("/api/colaborador", (Collaborators collab) =>
{ 
    return Results.Ok($"Collaborator: {collab.Id}, {collab.Name}, {collab.Turn}, {collab.Sector}");
});

app.MapGet("/api/colaborador/listar", () =>
{
    return collabs;
});
app.Run();
