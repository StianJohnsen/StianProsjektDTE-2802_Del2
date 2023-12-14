using System.ComponentModel.DataAnnotations;

namespace ProsjektOppgaveBlazor.data.Models.ViewModel;
public class CommentViewModel
{
    public int CommentId { get; set; }
    
    [Required(ErrorMessage = "Comment Required"), StringLength(750)] 
    public string Text { get; set; }
    public int PostId { get; set; }
    public string OwnerId { get; set; }

}