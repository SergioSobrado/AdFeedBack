using AdFeedBack.dto.Dtos.User;
using AdFeedBack.dto.Results;
using AdFeedBack.negocio.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdFeedBack.negocio.Interfaces
{
    public interface IUserService
    {
        List<UserReadDto> GetAllUsers();
        UserReadDto GetById(int id);
        Task<UserResult> Create(UserCreateDto userCreateDto);
        UserResult Update(int userId, UserUpdateDto userUpdateDto);
        bool DeleteUser(int userId);
        UserResult Login(UserLoginDto userLoginDto);
        // Otros métodos según sea necesario
    }
}
