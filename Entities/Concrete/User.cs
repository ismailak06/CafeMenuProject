using Core.Entities;
using System;

namespace Entities.Concrete
{
    public class User : IEntity
    {
        public int Id { get; set; }

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Name cannot be null");
                }
                _name = value;
            }
        }

        private string _surname;
        public string Surname
        {
            get => _surname;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("SurName cannot be null");
                }
                _surname = value;
            }
        }

        private string _username;
        public string Username
        {
            get => _username;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("UserName cannot be null");
                }
                _username = value;
            }
        }
        public byte[] HashPassword { get; set; }
        public byte[] SaltPassword { get; set; }
    }
}
