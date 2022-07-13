using Microsoft.AspNetCore.Mvc;
using TauThuyenViet.Models;

namespace TauThuyenViet.Controllers
{
    public class ContactController : Controller
    {
        [HttpGet]
        [Route("/lien-he", Name = "Contact")]
        [Route("/contact")]
        public IActionResult Index()
        {
            ViewBag.Title = "Liên Hệ";
            ViewBag.MessageType = "alert alert-info";
            ViewBag.MessageText = "Mời Nhập Thông Tin";

            return View();
        }


        [HttpPost]
        [Route("/lien-he", Name = "Contact")]
        [Route("/contact")]
        public IActionResult Index(Contact item)
        {
            //Kiếm tra lỗi
            if(item == null) //Nếu tất cả đều null k nhập gì hết thì báo
            {
                ViewBag.MessageType = "alert alert-danger";
                ViewBag.MessageText = "Mời Nhập Thông Tin";
                ViewBag.Title = "Liên Hệ";
                return View();
            }

            if(string.IsNullOrEmpty(item.FullName))
            {
                ViewBag.MessageType = "alert alert-danger";
                ViewBag.MessageText = "Mời Nhập Họ Tên";
                ViewBag.Title = "Liên Hệ";
                return View();
            }

            if (string.IsNullOrEmpty(item.Mobi))
            {
                ViewBag.MessageType = "alert alert-danger";
                ViewBag.MessageText = "Mời Nhập Điện Thoại";
                ViewBag.Title = "Liên Hệ";
                return View();
            }

            if (string.IsNullOrEmpty(item.Content))
            {
                ViewBag.MessageType = "alert alert-danger";
                ViewBag.MessageText = "Mời Nhập Nội Dung";
                ViewBag.Title = "Liên Hệ";
                return View();
            }

            item.CreateTime = DateTime.Now;
            item.Status = false;

            DBContext db = new DBContext();
            db.Contacts.Add(item);
            db.SaveChanges();

            ViewBag.MessageType = "alert alert-success";
            ViewBag.MessageText = "Cảm Ơn Đã Liên Hệ. Chúng Tôi Sẽ Phản Hồi Sớm";
            ViewBag.Title = "Liên Hệ";

            //Reset form khi gửi 
            ModelState.Clear();
            return View();
        }
    }
}
