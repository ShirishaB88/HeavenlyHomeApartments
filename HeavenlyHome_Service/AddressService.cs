using HeavenlyHome_Data;
using HeavenlyHome_Models.AddressModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeavenlyHome_Service
{
    public class AddressService
    {
        private readonly Guid _userID;

        public AddressService(Guid userID)
        {
            userID = _userID;
        }

        //Create

        public bool CreateAddress(AddressCreate address)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    new Address
                    {
                        UserID = _userID,
                        FloorPlanID = address.FloorPlanID,
                        FloorPlan = ctx.FloorPlans.Single(e => e.FloorPlanID == address.FloorPlanID),
                       FullAddress = address.FullAddress,
                       IsAvailable = address.IsAvailable

                };
                ctx.Addresses.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //GetAllAddress
        public IEnumerable<AddressListItems> GetAllAddress()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Addresses
                    .Where(e => e.UserID == _userID)
                    .Select(e => new AddressListItems
                    {
                        AddressID = e.AddressID,
                        FloorPlanID = e.FloorPlanID,
                        FullAddress = e.FullAddress,
                        IsAvailable = e.IsAvailable
                    });
                return query.ToList();

            }
        }

        //Update Address

        public bool UpdateAddress(AddressEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Addresses
                    .Single(e => e.AddressID == model.AddressID && e.UserID == _userID);

                entity.AddressID = model.AddressID;
                entity.FloorPlanID = model.FloorPlanID;
                entity.FullAddress = model.FullAddress;
                entity.IsAvailable = model.IsAvailable;

                return ctx.SaveChanges() == 1;
            }
        }

        //Delete Address

        public bool DeleteAddress(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Addresses
                    .Single(e => e.AddressID == id && e.UserID == _userID);

                ctx.Addresses.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        //GET  by AddressID

        public AddressDetail GetByAddressID(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                Address entity =
                    ctx
                    .Addresses
                    .Single(e => e.AddressID == id && e.UserID == _userID);
               return new AddressDetail
               {
                   AddressID = entity.AddressID,
                   FloorPlanID = entity.FloorPlanID,
                   FullAddress = entity.FullAddress,
                   IsAvailable = entity.IsAvailable

               };
            }
        }
    }
}
