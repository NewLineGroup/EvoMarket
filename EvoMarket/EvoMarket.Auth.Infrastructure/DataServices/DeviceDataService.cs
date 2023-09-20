using EvoMarket.Auth.Infrastructure.Context;

using OnlineShop.Domain.Models;

namespace EvoMarket.Auth.Infrastructure.DataServices;

public class DeviceDataService
{
   private AuthDataContext DataContext { get; set; }

   public DeviceDataService(AuthDataContext dataContext)
   {
      DataContext = dataContext;
   }

   public async Task<Device?> AddDevice(Device? device)
   {
         DataContext.Devices.Add(device);
         await SaveChanges();
         return device;
     
   }

   public async Task<Device?> GetById(int id)
   {
        return DataContext.Devices.Where(device => device.Id == id).FirstOrDefault();
   }


   public async Task<List<Device?>> GetUserDevices(int userId)
   {
         return DataContext.Devices.Where(device => device.UserId == userId).ToList();
   }
   
   public async Task<List<Device?>> GetAllDevices()
   {
      return DataContext.Devices.ToList();
   }
   
   
   public async Task<Device?> UpdateDevice(Device updatedDevice)
   {
     
         var existingDevice = DataContext.Devices.FirstOrDefault(d => d.Id == updatedDevice.Id);

         if (existingDevice != null)
         {
            existingDevice = updatedDevice;
            await SaveChanges();
            return existingDevice;
         }
         return null;
   }

   public async Task<int> DeleteDevice(Device device)
   {
       DataContext.Devices.Remove(device);
       return device.Id;
   }
   
   public async Task SaveChanges()=> await DataContext.SaveChangesAsync();
   
   
}