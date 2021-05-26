using HeavenlyHome_Data;
using HeavenlyHome_Models.MaintenanceRequestModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeavenlyHome_Service
{
    public class MaintenanceRequestService
    {
        private readonly Guid _userID;

        public MaintenanceRequestService(Guid userID)
        {
            userID = _userID;
        }

        //Create MaintenanceRequest

        public bool CreateMaintenanceRequest(MaintenanceRequestCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = new MaintenanceRequest
                {
                    UserID = _userID,
                    ResidentID = model.ResidentID,
                    Resident = ctx.Residents.Single(e => e.ResidentID == model.ResidentID),
                    Category = model.Category,
                    SubCategory = model.SubCategory,
                    Location = model.Location,
                    Description = model.Description,
                    Status = model.Status,
                    AccessPermission = model.AccessPermission,
                    RequestDate = DateTimeOffset.Now

                };

                ctx.MaintenanceRequests.Add(entity);
                return ctx.SaveChanges() == 1;

            }

        }
        //Get all MaintenanceRequests

        public IEnumerable<MaintenanceRequestListItem> GetAllMaintenanceRequests()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .MaintenanceRequests
                    .Where(e => e.RequestID >= 1 )
                    .Select(e => new MaintenanceRequestListItem
                    {
                        RequestID = e.RequestID,
                        ResidentID = e.ResidentID,
                        Resident = e.Resident,
                        Category = e.Category,
                        SubCategory = e.SubCategory,
                        Location = e.Location,
                        Description = e.Description,
                        Status = e.Status,
                        AccessPermission = e.AccessPermission,
                        RequestDate = e.RequestDate
                        
                    });

                return query.ToArray();
            }

        }
        //Update MaintenanceRequest

        public bool UpdateMaintenanceRequest(MaintenanceRequestEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .MaintenanceRequests
                    .Single(e => e.RequestID == model.RequestID);

                entity.RequestID = model.RequestID;
                entity.ResidentID = model.ResidentID;
                entity.Category = model.Category;
                entity.SubCategory = model.SubCategory;
                entity.Location = model.Location;
                entity.Description = model.Description;
                entity.Status = model.Status;
                entity.AccessPermission = model.AccessPermission;
                entity.RequestDate = model.RequestDate;

                return ctx.SaveChanges() == 1;
                   
            }
        }
        //Delete MaintenanceRequest

        public bool DeleteMaintenanceRequest(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .MaintenanceRequests
                    .Single(e => e.RequestID == id);
                ctx.MaintenanceRequests.Remove(entity);
                return ctx.SaveChanges() == 1;

            }
        }

        //Get by RequestID

        public MaintenanceRequestDetails GetByRequestID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .MaintenanceRequests
                    .Single(e => e.RequestID == id && e.UserID == _userID);

                return new MaintenanceRequestDetails
                {
                    RequestID = entity.RequestID,
                    ResidentID = entity.ResidentID,
                    Resident = ctx.Residents.Single(e => e.ResidentID == entity.ResidentID),
                    Category = entity.Category,
                    SubCategory = entity.SubCategory,
                    Location = entity.Location,
                    Description = entity.Description,
                    Status = entity.Status,
                    AccessPermission = entity.AccessPermission,
                    RequestDate = entity.RequestDate
                };


            }

        }




    }
}
