using AutoMapper;
using SnagDesk.Domain;
using SnagDesk.Models.ProjectTasks.Response;

namespace SnagDesk.Models.ProjectTasks.Mappings
{
    public class ProjectTaskDtoMapping : Profile
    {
        public ProjectTaskDtoMapping()
        {
            CreateMap<Task, ProjectTaskDto>()
                .ForMember(c => c.Status, opt => opt.MapFrom(c => c.StatusInfo.Title));
        }
    }
}