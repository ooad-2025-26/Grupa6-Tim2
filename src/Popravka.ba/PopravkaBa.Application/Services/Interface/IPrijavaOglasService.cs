using PopravkaBa.Application.DTOs;
using PopravkaBa.Domain.Models;

public interface IPrijavaOglasService
{
    Task<IEnumerable<PrijavaRadnoMjesto>> DajSvePrijave(int oglasId);
    Task<PrijavaRadnoMjesto?> DajPrijavuPoId(int prijavaId);
    Task KreirajPrijavu(KreirajPrijavaRadnoMjestoDto dto);
    Task ObrisiPrijavu(int prijavaId);
    Task PrihvatiPonudu(int prijavaId);
    Task OdbijPrijavu(int prijavaId);
}