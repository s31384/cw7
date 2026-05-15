using cw7.DTOs;
using cw7.Entities;

namespace cw7.Services;

public interface IDbService
{
    public Task<IEnumerable<GetPCsDTO>> GetPcsAsync();
    
    public Task<GetByIdDTO> GetComponentsAsync(int id);
    
    public Task<GetPCsDTO> PostAsync(PcPostDTO postDto);

    public Task PutAsync(PutPcDTO putDto, int id);
    
    public Task DeleteAsync(int id);
}