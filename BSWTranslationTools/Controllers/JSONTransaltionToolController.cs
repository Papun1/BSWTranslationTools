using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BSWTranslationTools.API.Entities;
using BSWTranslationTools.API.Repository.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagementAPI.Repository.Contracts;

namespace BSWTranslationTools.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public class JSONTransaltionToolController : ControllerBase
    {
        private readonly ILoggerService _logger;
        private readonly IMapper _Mapper;
        private readonly IJsonDetailsRepository _JsonDetailsRepository;
        private readonly IJsonDetailsKeyRepository _JsonDetailsKeyRepository;
        private readonly IAudit_logs _audit_Logs;

        public JSONTransaltionToolController(ILoggerService logger, IMapper Mapper, IJsonDetailsRepository JsonDetailsRepository,
            IJsonDetailsKeyRepository JsonDetailsKeyRepository, IAudit_logs audit_Logs)
        {
            _logger = logger;
            _Mapper = Mapper;
            _JsonDetailsRepository = JsonDetailsRepository;
            _JsonDetailsKeyRepository = JsonDetailsKeyRepository;
            _audit_Logs = audit_Logs;
        }
        [HttpGet]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllJson()
        {
            try
            {
                _logger.LogInfo("Attempted Get all Json list");
                var JsonDetaillist = await _JsonDetailsKeyRepository.FindAll();
                var respose = _Mapper.Map<IList<JsonDetailsKeyDTO>>(JsonDetaillist);
                _logger.LogInfo("Successfully got all the list");
                return Ok(respose);
            }
            catch (Exception ex)
            {
                return InternalError($"{ex.Message}-{ex.InnerException}");

            }

        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetJson(int id)
        {
            try
            {
                _logger.LogInfo($"Attempted Get the Json record with id:{id}");
                var JsonDetaillist = await _JsonDetailsKeyRepository.FindById(id);
                if (JsonDetaillist == null)
                {
                    _logger.LogWarn($"Json records with id:{id} was not found");
                    return NotFound();
                }
                var respose = _Mapper.Map<JsonDetailsKeyDTO>(JsonDetaillist);
                _logger.LogInfo($"Successfully got the Json records with id:{id}");
                return Ok(respose);
            }
            catch (Exception ex)
            {
                return InternalError($"{ex.Message}-{ex.InnerException}");
            }

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Create([FromBody] JsonDetailsKeyCreateDTO jsonDetailsCreatedDTO)
        {
            try
            {
                _logger.LogInfo("Attempted submission attempted");

                if (jsonDetailsCreatedDTO == null)
                {
                    _logger.LogWarn("Empty request submitted");
                    return BadRequest(ModelState);
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogWarn("Json record data was incomplete");
                    return BadRequest(ModelState);
                }
                var jsonrecord = _Mapper.Map<JsonDetailsKey>(jsonDetailsCreatedDTO);
                var isSuccess = await _JsonDetailsKeyRepository.Create(jsonrecord);
                if (!isSuccess)
                {
                    return InternalError("Json records creation failed");
                }
                _logger.LogInfo("Json record created");
                Audit_logs audit = new Audit_logs()
                {
                    jsonKeyid = jsonrecord.JsonKeyID,
                    action = "Create",
                    log = $"Json records has created,Key:{jsonrecord.Keys},KeyValues1:{jsonrecord.KeyValues1},KeyValues2:{jsonrecord.KeyValues2}",
                    datetime = DateTime.Now
                };
                await _audit_Logs.Create(audit);
                return Created("Create", new { jsonrecord });
            }
            catch (Exception ex)
            {
                return InternalError($"{ex.Message}-{ex.InnerException}");
            }

        }
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Update(int id, [FromBody] JsonDetailsKeyUpdateDTO jsonDetailsUpdatedDTO)
        {
            try
            {
                _logger.LogInfo($"Json detail update with id:{id}");
                if (id < 1 || jsonDetailsUpdatedDTO == null || id != jsonDetailsUpdatedDTO.JsonKeyID)
                {
                    _logger.LogWarn("Json records update failed with bad data");
                    return BadRequest();
                }
                var isExist = await _JsonDetailsRepository.isExist(id);
                if (!isExist)
                {
                    _logger.LogWarn($"Json record with id:{id} was not found");
                    return NotFound();
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogWarn("Json data was incomplete");
                    return BadRequest(ModelState);
                }
                var jsonrecord = _Mapper.Map<JsonDetailsKey>(jsonDetailsUpdatedDTO);
                var isSuccess = await _JsonDetailsKeyRepository.Update(jsonrecord);
                if (!isSuccess)
                {
                    return InternalError("Json record update operation failed");
                }
                _logger.LogInfo("Json records updated");
                Audit_logs audit = new Audit_logs()
                {
                    jsonKeyid = jsonrecord.JsonKeyID,
                    action = "Update",
                    log = $"Json records has Updated,Key:{jsonrecord.Keys},KeyValues1:{jsonrecord.KeyValues1},KeyValues2:{jsonrecord.KeyValues2}",
                    datetime = DateTime.Now
                };
                await _audit_Logs.Create(audit);
                return NoContent();
            }
            catch (Exception ex)
            {
                return InternalError($"{ex.Message}-{ex.InnerException}");
            }
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                _logger.LogInfo($"Json detail delete with id:{id}");
                if (id < 1)
                {
                    _logger.LogWarn("Json details not avaible");
                    return BadRequest();
                }
                var isExist = await _JsonDetailsKeyRepository.isExist(id);
                if (!isExist)
                {
                    _logger.LogWarn($"Json details with id:{id} was not found");
                    return NotFound();
                }
                var jsonrecord = await _JsonDetailsKeyRepository.FindById(id);
                var isSuccess = await _JsonDetailsKeyRepository.Delete(jsonrecord);
                if (!isSuccess)
                {
                    return InternalError("Json records delete failed");
                }
                _logger.LogInfo("Json records delete");
                Audit_logs audit = new Audit_logs()
                {
                    jsonKeyid = jsonrecord.JsonKeyID,
                    action = "Delete",
                    log = $"Json records has Deleted,Key:{jsonrecord.Keys},KeyValues1:{jsonrecord.KeyValues1},KeyValues2:{jsonrecord.KeyValues2}",
                    datetime = DateTime.Now
                };
                await _audit_Logs.Create(audit);
                return NoContent();
            }
            catch (Exception ex)
            {
                return InternalError($"{ex.Message}-{ex.InnerException}");
            }
        }
        [HttpGet]
        [Route("Simulation")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ExecuteProcJsonSimulation()
        {
            try
            {
                _logger.LogInfo("Attempted submission attempted");

                if (!ModelState.IsValid)
                {
                    _logger.LogWarn("Json data was incomplete");
                    return BadRequest(ModelState);
                }
                //  int UID = _JsonDetailsRepository.ExecuteProcJsonSimulation();
                var JsonDetaillist = await _JsonDetailsKeyRepository.FindFaultStatus();
                var respose = _Mapper.Map<IList<JsonDetailsKeyDTO>>(JsonDetaillist);
                _logger.LogInfo("Json Role created");
                return Ok(respose);
            }
            catch (Exception ex)
            {
                return InternalError($"{ex.Message}-{ex.InnerException}");
            }

        }
        private ObjectResult InternalError(string message)
        {
            _logger.LogError(message);
            return StatusCode(500, "Something went wrong,Please contact the Adminstrator");
        }
    }
}
