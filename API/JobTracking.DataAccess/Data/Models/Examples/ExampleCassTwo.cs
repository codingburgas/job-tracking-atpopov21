using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using JobTracking.DataAccess.Data.Base;

namespace JobTracking.DataAccess.Data.Models.Examples;

public class ExampleCassTwo : IEntity
{
    [Key]
    public int Id { get; set; }
    public bool IsActive { get; set; } 
    [Required]
    public DateTime CreatedOn { get; set; }
    [NotNull]
    public string CreatedBy { get; set; }
    public DateTime? UpdatedOn { get; set; }
    public string? UpdatedBy { get; set; }
    
    public virtual ICollection<ExampleCassTwo> Models { get; set; } = new List<ExampleCassTwo>(); 
}