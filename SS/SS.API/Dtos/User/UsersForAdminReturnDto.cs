using System.Collections.Generic;

namespace SS.API.Dtos.User
{
    public class UsersForAdminReturnDto
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public List<string> Roles { get; set; }
    }
}