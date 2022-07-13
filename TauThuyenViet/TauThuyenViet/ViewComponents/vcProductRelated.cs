using Microsoft.AspNetCore.Mvc;
using TauThuyenViet.Models;

namespace TauThuyenViet.ViewComponents
{
	public class vcProductRelated : ViewComponent
	{
		public IViewComponentResult Invoke(int? cid)
		{
			DBContext db = new DBContext();
			var data = db.Products.Where(x => x.Status == true)
								  .OrderByDescending(x => x.CreateTime)
								  .AsQueryable();	

			if(cid > 0)
            {
				data = data.Where(x => x.ProductCategoryID == cid);
            }
			return View(data.Take(6).ToList());
		}
	}
}
