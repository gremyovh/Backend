#nullable disable

using gremy;

namespace gremy.ovh.Web.Endpoints.PostEndpoints.CRUD;

public record PostRecord
  (
    int Id,
    string Title,
    string Body
  );
