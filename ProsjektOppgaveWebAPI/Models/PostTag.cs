﻿namespace ProsjektOppgaveWebAPI.Models;

public class PostTag
{
    public int Id { get; set; }
    public int PostId { get; set; }
    public int TagId { get; set; }
}