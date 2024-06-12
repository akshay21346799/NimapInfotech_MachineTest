using NimapInfotechMachineTest.Models;
using NimapInfotechMachineTest.SqlDbConnection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NimapInfotechMachineTest.Controllers
{
    public class ProductController : Controller
    {
        #region
        SqlConnection sqlcon;
        SqlCommand cmd;
        Connection conn;
        SqlDataAdapter da;
        #endregion
        public ActionResult ProductPartialView()
        {
            ViewBag.Category = DropdownList();

            return View();
        }

        public ActionResult ProductView()
        {
            ViewBag.Category = DropdownList();

            return View();
        }

        public List<SelectListItem>DropdownList()
        {
            DataTable dt = new DataTable();
            var list = new List<SelectListItem>();
            list.Add(new SelectListItem { Value = "0", Text = "--Select Category--" });
            try
            {
                conn = new Connection();
                dt = conn.GetData("Select * From Category Where IsActive='True'");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    list.Add(new SelectListItem { Value = dt.Rows[i]["CategoryId"].ToString(), Text = dt.Rows[i]["CategoryName"].ToString() });

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return list;

        }
        public ActionResult ProductSaveOrUpdate(ProductModel model)
        {
            int response = 0;
            int _return = 0;
            string Flag = "";
            try
            {
                if (model.ProductId == 0)
                {
                    Flag = "I";
                    _return = 1;
                    response = 1;
                }
                else
                {
                    Flag = "U";
                    _return = 2;
                    response = 2;
                }
                conn = new Connection();
                sqlcon = conn.Connect();
                cmd = new SqlCommand();
                cmd.CommandText = "SpProduct";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = sqlcon;
                cmd.Parameters.AddWithValue("@ProductId", model.ProductId);
                cmd.Parameters.AddWithValue("@ProductName", model.ProductName);
                cmd.Parameters.AddWithValue("@CategoryId", model.CategoryId);               
                cmd.Parameters.AddWithValue("@Flag", Flag);
                cmd.ExecuteNonQuery();
                //TempData["message"] = "Your Data Save Successfully !!!";
            }
            catch (Exception ex)
            {
                response = 3;
            }
            finally
            {
                cmd.Dispose();
                sqlcon.Close();
            }
            if (response == 1)
            {
                TempData["Save"] = "Your Data Save Successfuly !!";
            }
            else if (response == 2)
            {
                TempData["Update"] = "Your Data Update Successfuly !!";
            }
            else
            {
                TempData["Delete"] = "Your Data Delete Successfuly !!";
            }
            return RedirectToAction("ProductPartialView");
        }
        public ActionResult ProductReport(int pg = 1)
        {

            List<ProductReportModel> list = new List<ProductReportModel>();
            DataTable dt = new DataTable();
            conn = new Connection();
            dt = conn.GetData("Select ProductId,ProductName,C.CategoryId,C.CategoryName From Product P inner join Category C on C.CategoryId=P.CategoryId");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ProductReportModel model = new ProductReportModel();
                model.ProductId = Convert.ToInt32(dt.Rows[i]["ProductId"]);
                model.ProductName = dt.Rows[i]["ProductName"].ToString();
                model.CategoryId = Convert.ToInt32(dt.Rows[i]["CategoryId"]);
                model.CategoryName = dt.Rows[i]["CategoryName"].ToString();
                list.Add(model);
            }

            const int pageSize = 10;
            if (pg < 1)
            {
                pg = 1;
            }
            int totalCount = list.Count();
            var pager = new Pager(totalCount, pg, pageSize);

            if (pg > pager.TotalPages)
            {
                pg = pager.TotalPages;
            }

            int recordsToSkip = (pg - 1) * pageSize;
            var data = list.Skip(recordsToSkip).Take(pageSize).ToList();
            ViewBag.pager = pager;

            return View(data);
        }
        public ActionResult UpdateProductData(int id)
        {
            ViewBag.Category = DropdownList();

            DataTable dt = new DataTable();
            conn = new Connection();
            dt = conn.GetData("Select * From Product Where ProductId=" + id);

            {
                ProductModel model = new ProductModel();
                {

                    model.ProductId = Convert.ToInt32(dt.Rows[0]["ProductId"]);
                    model.ProductName = dt.Rows[0]["ProductName"].ToString();                  
                    model.CategoryId = Convert.ToInt32(dt.Rows[0]["CategoryId"]);

                }
                //TempData["update"] = "Your Data Update Sucessfully!";
                return PartialView("ProductPartialView", model);

            }
        }
        public ActionResult DeleteProductData(int id)
        {
            ViewBag.Category = DropdownList();

            try
            {
                List<ProductReportModel> _list = new List<ProductReportModel>();
                Connection Con = new Connection();
                DataTable dt = new DataTable();
                conn = new Connection();
                ProductModel model = new ProductModel();
                model.ProductId = id;
                dt = conn.GetData("Delete From Product Where ProductId =" + id);
                TempData["Delete"] = "Your Data Delete Sucessfully!";
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
            return View("ProductPartialView");

        }
    }
}