using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hospital.Models;
using Hospital.ViewModels;

namespace Hospital.Tests
{
    [TestClass]
    public class RoomViewModelTests
    {
        [TestMethod]
        public void ConvertViewModelToModelTest()
        {
           
            var roomViewModel = new RoomViewModel
            {
                Id = 1,
                RoomNumber = "101",
                Type = "Standard",
                Status = "Occupied",
                HospitalInfoId = 1,
                HospitalInfo = new HospitalInfo { Id = 1, Name = "Hospital A" }
            };

           
            var roomModel = roomViewModel.ConvertViewModelToModel();

           
            Assert.IsNotNull(roomModel);
            Assert.AreEqual(roomViewModel.Id, roomModel.Id);
            Assert.AreEqual(roomViewModel.RoomNumber, roomModel.RoomNumber);
            Assert.AreEqual(roomViewModel.Type, roomModel.Type);
            Assert.AreEqual(roomViewModel.Status, roomModel.Status);
            Assert.AreEqual(roomViewModel.HospitalInfoId, roomModel.HospitalId);
        }
    }
}
