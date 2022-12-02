namespace Ef_7_IMaterializationInterceptor.Models;

public class Post:IHasRetrieved
{
    public int PostId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime Retrieved { get; set; }
}

public interface IHasRetrieved
{
    DateTime Retrieved { get; set; }
}