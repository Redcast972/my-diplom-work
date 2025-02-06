namespace AllCourses.Domain.Repositories.EntityFramevork
{
    public class EFApplicationsForTeachingRepository
    {
        private AllCoursesDbContext _context;
        public EFApplicationsForTeachingRepository(AllCoursesDbContext context)
        {
            _context = context;    
        }


    }
}
