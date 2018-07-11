using System;
using System.Collections.Generic;
using System.Text;

namespace Friendface.Core
{
    class FriendfaceService
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
    }
}
