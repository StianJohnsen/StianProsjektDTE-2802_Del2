namespace ProsjektOppgaveWebAPI.Models;

public class Tag
{
    public int Id { get; set; }
    public string content { get; set; }
    public List<Post>? Posts { get; set; }
}
