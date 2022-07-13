using Microsoft.AspNetCore.Mvc;
using TauThuyenViet.Models;
using Microsoft.EntityFrameworkCore;

namespace TauThuyenViet.Controllers
{
    public class ProductController : Controller
    {
        [Route("/san-pham", Name = "ProductList")]
        [Route("/san-pham/{mid}/{cid}/{title}", Name = "ProductListByID")]
        public IActionResult Index(int mid, int cid, string title)
        {
            DBContext db = new DBContext();
            var data = db.Products.AsQueryable();
            //Nếu có cid, thì load sp theo menu cấp 2
            if (cid > 0)
            {
                //Load list data của cate
                data = data.Where(x => x.ProductCategoryID == cid);

                //Query lấy cat title
                var catItem = db.ProductCategories
                                .Where(x => x.ProductCategoryID == cid)
                                .FirstOrDefault();
                if (catItem != null)
                    ViewBag.Title = catItem.Title;
            }
            //Nếu Không có cid, mà có mid thì load sp theo menu cấp 1
            else if (mid > 0)
            {
                data = data.Include(x => x.ProductCategory)
                           .Where(x => x.ProductCategory.ProductMainCategoryID == mid);

                //Query lấy mainCat title
                var mainCatItem = db.ProductMainCategories
                                    .Where(x => x.ProductMainCategoryID == mid)
                                    .FirstOrDefault();
                if (mainCatItem != null)
                    ViewBag.Title = mainCatItem.Title;

            }
            //Còn lại không có cả 2 thì load all
            else
            {
                ViewBag.Title = "Sản Phẩm";
            }

            return View(data.ToList());
        }

        [Route("/chi-tiet-san-pham/{ID}/{title}", Name = "ProductDetail")]
        [Route("/product-detail")]
        public IActionResult Detail(int ID, string title)
        {
            DBContext db = new DBContext();
            var data = db.Products.Where(x => x.ProductID == ID).FirstOrDefault();


            if (data != null)
            {
                ViewBag.Title = data.Title;
            }
            return View(data);
        }
    }
}
