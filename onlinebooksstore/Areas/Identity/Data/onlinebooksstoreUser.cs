using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Client;

namespace onlinebooksstore.Areas.Identity.Data;

// Add profile data for application users by adding properties to the onlinebooksstoreUser class
public class onlinebooksstoreUser : IdentityUser
{
    public string UserName   { get; set; }
    public string Mobile { get; set; }
    public string State  { get; set; }
    public string City   { get; set; }
    public string Password { get;set; }
}

