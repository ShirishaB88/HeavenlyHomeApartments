using HeavenlyHome_Data;
using HeavenlyHome_Models.ResidentModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeavenlyHome_Service
{
    public class ResidentService
    {
        private readonly Guid _userID;

        public ResidentService(Guid userID)
        {
            _userID = userID;
        }

        //Create Resident

        public bool CreateResident(ResidentCreate model)
        {
            var entity = new Resident
            {
                UserID = _userID,
                AddressID = model.AddressID,
                FullName = model.FullName,
                PhoneNumber = model.PhoneNumber,
                EmailAddress = model.EmailAddress

            };
                
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Residents.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }
        //Get all Redidents
        public IEnumerable<ResidentListItems> GetAllResidents()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Residents
                    .Where(e => e.UserID == _userID)
                    .Select(e => new ResidentListItems
                    {
                        ResidentID = e.ResidentID,
                        AddressID = e.AddressID,
                        FullName = e.FullName,
                        PhoneNumber = e.PhoneNumber,
                        EmailAddress = e.EmailAddress
                    });
                return query.ToList();
            }

        }

       //Update Resident
       public bool UpdateResident( ResidentEdit model)
       {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Residents
                    .Single(e => e.ResidentID == model.ResidentID && e.UserID == _userID);

                entity.ResidentID = model.ResidentID;
                entity.AddressID = model.AddressID;
                entity.FullName = model.FullName;
                entity.PhoneNumber = model.PhoneNumber;
                entity.EmailAddress = model.EmailAddress;

                return ctx.SaveChanges() == 1;
            }

       }      
        //Delete Resident

        public bool DeleteResident(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                     .Residents
                     .Single(e => e.ResidentID == id && e.UserID == _userID);

                ctx.Residents.Remove(entity);
                return ctx.SaveChanges() == 1;

            }

        }

        //Helper methods
        //Get by ResidentID

       public ResidentDetail GetResidentByID(int id)
       {
            using (var ctx = new ApplicationDbContext())
            {
                Resident entity =
                     ctx
                     .Residents
                     .Single(e => e.ResidentID == id && e.UserID == _userID);

                return new ResidentDetail
                {
                    AddressID = entity.AddressID,
                    FullName = entity.FullName,
                    PhoneNumber = entity.PhoneNumber,
                    EmailAddress = entity.EmailAddress
                };
                
            }
       }


    }
}
