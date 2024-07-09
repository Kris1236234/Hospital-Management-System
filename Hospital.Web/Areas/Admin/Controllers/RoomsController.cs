using Hospital.Services;
using Hospital.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Room.Web.Areas.Admin.Controllers
{
    [Area("admin")]
    public class RoomsController : Controller
    {
        private readonly IRoomService _room;
        private readonly IHospitalInfo _hospitalInfo;

        public RoomsController(IRoomService room, IHospitalInfo hospitalInfo)
        {
            _room = room;
            _hospitalInfo = hospitalInfo;
        }

        public IActionResult Index(int pageNumber = 1, int pageSize = 10)
        {
            var viewModel = _room.GetAll(pageNumber, pageSize);
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.hospital = new SelectList(_hospitalInfo.GetAll(), "Id", "Name");
            var viewModel = _room.GetRoomById(id);
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Edit(RoomViewModel vm)
        {
            _room.UpdateRoom(vm);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.hospital = new SelectList(_hospitalInfo.GetAll(), "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(RoomViewModel vm)
        {
            _room.InsertRoom(vm);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _room.DeleteRoom(id);
            return RedirectToAction("Index");
        }
    }
}
