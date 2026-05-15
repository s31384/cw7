using cw7.DbContext;
using cw7.DTOs;
using cw7.Entities;
using cw7.Exeptions;
using Microsoft.EntityFrameworkCore;

namespace cw7.Services;

public class DbService : IDbService
{
    private readonly AppDbContext _dbContext;

    public DbService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task<IEnumerable<GetPCsDTO>> GetPcsAsync()
    {
        var pcs = await _dbContext.Pcs.Select(e => new GetPCsDTO()
        {
            Id = e.Id,
            Name = e.Name,
            Warranty = e.Warranty,
            CreatedAt = e.CreatedAt,
            Stock = e.Stock,
            Weight = e.Weight,
        }).ToListAsync();
        return pcs;
    }

    public async Task<GetByIdDTO> GetComponentsAsync(int id)
    {
        var pc = await _dbContext
            .Pcs
            .Where(p => p.Id == id)
            .Select(
                p => new GetByIdDTO()
                {
                    Id =  p.Id,
                    Name = p.Name,
                    Warranty = p.Warranty,
                    CreatedAt = p.CreatedAt,
                    Stock = p.Stock,
                    Weight = p.Weight,
                    Components = p.PcComponents.Select(p => new GetComponentDTO()
                    {
                        Code = p.Component.Code,
                        Name = p.Component.Name,
                        Description = p.Component.Description,
                        ComponentManufacturer = new GetManufacturerDTO()
                        {
                            Id = p.Component.ComponentManufacturer.Id,
                            Abbreviation =  p.Component.ComponentManufacturer.Abbreviation,
                            FullName = p.Component.ComponentManufacturer.FullName,
                            FoundationDate =  p.Component.ComponentManufacturer.FoundationDate,
                        },
                        ComponentType = new GetTypeDTO()
                        {
                            Abbreviation = p.Component.ComponentType.Abbreviation,
                            Name = p.Component.ComponentType.Name,
                            Id =  p.Component.ComponentType.Id,
                        },
                        Amount = p.Amount,
                        
                        
                    }).ToList()
                }
                
                ).FirstOrDefaultAsync();

        if (pc == null)
        {
            throw new NotFoundExeption("Pc not found");
        }

        return pc;
    }

    public async Task<GetPCsDTO> PostAsync(PcPostDTO postDto)
    {
        if (postDto.stock < 0)
        {
            throw new BadRequestExeption("stock cant be negative");
        }
        if (postDto.warrantry < 0)
        {
            throw new BadRequestExeption("warrantry cant be negative");
        }
        if (postDto.weight < 0)
        {
            throw new BadRequestExeption("weight cant be negative");
        }


        var pc = new Pc()
        {
            Name = postDto.name,
            Weight = postDto.weight,
            Warranty = postDto.warrantry,
            Stock = postDto.stock,
            CreatedAt = postDto.createdAt,
        };
        await _dbContext.Pcs.AddAsync(pc);
        
        await _dbContext.SaveChangesAsync();


        GetPCsDTO pcDto = new GetPCsDTO()
        {
            CreatedAt = pc.CreatedAt,
            Id = pc.Id,
            Name = pc.Name,
            Warranty = pc.Warranty,
            Stock = pc.Stock,
            Weight = pc.Weight,
        };
        return pcDto;



    }

    public  async Task PutAsync(PutPcDTO putDto, int id)
    {
        
        if (putDto.stock < 0)
        {
            throw new BadRequestExeption("stock cant be negative");
        }
        if (putDto.warranty < 0)
        {
            throw new BadRequestExeption("warrantry cant be negative");
        }
        if (putDto.weight < 0)
        {
            throw new BadRequestExeption("weight cant be negative");
        }
        
        
        var pc = await _dbContext.Pcs.FindAsync(id);

        if (pc == null)
        {
            throw new NotFoundExeption("pc not found");
        }
        
        pc.CreatedAt = putDto.createdAt;
        pc.Stock = putDto.stock;
        pc.Warranty = putDto.warranty;
        pc.Name = putDto.name;
        pc.Weight = putDto.weight;
        
        await _dbContext.SaveChangesAsync();
        
    }

    public async Task DeleteAsync(int id)
    {
        var pc = await _dbContext.Pcs.FindAsync(id);

        if (pc == null)
        {
            throw new NotFoundExeption("pc not found");
        }
        
        _dbContext.Pcs.Remove(pc);
        await _dbContext.SaveChangesAsync();
        
    }
}