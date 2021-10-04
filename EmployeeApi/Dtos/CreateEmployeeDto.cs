namespace EmployeeApi.Dtos
{
    public class CreateEmployeeDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int? CompanyListId { get; set; }
    }
}
