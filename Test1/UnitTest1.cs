using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hospital.ViewModels;
using System;
using Hospital.Models;

namespace Hospital.Tests
{
    [TestClass]
    public class TimingViewModelTests
    {
        [TestMethod]
        public void ConvertViewModelToModel_ConvertsCorrectly()
        {
            
            var timingViewModel = new TimingViewModel
            {
                Id = 1,
                ScheduleDate = DateTime.Now,
                MorningShiftStartTime = 8,
                MorningShiftEndTime = 12,
                AfternoonShiftStartTime = 13,
                AfternoonShiftEndTime = 17,
                Duration = 60,
                Status = Status.Active,
                DoctorId = 1
            };

            
            var timingModel = timingViewModel.ConvertViewModelToModel();

      
            Assert.IsNotNull(timingModel);
            Assert.AreEqual(timingViewModel.Id, timingModel.Id);
            Assert.AreEqual(timingViewModel.ScheduleDate, timingModel.Date);
            Assert.AreEqual(timingViewModel.MorningShiftStartTime, timingModel.MorningShiftStartTime);
            Assert.AreEqual(timingViewModel.MorningShiftEndTime, timingModel.MorningShiftEndTime);
            Assert.AreEqual(timingViewModel.AfternoonShiftStartTime, timingModel.AfternoonShiftStartTime);
            Assert.AreEqual(timingViewModel.AfternoonShiftEndTime, timingModel.AfternoonShiftEndTime);
            Assert.AreEqual(timingViewModel.Duration, timingModel.Duration);
            Assert.AreEqual(timingViewModel.Status, timingModel.Status);
            Assert.AreEqual(timingViewModel.DoctorId, timingModel.DoctorId);
        }
    }
}
