using HeavenlyHome_Data;
using HeavenlyHome_Models.FloorPlanModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeavenlyHome_Service
{
    public class FloorPlanService
    {
        private readonly Guid _userID;

        public FloorPlanService(Guid userID)
        {
            _userID = userID;
        }

        public bool CreateFloorPlan(FloorPlanCreate model)
        {
              var entity =
                new FloorPlan()
                {
                    UserID = _userID,
                    NoOfBaths = model.NoOfBaths,
                    NoOfBeds = model.NoOfBeds,
                    AreaInSqFt = model.AreaInSqFt,
                    Price = model.Price,
                    NoOfGarageSpaces = model.NoOfGarageSpaces,
                    Image = model.Image,
                    IsAvailable = model.IsAvailable,
                    CreatedDate = DateTimeOffset.Now

                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.FloorPlans.Add(entity);
               return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<FloorPlanListItem> GetFloorPlans()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .FloorPlans
                    .Where(e => e.UserID == _userID)
                    .Select(e => new FloorPlanListItem
                    {
                        FloorPlanID = e.FloorPlanID,
                        NoOfBaths = e.NoOfBaths,
                        NoOfBeds = e.NoOfBeds,
                        AreaInSqFt = e.AreaInSqFt,
                        Price = e.Price,
                        NoOfGarageSpaces = e.NoOfGarageSpaces,
                        Image = e.Image,
                        IsAvailable = e.IsAvailable,
                        CreatedDate = e.CreatedDate

                    });
                return query.ToArray();
            }
        }
    }
}
