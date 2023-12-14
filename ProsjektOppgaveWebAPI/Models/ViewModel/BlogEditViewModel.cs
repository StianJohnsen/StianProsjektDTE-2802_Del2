using System.ComponentModel.DataAnnotations;

namespace ProsjektOppgaveWebAPI.Models.ViewModel;

public class BlogViewModel
{
    public int BlogId { get; set; }
    [Required(ErrorMessage = "Blog Name Required")]
    public string Name { get; set; }
    public int Status { get; set; }
    
    public string OwnerId { get; set; }
}