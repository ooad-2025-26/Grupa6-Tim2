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
        // Dohvata sve podatke za detaljan prikaz profila
        Task<ProfilIzvrsilacDto?> DajProfilAsync(string id);

        // Dohvata samo polja potrebna za formu uređivanja
        Task<UrediProfilDto?> DajZaUredjivanjеAsync(string id);

        // Snima izmjene profila u bazu
        Task<bool> UrediProfilAsync(UrediProfilDto dto);
    }
}