using M3S01_api.DTO;
using M3S01_api.Models;
using M3S01_api.Repositories;

namespace M3S01_api.Services;

public class BandaService: IBandaService

{
    
    private readonly IBandaRepository<BandaModel> _bandaRepository;
    
    public BandaService(IBandaRepository<BandaModel> bandaRepository)
    {
        _bandaRepository = bandaRepository;
    }
    

    public int Add(BandaPostDto bandaPostDto)
    {
        var model = new BandaModel {Descricao = bandaPostDto.Descricao, Solo = bandaPostDto.Solo, GeneroMusical = bandaPostDto.GeneroMusical };
        _bandaRepository.Add(model);

        return model.Id;

    }

    public bool Update(BandaPutDto bandaPutDto)
    {
        var model = new BandaModel
        {
            Id = bandaPutDto.Id,
            Descricao = bandaPutDto.Descricao,
            GeneroMusical = bandaPutDto.GeneroMusical,
            Solo = bandaPutDto.Solo
        };

        return _bandaRepository.Update(model);

    }

    public bool Delete(int id)
    {
        return _bandaRepository.Delete(id);
    }

    public IList<BandaGetDto> GetAll()
    {
        var bandaModel = _bandaRepository.GetAll();
        List<BandaGetDto> returns = new(bandaModel.Select(lambdaExpressio => (BandaGetDto)lambdaExpressio));
        return returns;

    }

    public BandaGetDto GetId(int id)
    {
        var bandaModel = _bandaRepository.GetId(id);
        
        var dto = new BandaGetDto
        {
            Id = bandaModel.Id, Descricao = bandaModel.Descricao, GeneroMusical = bandaModel.GeneroMusical        };
        
        return dto;

    }
}