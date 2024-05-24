using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ICryptService
    {
        string GenerateSalt();
        string Hash(string input, string salt);
        bool Verify(string entered, string storedHash, string storedSalt);
    }
}
