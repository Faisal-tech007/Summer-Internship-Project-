using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Summer_Intership_Application.Data;
using Summer_Intership_Application.Models;

namespace Summer_Intership_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public QuestionController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpPost]
        [Route("postendpoint post questions by various type Paragraph, YesNo, Dropdown, MultipleChoice, Date, Number")]
        public async Task<ActionResult<Question>> PostQuestion(Question question)
        {
            if (question == null)
            {
                return BadRequest("Question object is null");
            }

            _dataContext.Questions.Add(question);
            await _dataContext.SaveChangesAsync();

            return Ok(question);
        }

        [HttpGet]
        [Route("GET endpoint for the front-end team to render the questions based on the question type.")]
        public async Task<ActionResult<IEnumerable<Question>>> GetQuestionsByType(string type)
        {
            var questions = await _dataContext.Questions
                .Where(q => q.Type == type)
                .ToListAsync();

            if (questions == null || questions.Count == 0)
            {
                return NotFound();
            }

            return questions;
        }

        [HttpPut]
        [Route("Update question after user wants to edit the question after creating the application.")]
        public async Task<IActionResult> PutQuestion(int id, Question question)
        {
            if (id != question.Id)
            {
                return BadRequest();
            }

            _dataContext.Entry(question).State = EntityState.Modified;

            try
            {
                await _dataContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        private bool QuestionExists(int id)
        {
            return _dataContext.Questions.Any(e => e.Id == id);
        }
    }
}
