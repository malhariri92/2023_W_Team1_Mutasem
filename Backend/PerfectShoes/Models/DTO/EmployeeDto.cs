namespace PerfectShoes.Models.DTO
{
    public class EmployeeDto : UserDto
    {
        //Id, Type, First name, Last name, and email are all accounted for with the UserDto
        public string Role { get; set; }
        public bool IsAdmin { get; set; }
    }
}
