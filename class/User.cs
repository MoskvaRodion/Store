using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class User
{
    [Key]
    public string login { get; set; }
    public string password { get; set; }
    public int Role_id { get; set; }

    public static User CurrentUser = null;
}