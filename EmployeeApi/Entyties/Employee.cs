﻿namespace EmployeeApi.Entyties
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public GenderType GenderType { get; set; }
        public int? CompanyListId { get; set; }
    }
}
