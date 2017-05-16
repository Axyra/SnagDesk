using System.Linq;
using System.Web.Http;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using SnagDesk.DAL;
using SnagDesk.DAL.Repositories;
using SnagDesk.Domain;
using SnagDesk.Models.ProjectTasks;
using SnagDesk.Models.ProjectTasks.Request;
using SnagDesk.Models.ProjectTasks.Response;

namespace SnagDesk.Controllers
{
    [RoutePrefix("api/project/{projectId:int}/tasks")]
    public class ProjectTasksController : ApiController
    {
        private readonly IProjectsRepository _repository;
        private readonly IMapper _mapper;

        public ProjectTasksController(IProjectsRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet, Route("")]
        public IHttpActionResult List([FromUri] ProjectTasksRequestDto request)
        {
            if (!_repository.All.Any(c => c.Id == request.ProjectId))
            {
                ModelState.AddModelError(nameof(request.ProjectId), "Project with such identifier doesn't exist.");
            }

            if (request.Status.HasValue && !_repository.DoesProjectHaveStatus(request.ProjectId, request.Status.Value))
            {
                ModelState.AddModelError(nameof(request.Status), "Invalid status for specified project.");
            }

            if (!ModelState.IsValid) return BadRequest(ModelState);


            var query = request.Status.HasValue
                ? _repository.GetTasks(request.ProjectId, request.Status.Value)
                : _repository.GetTasks(request.ProjectId);

            return Ok(query.OrderBy(c => c.Id)
                .Paginate(request.PageSize, request.PageNumber)
                .ProjectTo<ProjectTaskDto>(_mapper.ConfigurationProvider)
                .ToList());
        }
    }
}
