using NimapInfotechMachineTest.Models;
using NimapInfotechMachineTest.SqlDbConnection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NimapInfotechMachineTest.Controllers
{
    public class CategoryController : Controller
    {
        #region
        SqlConnection sqlCon;
        SqlCommand cmd;
        Connection conn;
        SqlDataAdapter da;
        #endregion
        // GET: Category
        public ActionResult CategoryPartial()
        {
            return View();
        }
        public ActionResult CategoryView()
        {
            return View();
        }
        public ActionResult CategoryReport(int pg = 1)
        {

            List<CategoryModel> list = new List<CategoryModel>();
            DataTable dt = new DataTable();
            conn = new Connection();
            dt = conn.GetData("Select CategoryId,CategoryName From Category");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                CategoryModel model = new CategoryModel();

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
        public ActionResult CategorySaveOrUpdate(CategoryModel model)
        {
            int response = 0;
            int _return = 0;
            string IUFlag = "";
            bool activ = true;
            try
            {
                if (model.CategoryId == 0)
                {
                    IUFlag = "I";
                    _return = 1;
                    response = 1;
                }
                else
                {
                    IUFlag = "U";
                    _return = 2;
                    response = 2;
                }
                conn = new Connection();
                sqlCon = conn.Connect();
                cmd = new SqlCommand();
                cmd.CommandText = "SpCategory";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = sqlCon;
                cmd.Parameters.AddWithValue("@CategoryId", model.CategoryId);
                cmd.Parameters.AddWithValue("@CategoryName", model.CategoryName);
                cmd.Parameters.AddWithValue("@IsActiv", activ);
                cmd.Parameters.AddWithValue("@IUFlag", IUFlag);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                response = 3;
            }
            finally
            {
                cmd.Dispose();
                sqlCon.Close();
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
            return RedirectToAction("CategoryPartial");
        }
        public ActionResult UpdateCategoryData(int id)
        {

            DataTable dt = new DataTable();
            conn = new Connection();
            dt = conn.GetData("Select * From Category Where CategoryId=" + id);

            {
                CategoryModel model = new CategoryModel();
                {

                    model.CategoryId = Convert.ToInt32(dt.Rows[0]["CategoryId"]);
                    model.CategoryName = dt.Rows[0]["CategoryName"].ToString();
                }
                return PartialView("CategoryPartial", model);

            }
        }
        public ActionResult DeleteCategoryData(int id)
        {
            try
            {
                List<CategoryModel> _list = new List<CategoryModel>();
                Connection Con = new Connection();
                DataTable dt = new DataTable();
                conn = new Connection();
                CategoryModel model = new CategoryModel();
                model.CategoryId = id;
                dt = conn.GetData("Delete From Category Where CategoryId =" + id);
                TempData["Delete"] = "Your Data Delete Sucessfully!";
            }

            catch (Exception Ex)
            {
                throw Ex;
            }
            return View("CategoryPartial");

        }
    }
}