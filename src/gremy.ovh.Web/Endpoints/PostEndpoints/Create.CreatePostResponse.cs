namespace gremy.ovh.Web.Endpoints.PostEndpoints;

public class CreatePostResponse
{
  public int Id { get; set; }
  public string Title { get; set; }
  public string Body { get; set; }

  public CreatePostResponse(int id, string title, string body)
  {
    this.Id = id;
    this.Title = title;
    this.Body = body;
  }
}
