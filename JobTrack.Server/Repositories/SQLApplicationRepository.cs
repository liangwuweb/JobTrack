using JobTrack.Server.Data;
using JobTrack.Server.Models.Entities;
using JobTrack.Server.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace JobTrack.Server.Repositories
{
    public class SQLApplicationRepository : IApplicationRepository
    {
        private readonly JobTrackDbContext dbContext;

        public SQLApplicationRepository(JobTrackDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Application>> GetAllApplicationsAsync()
        {
            return await dbContext.Applications.ToListAsync();
        }

        public async Task<Application> CreateApplicationAsync(Application application)
        {
            await dbContext.Applications.AddAsync(application);
            await dbContext.SaveChangesAsync();
            return application;
        }


        public async Task<Application> GetApplicationByIdAsync(Guid id)
        {
            return await dbContext.Applications.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Application?> UpdateApplicationAsync(Guid id, Application application)
        {
            var model = await dbContext.Applications.FirstOrDefaultAsync(x => x.Id == id);
            if (model == null) { return null; }

            model.CompanyName = application.CompanyName;
            model.JobDescription = application.JobDescription;
            model.JobLink = application.JobLink;
            model.JobTitle = application.JobTitle;

            await dbContext.SaveChangesAsync();

            return model;

        }

        public async Task<Application> DeleteApplicationAsync(Guid id)
        {
            var model = await dbContext.Applications.FirstOrDefaultAsync(x => x.Id == id);
            if (model == null) { return null; }
            dbContext.Applications.Remove(model);
            await dbContext.SaveChangesAsync();
            return model;
        }
    }
}
