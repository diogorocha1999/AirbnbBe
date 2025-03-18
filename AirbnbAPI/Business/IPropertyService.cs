using System.Collections.Generic;
using AirbnbAPI.Data;

namespace AirbnbAPI.Business
{
    public interface IPropertyService
    {
        List<Property> GetAllProperties(); // Retorna todas as propriedades
        Property GetPropertyById(int id); // Retorna uma propriedade pelo ID
        Property AddProperty(Property property); // Adiciona uma nova propriedade
        void UpdateProperty(Property property); // Atualiza uma propriedade existente
        void DeleteProperty(int id); // Remove uma propriedade pelo ID
    }
}