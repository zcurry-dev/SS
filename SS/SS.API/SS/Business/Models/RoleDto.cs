namespace SS.Business.Models.Role
{
    public class RoleDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public string ConcurrencyStamp { get; set; } //needed? 062820
    }

    public class RoleUpdateDto
    {
        public string[] Names { get; set; }
    }
}