using Hospital.Models;
using Hospital.Repositories.Interfaces;
using Hospital.ViewModels;
using hospitals.Utilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hospital.Services
{
    [Area("admin")]
    public class RoomService : IRoomService
    {
        private readonly IGenericRepository<Room> _roomRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RoomService(IGenericRepository<Room> roomRepository, IUnitOfWork unitOfWork)
        {
            _roomRepository = roomRepository ?? throw new ArgumentNullException(nameof(roomRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public void DeleteRoom(int id)
        {
            var room = _roomRepository.GetById(id);
            if (room != null)
            {
                _roomRepository.Delete(room);
                _unitOfWork.Save();
            }
        }

        public PagedResult<RoomViewModel> GetAll(int pageNumber, int pageSize)
        {
            var query = _roomRepository.GetAll();
            var skipAmount = pageSize * (pageNumber - 1);
            var rooms = query.Skip(skipAmount).Take(pageSize).ToList();
            var totalRecords = query.Count();
            var roomViewModels = rooms.Select(room => new RoomViewModel(room)).ToList();

            return new PagedResult<RoomViewModel>
            {
                Data = roomViewModels,
                TotalItems = totalRecords,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public IEnumerable<RoomViewModel> GetAll()
        {
            var roomList = _roomRepository.GetAll().ToList();
            return roomList.Select(room => new RoomViewModel(room)).ToList();
        }

        public List<RoomViewModel> GetAvailableRooms()
        {
            var availableRooms = _roomRepository
                .GetAll(r => r.Status == "Dostępny")
                .Select(room => new RoomViewModel(room))
                .ToList();
            return availableRooms;
        }

        public RoomViewModel GetRoomById(int roomId)
        {
            var room = _roomRepository.GetById(roomId);
            return new RoomViewModel(room);
        }

        public void InsertRoom(RoomViewModel roomVM)
        {
            var room = roomVM.ConvertViewModelToModel();
            _roomRepository.Add(room);
            _unitOfWork.Save();
        }

        public bool IsRoomAvailable(int roomId, DateTime startDate, DateTime endDate)
        {
            var room = _roomRepository.GetById(roomId);
            return room != null;
        }

        public void ReserveRoom(int roomId, DateTime startDate, DateTime endDate)
        {
            
            _unitOfWork.Save();
        }

        public void ReleaseRoom(int roomId, DateTime startDate, DateTime endDate)
        {

            var room = _roomRepository.GetById(roomId);


            if (room != null)
            {

                room.Status = "Dostępny";
                _unitOfWork.Save();
            }
        }


            public void UpdateRoom(RoomViewModel roomVM)
        {
            var room = _roomRepository.GetById(roomVM.Id);
            if (room != null)
            {
                room.RoomNumber = roomVM.RoomNumber;
                room.Status = roomVM.Status;
                room.HospitalId = roomVM.HospitalInfoId;
                room.Type = roomVM.Type;
                room.IsUnavailable = roomVM.IsUnavailable;
                _roomRepository.Update(room);
                _unitOfWork.Save();
            }
        }
    }
}
