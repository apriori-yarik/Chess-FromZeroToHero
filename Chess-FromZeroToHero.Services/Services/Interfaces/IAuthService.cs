using Chess_FromZeroToHero.Contracts.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_FromZeroToHero.Services.Services.Interfaces
{
    public interface IAuthService
    {
        Task RegisterAsync(UserDto userDto);

        Task<string> LoginAsync(string username, string password);

    }
}
