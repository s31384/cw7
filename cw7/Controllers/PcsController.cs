using cw7.DbContext;
using cw7.DTOs;
using cw7.Exeptions;
using cw7.Services;
using Microsoft.AspNetCore.Mvc;

namespace cw7.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PcsController : ControllerBase
    {
        private readonly IDbService _dbService;

        public PcsController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var pcs = await _dbService.GetPcsAsync();
            return Ok(pcs); 
        }

        [HttpGet("{id:int}/components")]
        public async Task<IActionResult> GetComponentsAsync([FromRoute]int id)
        {
            GetByIdDTO dto;
            try
            {
                dto = await _dbService.GetComponentsAsync(id);
            }
            catch (NotFoundExeption e)
            {
                return NotFound(e.Message);
            }
            return Ok(dto);
        }

        [HttpPost]
        public async Task<IActionResult> PostPc([FromBody] PcPostDTO postDto)
        {
            GetPCsDTO responceDto;

            try
            {
                responceDto = await _dbService.PostAsync(postDto);
            }
            catch (BadRequestExeption e)
            {
                return BadRequest(e.Message);
            }
            return CreatedAtAction(nameof(PostPc), new{id = responceDto.Id}, responceDto );
        }


        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutPcAsync([FromRoute] int id, [FromBody] PutPcDTO putPcDto)
        {
            try
            {
                await _dbService.PutAsync(putPcDto, id);
            }
            catch (NotFoundExeption e)
            {
                return NotFound(e.Message);
            }
            catch (BadRequestExeption e)
            {
                return BadRequest(e.Message);
            }
            
            return Ok(putPcDto);
        }



        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeletePcAsync([FromRoute] int id)
        {
            try
            {
                await _dbService.DeleteAsync(id);
            }catch(NotFoundExeption e)
            {
                return NotFound(e.Message);
            }
            return NoContent();
        }
    }
}
