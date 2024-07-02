using AutoMapper;
using JobTrack.Server.Data;
using JobTrack.Server.Models.DTO;
using JobTrack.Server.Models.Entities;
using JobTrack.Server.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;

namespace JobTrack.Server.Controllers
{
    //https://localhost:portnumber/applications
    [ApiController]
    [Route("[controller]")]
    public class ApplicationsController : ControllerBase
    {
        private readonly JobTrackDbContext dbContext;
        private readonly IApplicationRepository applicationRepository;
        private readonly IMapper mapper;

        public ApplicationsController(JobTrackDbContext dbContext, IApplicationRepository applicationRepository, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.applicationRepository = applicationRepository;
            this.mapper = mapper;
        }
        // GET ALL APPLICATIONS
        // https://localhost:portnumber/applications
        [HttpGet]
        public async Task<IActionResult> GetAllApplications()
        {
            var applications = await applicationRepository.GetAllApplicationsAsync();

            var applicationsDto = mapper.Map<List<ApplicationDto>>(applications);
            return Ok(applicationsDto);
        }

        // GET APPLICATION BY ID
        // https://localhost:portnumber/applications/{id}
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetApplicationById(Guid id)
        {
            var application = await applicationRepository.GetApplicationByIdAsync(id);
            if (application == null)
            {
                return NotFound();
            }

            var applicationDto = mapper.Map<ApplicationDto>(application);

            return Ok(applicationDto);
        }

        // POST A NEW APPLICATION
        // https://localhost:portnumber/applications/
        [HttpPost]
        public async Task<IActionResult> CreateApplication([FromBody] EditApplicationDto createApplicationDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var applicationModel = mapper.Map<Application>(createApplicationDto);

            await applicationRepository.CreateApplicationAsync(applicationModel);

            var applicationDto = mapper.Map<ApplicationDto>(applicationModel);

            return CreatedAtAction(nameof(GetApplicationById), new { id = applicationModel.Id }, applicationDto);
        }


        // PUT A NEW APPLICATION
        // https://localhost:portnumber/applications/{id}
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateApplication(Guid id, [FromBody] EditApplicationDto updateApplicationDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var applicationModel = mapper.Map<Application>(updateApplicationDto);

            applicationModel = await applicationRepository.UpdateApplicationAsync(id, applicationModel);
            if (applicationModel == null)
            {
                return NotFound();
            }

            var applicationDto = mapper.Map<ApplicationDto>(applicationModel);

            return Ok(applicationDto);
        }

        // DELETE A APPLICATION
        // https://localhost:portnumber/applications/{id}
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteApplication(Guid id)
        {
            var applicationModel = await applicationRepository.DeleteApplicationAsync(id);
            if (applicationModel == null) { return NotFound(); }

            return Ok("Successfully Removed!");
        }

    }
}
