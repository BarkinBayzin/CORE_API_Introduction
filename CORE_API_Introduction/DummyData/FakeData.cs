using Bogus;
using CORE_API_Introduction.Models;
using System.Collections.Generic;

namespace CORE_API_Introduction.DummyData
{
    public static class FakeData
    {
        private static List<User> _users;

        public static List<User> GetUsers(int count)
        {
            // Her defasında yeni userList oluşturmasın, null olduğu zaman oluştursun. Aksi halde aynı userList'i return edilsin.

            if (_users == null)
            {
                _users = new Faker<User>()
                                .RuleFor(x => x.Id, faker => faker.IndexFaker + 1)
                                .RuleFor(x => x.FirstName, faker => faker.Name.FirstName())
                                .RuleFor(x => x.LastName, faker => faker.Name.LastName())
                                .RuleFor(x => x.Address, faker => faker.Address.FullAddress())
                                .Generate(count);
            }

            return _users;
        }
    }
}
