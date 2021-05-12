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
        //GET: GetFloorPlansByID
        public FloorPlanDetail GetFloorPlanByID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .FloorPlans
                    .Single(e => e.FloorPlanID == id && e.UserID == _userID);
                return
                    new FloorPlanDetail
                    {
                        FloorPlanID = entity.FloorPlanID,
                        NoOfBeds = entity.NoOfBeds,
                        NoOfBaths = entity.NoOfBaths,
                        AreaInSqFt = entity.AreaInSqFt,
                        Price = entity.Price,
                        NoOfGarageSpaces = entity.NoOfGarageSpaces,
                        Image = entity.Image,
                        IsAvailable = entity.IsAvailable,
                        CreatedDate = entity.CreatedDate,
                        ModifiedDate = entity.ModifiedDate
                    };

            }
        }
        //GET: GetFloorPlansBySpecifications(NoOFBeds,NoOFBaths,ISAvailable,AreaRange,NoOfGarage,PriceRange)

        public FloorPlanDetail GetFloorPlanByAvailability()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .FloorPlans
                    .FirstOrDefault(e => e.IsAvailable == true);
                return
                    new FloorPlanDetail
                    {
                        FloorPlanID = entity.FloorPlanID,
                        NoOfBeds = entity.NoOfBeds,
                        NoOfBaths = entity.NoOfBaths,
                        AreaInSqFt = entity.AreaInSqFt,
                        Price = entity.Price,
                        NoOfGarageSpaces = entity.NoOfGarageSpaces,
                        Image = entity.Image,
                        IsAvailable = entity.IsAvailable,
                        CreatedDate = entity.CreatedDate,
                        ModifiedDate = entity.ModifiedDate

                    };

            }

        }

        public bool UpdateFloorPlan(FloorPlanEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .FloorPlans
                    .Single(e => e.FloorPlanID == model.FloorPlanID && e.UserID == _userID);

                entity.NoOfBaths = model.NoOfBaths;
                entity.NoOfBeds = model.NoOfBeds;
                entity.AreaInSqFt = model.AreaInSqFt;
                entity.Price = model.Price;
                entity.NoOfGarageSpaces = model.NoOfGarageSpaces;
                entity.Image = model.Image;
                entity.IsAvailable = model.IsAvailable;
                entity.ModifiedDate = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;

            }
        }

        public bool DeleteFloorPlan(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .FloorPlans
                    .Single(e => e.FloorPlanID == id && e.UserID == _userID);
                ctx.FloorPlans.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
