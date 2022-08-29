#nullable disable

namespace gremy.ovh.Web.Endpoints.PostEndpoints;

public record PostRecord
  (
    int Id,
    string Title,
    string Body
  );
