using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Auth
{
    public interface IUserRepository
    {

        Task<User> FindByEmail(string email);


        /// <summary>
        /// Verifica si el usuario existe en la base de datos
        /// </summary>
        /// <param name="email">Email del usuario</param>
        /// <returns>Si el usuario existe devuelve true, false de otra forma</returns>
        Task<bool> UserExists(string email);

        /// <summary>
        /// Verifica si las credenciales para el inicio de sesión del usuario son correctas
        /// </summary>
        /// <param name="email">Email del usuario</param>
        /// <param name="password">Contraseña del usuario</param>
        /// <returns></returns>
        Task<bool> CheckCredentials(User email, string password);


        /// <summary>
        /// Crea el usuario en la base de datos
        /// </summary>
        /// <param name="user">Objeto usuario con sus datos</param>
        /// <param name="password">Contraseña del usuario</param>
        /// <returns></returns>
        Task<IdentityResult> CreateUser(User user, string password);
    }
}
