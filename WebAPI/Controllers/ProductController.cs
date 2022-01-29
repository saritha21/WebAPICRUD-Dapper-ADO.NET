using DAL;
using DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Dapper.DAL;
using ADO.NET.DAL;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        AppDbContext _db;
        public ProductController(AppDbContext db)
        {
            _db = db;
        }

        //[HttpGet]
        //public IEnumerable<Product> GetAll()
        //{
        //    return _db.Products.ToList(); //200
        //}

        //[HttpGet]
        //public IEnumerable<Dapper.DAL.Product> GetAll()
        //{
        //    DapperDAL dal = new DapperDAL();

        //    return dal.GetAllProducts(); //200
        //}

        [HttpGet]
        public IEnumerable<ADO.NET.DAL.Product> GetAll()
        {
            ADONETDAL dal = new ADONETDAL();

            return dal.GetAllProducts(); //200
        }

        //[HttpGet("{Id}")]
        //public Dapper.DAL.Product Get(int Id)
        //{
        //    return _db.Products.Find(Id); //200
        //}

        //[HttpPost]
        //public IActionResult Add([FromBody] Dapper.DAL.Product model)
        //{
        //    try
        //    {
        //        _db.Products.Add(model);
        //        _db.SaveChanges();
        //        return StatusCode(StatusCodes.Status201Created, model); //201
        //        return Created("/api/product", model); //201
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message); //500
        //    }
        //}


        [HttpPost]
        public IActionResult Add([FromBody] ADO.NET.DAL.Product model)
        {
            try
            {
                ADONETDAL dal = new ADONETDAL();

                dal.CreateProduct(model); //200
               
                return Created("/api/product", model); //201
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message); //500
            }
        }

        //[HttpPost]
        //public IActionResult Add([FromBody] ADO.NET.DAL.Product model)
        //{
        //    try
        //    {
        //        DapperDAL dal = new DapperDAL();

        //        dal.CreateProduct(model); //200

        //        return Created("/api/product", model); //201
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message); //500
        //    }
        //}

        [HttpPut("{id}")]
        public IActionResult Update(int id, Dapper.DAL.Product model)
        {
            try
            {
                if (id != model.Id)
                    return BadRequest();

                DapperDAL dal = new DapperDAL();

                dal.UpdateProduct(model); //200

                //_db.Products.Update(model);
                //_db.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

      
    }
}
