using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BAL.Models
{
  public class ClassAdminViewModel
  {
    public long Id { get; set; }
    public string? Name { get; set; }
    public string? Location { get; set; }
    public string? Image { get; set; }
  }
}