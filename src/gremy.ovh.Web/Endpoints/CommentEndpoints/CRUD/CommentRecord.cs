namespace gremy.ovh.Web.Endpoints.CommentEndpoints.CRUD;

public record CommentRecord
  (
    int Id,
    string Title,
    string Body,
    DateTime creationDate,
    int PostId
  );
