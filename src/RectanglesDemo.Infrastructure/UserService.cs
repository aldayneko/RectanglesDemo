﻿namespace RectanglesDemo;

public class UserService : IUserService
{
    public bool ValidateCredentials(string username, string password)
    {
        return username.Equals("admin") && password.Equals("admin111");
    }
}