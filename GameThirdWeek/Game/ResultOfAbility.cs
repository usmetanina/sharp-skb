using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class ResultOfAbility // Последствия, которые приносит способность
    {
        private DateTime timeOfEnd;

        public ResultOfAbility(DateTime timeOfEnd)
        {
        }

        public bool IsActive()
        {
            // Если время вышло, то последствия от этой способности не учитываются
            return true;
        }
    }
}
