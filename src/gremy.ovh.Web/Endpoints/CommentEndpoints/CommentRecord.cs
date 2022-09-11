namespace gremy.ovh.Web.Endpoints.CommentEndpoints;

public record CommentRecord
  (
    int Id,
    string Title,
    string Body,
    DateTime creationDate,
    int postId
  );
