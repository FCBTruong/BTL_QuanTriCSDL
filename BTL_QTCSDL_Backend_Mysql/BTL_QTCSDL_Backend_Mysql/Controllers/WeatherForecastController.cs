using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using BTL_QTCSDL_Backend_Mysql.Models.DBModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using Microsoft.EntityFrameworkCore;


namespace BTL_QTCSDL_Backend_Mysql.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private btl_quantricsdlContext _context;

        MySql.Data.MySqlClient.MySqlConnection conn;
        string myConnectionString;

        public WeatherForecastController(btl_quantricsdlContext context)
        {
            this._context = context;
            myConnectionString = "Server=localhost;Port=3307;User=root;Password=huytruong9112k;Database=btl_quantricsdl";
            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {

            }
        }

        [HttpGet]
        [Route("/Message/Get")]
        public ActionResult<IEnumerable<string>> Get()
        {
            var result = _context.Weapons.FromSqlRaw("Select * from weapons");
            return Ok(result);
        }

        [HttpPost]
        [Route("/Message/Post")]
        public ActionResult<IEnumerable<string>> Post()
        {
            string response = "ok";
            for (int i = 151; i < 1500000; i++)
            {
                string cmdStr = "INSERT INTO weapons VALUES (" + i + ',' + "'MMMM'" + ");";
                Console.WriteLine(cmdStr);
                var cmd = conn.CreateCommand() as MySqlCommand;
                cmd.CommandText = @cmdStr;
                // @"INSERT INTO weapons VALUES (i,'XX');"

                var recs = cmd.ExecuteNonQuery();
            }
            return Ok(response);
        }
    }
}