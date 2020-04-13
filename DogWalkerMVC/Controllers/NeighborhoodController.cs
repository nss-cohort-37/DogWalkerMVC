using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DogWalkerMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DogWalkerMVC.Controllers
{
    public class NeighborhoodController : Controller
    {
        private readonly IConfiguration _config;

        public NeighborhoodController(IConfiguration config)
        {
            _config = config;
        }

        public SqlConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }


        // GET: Neighborhood
        public ActionResult Index()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using(SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                        SELECT n.Id, n.Name
                        FROM Neighborhood n";
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<Neighborhood> neighborhoods = new List<Neighborhood>();
                    while(reader.Read())
                    {
                        Neighborhood neighborhood = new Neighborhood
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            Name = reader.GetString(reader.GetOrdinal("Name"))
                        };
                        neighborhoods.Add(neighborhood);
                    }
                    reader.Close();
    
                    return View(neighborhoods);
                }
            }
        }

        // GET: Neighborhood/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Neighborhood/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Neighborhood/Create
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

        // GET: Neighborhood/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Neighborhood/Edit/5
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

        // GET: Neighborhood/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Neighborhood/Delete/5
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