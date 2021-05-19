using HeavenlyHome_Data;
using HeavenlyHome_Models.ApplicantModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeavenlyHome_Service
{
    public class ApplicantService
    {

        public bool CreateApplicant(ApplicantCreate model)
        {
            var entity =
                new Applicant()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    MoveInDate = model.MoveInDate,
                    Requirements = model.Requirements
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Applicants.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
