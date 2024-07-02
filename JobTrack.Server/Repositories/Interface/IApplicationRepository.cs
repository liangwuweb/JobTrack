using JobTrack.Server.Models.Entities;


namespace JobTrack.Server.Repositories.Interface
{
    public interface IApplicationRepository
    {
        Task<List<Application>> GetAllApplicationsAsync();
        Task<Application> GetApplicationByIdAsync(Guid id);
        Task<Application> CreateApplicationAsync(Application application);
        Task<Application?> UpdateApplicationAsync(Guid id, Application application);
        Task<Application> DeleteApplicationAsync(Guid id);
    }
}
