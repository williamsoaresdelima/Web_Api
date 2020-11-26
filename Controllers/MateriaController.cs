using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Model;

namespace WebAPI.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class MateriaController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public MateriaController(DatabaseContext context)
        {
            _context = context;
        }

        [Route("AddMateria")]
        [HttpPost]
        public ActionResult<Materia> AddMateria(Materia materia)
        {
            if(materia==null)
            {
                return StatusCode(415, "Matéria Inválida");
            }

            _context.Materia.Add(materia);
            _context.SaveChanges();
            return Ok(materia);
        }

        [Route("GetAllMateria")]
        [HttpGet]
        public ActionResult<List<Materia>> GetAllMateria()
        {
            return Ok(_context.Materia.Where(a=>a.isdelete==0).ToList());
        }

        [Route("GetAllMateriaForDDL")]
        [HttpGet]
        public ActionResult<List<Materia>> GetAllMateriaForDDL()
        {
            return Ok(_context.Materia.Where(a => a.isdelete == 0 && a.isactive==1).ToList());
        }

        [Route("GetMateriaById/{id}")]
        [HttpGet]
        public ActionResult<Materia> GetMateriaById(int id)
        {
            var materia = _context.Materia.FirstOrDefault(a => a.id == id && a.isdelete==0);
            return Ok(materia);
        }

        [Route("UpdateMateriaStatus/{id}")]
        [HttpGet]
        public ActionResult<Materia> UpdateMateriaStatus(int id)
        {
            var materiaInDb = _context.Materia.FirstOrDefault(a => a.id == id && a.isdelete == 0);
            materiaInDb.isactive = materiaInDb.isactive == 1 ? 0 : 1;

            _context.SaveChanges();
            return Ok(materiaInDb);
        }

        [Route("UpdateMateria")]
        [HttpPut]
        public ActionResult<Materia> UpdateMateria(Materia materia)
        {
            var materiaInDb = _context.Materia.FirstOrDefault(a => a.id == materia.id);
            materiaInDb.name = materia.name;
            materiaInDb.isdelete = materia.isdelete;
            materiaInDb.isactive = materia.isactive;

            _context.SaveChanges();
            return Ok(materia);
        }

       

    }
}