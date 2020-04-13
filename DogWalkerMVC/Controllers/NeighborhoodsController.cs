using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DogWalkerMVC.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DogWalkerMVC.Controllers
{
    public class NeighborhoodsController : Controller
    {
        private readonly IConfiguration _config;
        public NeighborhoodsController(IConfiguration config)
        {
            _config = config;
        }
        //COMPUTED PROPERTY FOR THE CONNECTION
        public SqlConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }


        // GET: Neighborhoods
        public ActionResult Index()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT n.Id, n.[Name], COUNT(w.NeighborhoodId) as 'Walkers'
                                        FROM Neighborhood n
                                        LEFT JOIN Walker w
                                        ON	w.NeighborhoodId = n.Id
                                        GROUP BY n.Name, n.Id ";
                    var reader = cmd.ExecuteReader();
                    var walkers = new List<NeighborhoodViewModel>();

                    while (reader.Read())
                    {
                        walkers.Add(new NeighborhoodViewModel()
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Name = reader.GetString(reader.GetOrdinal("Name")),
                            Walkers = reader.GetInt32(reader.GetOrdinal("Walkers"))
                        }
                        );
                    }
                    reader.Close();
                    return View(walkers);
                }
            }
        }

        // GET: Neighborhoods/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Neighborhoods/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Neighborhoods/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Neighborhoods/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Neighborhoods/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Neighborhoods/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Neighborhoods/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}