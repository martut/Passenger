using System;
using System.Text.RegularExpressions;

namespace Passenger.Core.Domain
{
    public class User
    {
        private static readonly Regex NameRegex = new Regex("^(?![_.-])(?!.*[_.-]{2})[a-zA-Z0-9._.-]+(?<![_.-])$");

        public Guid Id { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        public string Salt { get; protected set; }
        public string Username { get; protected set; }
        public string FullName { get; protected set; }
        public string Role { get; set; }
        public DateTime CreatedAt { get; protected set; }
        public DateTime UpdatedAt { get; protected set; }
        

        protected User()
        {
            
        }

        public User(string email, string username,
            string password, string role, string salt)
        {
            Id = Guid.NewGuid();
            Email = email.ToLowerInvariant();
            Username = username;
            Password = password;
            Role = role;
            Salt = salt;
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetUsername(string username)
        {
            if (NameRegex.IsMatch(username))
            {
                throw new Exception($"Username is invalid.");
            }

            if (String.IsNullOrEmpty(username))
            {
                throw new Exception($"Username can not be empty.");
            }

            Username = username.ToLowerInvariant();
            UpdatedAt = DateTime.UtcNow;
        }
        
        public void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new Exception($"Email cannot be empty.");
            }

            if (Email == email)
            {
                return;
            }

            Email = email.ToLowerInvariant();
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetRole(string role)
        {
            if (Role == role)
            {
                return;
            }

            Role = role;
            UpdatedAt = DateTime.UtcNow;
        }

        public void SetPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new Exception($"Password cannot be empty.");
            }
            if (password.Length < 4)
            {
                throw new Exception($"Password must contain at least 4 characters.");
            }
            if (password.Length > 20)
            {
                throw new Exception($"Password cannot contain more then 20 characters.");
            }
            if (Password == password)
            {
                return;
            }
            Password = password;
            UpdatedAt = DateTime.UtcNow;
        }
        
        
        
    }
}