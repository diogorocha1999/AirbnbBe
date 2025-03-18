using System.Collections.Generic;
using System.Linq;
using AirbnbAPI.Data;

namespace AirbnbAPI.Business
{
    public class PropertyService : IPropertyService
    {
        private readonly AppDbContext _context;

        public PropertyService(AppDbContext context)
        {
            _context = context;
        }

        public List<Property> GetAllProperties()
        {
            return _context.Properties.ToList(); // Retorna todas as propriedades
        }

        public Property GetPropertyById(int id)
        {
            return _context.Properties.FirstOrDefault(p => p.Id == id); // Retorna uma propriedade pelo ID
        }

        public Property AddProperty(Property property)
        {
            _context.Properties.Add(property); // Adiciona uma nova propriedade
            _context.SaveChanges(); // Salva as alterações no banco de dados
            return property; // Retorna a propriedade criada
        }

        public void UpdateProperty(Property property)
        {
            _context.Properties.Update(property); // Atualiza uma propriedade existente
            _context.SaveChanges(); // Salva as alterações no banco de dados
        }

        public void DeleteProperty(int id)
        {
            var property = _context.Properties.FirstOrDefault(p => p.Id == id); // Busca a propriedade pelo ID
            if (property != null)
            {
                _context.Properties.Remove(property); // Remove a propriedade
                _context.SaveChanges(); // Salva as alterações no banco de dados
            }
        }
    }
}