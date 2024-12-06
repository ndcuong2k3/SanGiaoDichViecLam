using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseLayer;

namespace BusinessLogicLayer
{
    public class JobManager
    {
        private readonly JobDbContext _context;
            
        public JobManager(JobDbContext context)
        {
            _context = context;
        }

        public List<TinTuyenDung> GetAllJobs()
        {
            return _context.tblTinTuyenDung.ToList(); 
        }

        public bool CheckEmpty(params string[] values)
        {
            return values.Any(string.IsNullOrEmpty);
        }

        public bool CheckValid(int salary, int numberOfEmployees)
        {
            return salary > 0 && numberOfEmployees >= 0;
        }


        public void AddJob(TinTuyenDung tinTuyenDung)
        {
            _context.tblTinTuyenDung.Add(tinTuyenDung);   
            _context.SaveChanges();          
        }
    }
}
