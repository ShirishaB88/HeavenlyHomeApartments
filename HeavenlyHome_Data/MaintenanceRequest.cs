using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeavenlyHome_Data
{
    public enum Category {Appliance, Electrical, BuildingRepairs, Plumbing, Locksandkeys, Blinds, Garage, Other}
    public enum Location {LivingRoom, Bath, BedRoom, DiningRoom, Kitchen, Laundry, Exterior, Entry, Garage, Hallway, Other }
    public enum Appliances  { AC, Dishwasher, Dryer, Washer, WaterHeater, Microwave, Oven, StoveRange, Refrigerator, Other }
    public enum Electrical { alarm, LightsOrBulbs, cableOutlets, FirePlace, CeilingFans, SmokingDetectors, PowerOutage, Other}
    public enum Garage { DoorRepairs, Opener, RemoteControl, Other}
    public enum Plumbing { Hotwater, LeakingFaucet, SinkClogged, TubOrShower, Toilet}
    public enum Exterior { Windows, Roof, Siding, StairRails, Doors, Patio}
    public class MaintenanceRequest
    {
        [Key]
        public int RequestID { get; set; }

        public Guid UserID { get; set; }

        [Required]
        [EnumDataType(typeof(Category))]
        public Category Category { get; set; }

        [Required]
        [EnumDataType(typeof(Location))]
        public Location Location { get; set; }

        [Required]
        [MaxLength(3000)]
        public string Description { get; set; }
       
        public string Status { get; set; }

        public bool AccessPermission { get; set; }
        public DateTimeOffset RequestDate { get; set; }
       
    }
}
