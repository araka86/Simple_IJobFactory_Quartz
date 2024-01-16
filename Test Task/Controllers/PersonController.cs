using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Test_Task.Models;
using Test_Task.Services;



namespace Test_Task.Controllers
{
    [ApiController]
    [Route("api/person")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public PersonController(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;

        }



        [HttpGet]
        public IActionResult GetAll()
        {
            var people = _personRepository.GetAll();
            return Ok(people);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var person = _personRepository.GetById(id);

            if (person == null)
                return NotFound();

            return Ok(person);
        }

        [HttpPost]
        public IActionResult Create([FromBody] PersonDto personDto)
        {
            if (personDto == null || !ModelState.IsValid)
                return BadRequest();


            var person = _mapper.Map<Person>(personDto);


            person.Id = Guid.NewGuid();

            _personRepository.Add(person);


            return CreatedAtAction(nameof(GetById), new { id = person.Id }, person);
        }



        [HttpPut("{id}")]
        public IActionResult Update(Guid id, [FromBody] PersonDto personDto)
        {
            if (personDto == null || !ModelState.IsValid)
                return BadRequest();

            var existingPerson = _personRepository.GetById(id);

            if (existingPerson == null)
                return NotFound();

            _mapper.Map(personDto, existingPerson);

            _personRepository.Update(existingPerson);
            return NoContent();
        }



        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var person = _personRepository.GetById(id);

            if (person == null)
                return NotFound();

            _personRepository.Delete(id);
            return NoContent();
        }
    }



}
