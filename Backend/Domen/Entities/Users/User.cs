using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuizApplication.Domain.Enums;

namespace QuizApplication.Domain.Entities.Users;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Salt { get; set; }
    public bool Confirmed { get; set; } = true;
    public string PasswordHash { get; set; }
    public UserRole Role { get; set; } = UserRole.User;
}

