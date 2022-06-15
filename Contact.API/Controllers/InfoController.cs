using AutoMapper;
using Contact.API.DTOs;
using Contact.Data.Entities;
using Contact.Data.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Contact.API.Controllers
{
    [Route("api/{personId:int}/[controller]")]
    [ApiController]
    public class InfoController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        private IMapper _mapper;

        public InfoController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Info>> GetInfos(int personId)
        {
            try
            {
                IEnumerable<Info> infos = _repository.Infos.GetAllInfo(personId);
                return Ok(infos);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public ActionResult<Info> CreateInfo(int personId, [FromBody] InfoDTO infoDto)
        {
            try
            {
                if (infoDto is null)
                {
                    return BadRequest("Info object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                Info info = _mapper.Map<Info>(infoDto);
                info.PersonId = personId;
                _repository.Infos.CreateInfo(info);
                _repository.Save();
                return Ok(info);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateInfo(int personId, int id, [FromBody] InfoDTO infoDto)
        {
            try
            {
                if (infoDto is null)
                {
                    return BadRequest("Info object is null");
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid model object");
                }

                Info info = _repository.Infos.GetInfoById(id);

                if (info is null)
                {
                    return NotFound();
                }
                _mapper.Map(infoDto, info);
                _repository.Infos.UpdateInfo(info);
                _repository.Save();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePerson(int personId, int id)
        {
            try
            {
                Info info = _repository.Infos.GetInfoById(id);
                if (info == null)
                {
                    return NotFound();
                }
                _repository.Infos.DeleteInfo(info);
                _repository.Save();
                return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
