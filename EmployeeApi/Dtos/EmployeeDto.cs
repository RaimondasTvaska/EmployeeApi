namespace EmployeeApi.Dtos
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string GenderType { get; set; }
        public int? CompanyListId { get; set; }
    }
}
