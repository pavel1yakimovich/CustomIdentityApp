﻿using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IdentityApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int Year { get; set; }

        public ApplicationUser() { }
    }
}