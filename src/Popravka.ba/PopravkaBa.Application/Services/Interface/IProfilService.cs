using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PopravkaBa.Application.DTOs;

namespace PopravkaBa.Application.Services.Interface
{
    public interface IProfilService
    {
        Task<ProfilIzvrsilacDto?> DajProfilAsync(string id);
    }
}