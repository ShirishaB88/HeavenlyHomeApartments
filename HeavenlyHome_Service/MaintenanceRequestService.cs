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
             _userID = userID;
        }

        //Create MaintenanceRequest

        public bool CreateMaintenanceRequest(MaintenanceRequestCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = new MaintenanceRequest
                {
                    UserID = _userID,            
                    Category = model.Category,               
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
                    .Where(e => e.UserID == _userID )
                    .Select(e => new MaintenanceRequestListItem
                    {
                        RequestID = e.RequestID,
                        Category = e.Category,
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
                    .Single(e => e.RequestID == model.RequestID && e.UserID == _userID);

                entity.RequestID = model.RequestID;
                entity.Category = model.Category;
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
                    .Single(e => e.RequestID == id && e.UserID == _userID);
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
                    Category = entity.Category,
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
