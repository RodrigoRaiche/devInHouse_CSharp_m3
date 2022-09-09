using M3S01_api.DTO;

namespace M3S01_api.Services;

public interface IBandaService
{
    int Add(BandaPostDto bandaPostDto);

    bool Update(BandaPutDto bandaPutDto);

    bool Delete(int id);

    IList<BandaGetDto> GetAll();
    
    BandaGetDto GetId(int id);
}