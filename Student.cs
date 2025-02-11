﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_API_Source
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; } // Ensure this is DateTime
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}