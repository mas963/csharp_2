using Faker;
using System;

namespace FakerDummyData
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var user = new UserProfile();

            for (int i = 0; i < 10; i++)
            {
                user.Name = Faker.Name.FullName(NameFormats.WithPrefix);
                user.Area = $"{Faker.Address.Country()}, {Faker.Address.City()}";
                user.Email = Faker.Internet.Email(user.Name);
                Console.WriteLine("Full Name: " + user.Name);
                Console.WriteLine("Full Email: " + user.Email);
                Console.WriteLine("Area: " + user.Area);
                Console.WriteLine("--------------------------");

            }
        }
    }

    class UserProfile
    {
        public string Name { get; set; }
        public int Followers { get; set; }
        public string Area { get; set; }
        public string Email { get; set; }
        public string Bio { get; set; }
    }


}
