using Hospital.ViewModels;
using hospitals.Utilities;
using System.Collections.Generic;

namespace Hospital.Services
{
    public interface IRoomService
    {
        List<RoomViewModel> GetAvailableRooms();
        RoomViewModel GetRoomById(int roomId);
        void UpdateRoom(RoomViewModel roomVM);
        void InsertRoom(RoomViewModel roomVM);
        void DeleteRoom(int id);
        PagedResult<RoomViewModel> GetAll(int pageNumber, int pageSize);
        IEnumerable<RoomViewModel> GetAll();
        bool IsRoomAvailable(int roomId, DateTime startDate, DateTime endDate);
        void ReserveRoom(int roomId, DateTime startDate, DateTime endDate);
        void ReleaseRoom(int roomId, DateTime startDate, DateTime endDate);
    }
}
