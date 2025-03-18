using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AirbnbAPI.Business;
using AirbnbAPI.Data;

namespace AirbnbAPI.Controllers
{
    [Route("api/[controller]")] // Define a rota base para o controller (api/properties)
    [ApiController]
    public class PropertiesController : ControllerBase
    {
        private readonly IPropertyService _propertyService;

        public PropertiesController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }

        // GET: api/properties
        [HttpGet]
        public ActionResult<List<Property>> GetAllProperties()
        {
            return _propertyService.GetAllProperties(); // Retorna todas as propriedades
        }

        // GET: api/properties/5
        [HttpGet("{id}")]
        public ActionResult<Property> GetPropertyById(int id)
        {
            var property = _propertyService.GetPropertyById(id); // Busca uma propriedade pelo ID
            if (property == null)
            {
                return NotFound(); // Retorna 404 (Not Found) se a propriedade não for encontrada
            }
            return property; // Retorna a propriedade encontrada
        }

        // POST: api/properties
        [Authorize] // Protege o endpoint com autenticação JWT
        [HttpPost]
        public ActionResult<Property> AddProperty([FromBody] Property property)
        {
            var newProperty = _propertyService.AddProperty(property); // Adiciona uma nova propriedade
            return CreatedAtAction(nameof(GetPropertyById), new { id = newProperty.Id }, newProperty); // Retorna 201 (Created) com a propriedade criada
        }

        // PUT: api/properties/5
        [Authorize] // Protege o endpoint com autenticação JWT
        [HttpPut("{id}")]
        public ActionResult UpdateProperty(int id, [FromBody] Property property)
        {
            if (id != property.Id)
            {
                return BadRequest(); // Retorna 400 (Bad Request) se o ID não corresponder
            }
            _propertyService.UpdateProperty(property); // Atualiza a propriedade existente
            return NoContent(); // Retorna 204 (No Content) para indicar sucesso sem retorno
        }

        // DELETE: api/properties/5
        [Authorize] // Protege o endpoint com autenticação JWT
        [HttpDelete("{id}")]
        public ActionResult DeleteProperty(int id)
        {
            _propertyService.DeleteProperty(id); // Remove uma propriedade pelo ID
            return NoContent(); // Retorna 204 (No Content) para indicar sucesso sem retorno
        }
    }
}