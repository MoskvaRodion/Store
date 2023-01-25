using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class client
{
    [Key]
    public int user_id { get; set; }
    public string? Name { get; set; }
    public string? password { get; set; }
    public string? pol { get; set; }
    public string? tel { get; set; }

    public static client CurrentUser = null;
}