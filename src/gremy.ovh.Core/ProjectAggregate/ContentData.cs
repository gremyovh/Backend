﻿using gremy.ovh.SharedKernel;
using Newtonsoft.Json;

namespace gremy.ovh.Core.ProjectAggregate;
public class ContentData : EntityBase
{
  [JsonProperty(PropertyName = "ContentDataId")]
  public override int Id { get; set; }
  public string FileName { get; set; }
  public Post Post { get; set; }

  public ContentData(string fileName)
  {
    FileName = fileName;
    Post = new Post();
  }
  public ContentData() : this(string.Empty)
  {
  }
}
