namespace pisLab1;

using Microsoft.EntityFrameworkCore;


public class Spy
{
    public Guid Id { get; set; }
    public string? FirstName { get; set; }
    public string? SecondName { get; set; }
    
    public string? Alias{get;set;}
    
    public DateTime? DateOfBirth { get; set; }
    
    public string? Nationality { get; set; }
}

public class Equipment
{
    public Guid Id { get; set; }
    
    public string? Name { get; set; }
    
    public string? Description { get; set; }
    
    public Spy SpyId { get; set; }
}

public class Mission
{
    public Guid Id { get; set; }
    
    public string? Name { get; set; }
    
    public string? Description { get; set; }
    
    public Spy SpyId { get; set; }
}

