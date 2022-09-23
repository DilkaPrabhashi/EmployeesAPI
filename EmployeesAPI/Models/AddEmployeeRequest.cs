namespace EmployeesAPI.Models
{
    public class AddEmployeeRequest
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public long Phone { get; set; }
    }
}
