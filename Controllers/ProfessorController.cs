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
    public class ProfessorController : ControllerBase
    {
        private DatabaseContext _context;

        public ProfessorController(DatabaseContext context)
        {
            _context = context;
        }

        [Route("GetAllProfessor")]
        [HttpGet]
        public ActionResult<List<Professor>> GetAllProfessor()
        {
            return _context.Professor.ToList();
        }

        [Route("GetProfessorById/{id}")]
        [Route("{id}")]
        [HttpGet]
        public ActionResult<Professor> GetProfessorById(int id)
        {
            var professor = _context.Professor.FirstOrDefault(a => a.id == id);
            return Ok(professor);
        }

        [Route("AddProfessor")]
        [HttpPost]
        public ActionResult<Professor> AddProfessor(Professor professor)
        {
            _context.Professor.Add(professor);
            _context.SaveChanges();
            return Ok(professor);
        }

        [Route("UpdateProfessor")]
        [HttpPut]
        public ActionResult<Professor> UpdateProfessor(Professor professor)
        {
            var professorInDb = _context.Professor.FirstOrDefault(a => a.id == professor.id);
            professorInDb.name = professor.name;
            _context.SaveChanges();
            return Ok(professor);
        }


        [Route("DeleteProfessor/{id}")]
        [HttpDelete]
        public ActionResult<Professor> DeleteProfessor(int id)
        {
            var professorInDb = _context.Professor.FirstOrDefault(a => a.id == id);
            _context.Remove(professorInDb);
            _context.SaveChanges();
            return Ok(professorInDb);
        }
    }
}