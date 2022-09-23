namespace EmployeesAPI.Models
{
    public class UpdateEmployeeRequest
    {
        
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public long Phone { get; set; }
    }
}
