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

        public IEnumerable<Friendface> ShowList()
        {
            return friendfaceRepository.GetActive();
        }

        public void Create(string name, DateTime birthday, string description)
        {
            friendfaceRepository.Create(name, birthday, description);
        }
    }
}
