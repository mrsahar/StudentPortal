﻿namespace StudentPortal.Models.Enitity
{
    public class Student
    {

        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public bool isActive { get; set; }

    }
}
