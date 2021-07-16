using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Services
{
    public interface IPublicationService
    {
       
        public Task<bool> SetPublication(Publication publication);

    }
}
