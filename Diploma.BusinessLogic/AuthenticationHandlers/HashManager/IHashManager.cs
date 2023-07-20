using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma.BusinessLogic.AuthenticationHandlers.HashManager
{
    public interface IHashManager
    {
        void CreateHash(string password, out byte[] hash, out byte[] salt);
        bool VerifyHash(string password, byte[] hash, byte[] salt);
    }
}
