using System;
using System.Collections.Generic;
using System.Text;

namespace Friendface.Core
{
    public class FriendfaceService
    {
        private IFriendfaceRepository friendfaceRepository;

        public FriendfaceService(IFriendfaceRepository friendfaceRepository)
        {
            this.friendfaceRepository = friendfaceRepository;
        }

        public IEnumerable<Domain.User> ShowList()
        {
            return friendfaceRepository.GetActive();
        }

        public void CreateUser(string username, string password, DateTime birthday, string description, string address, string email)
        {
            friendfaceRepository.CreateUser(username, password, birthday, description, address, email);
        }
    }
}
