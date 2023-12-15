namespace ProsjektOppgaveWebAPI.Models.ViewModel;

public class TagViewModel
{
    public int Id { get; set; }
    public string content { get; set; }
    public List<Post>? Posts { get; set; }
}