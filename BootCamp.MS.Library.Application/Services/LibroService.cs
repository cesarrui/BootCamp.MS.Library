using Bootcamp.MS.Library.Domain;
using Bootcamp.MS.Library.Domain.Models;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCamp.MS.Library.Application.Services
{
    public class LibroService
    {
        private readonly ILibroRepository _libroRepository;
        public LibroService(ILibroRepository libroRepository) { 
            _libroRepository = libroRepository;
        
        }

        public async Task<Result<List<Libro>>> GetAll()
        {
            try
            {
                var res = await _libroRepository.GetAll();
                return new Result<List<Libro>>()
                {
                    Success = true,
                    Data = res.ToList()
                };
            }
            catch(Exception ex)
            {
                return new Result<List<Libro>>()
                {
                    Message = ex.Message
                };

            }
            
        }

        public async Task<Result<string>> Create(HttpRequest req)
        {
            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var libro = JsonConvert.DeserializeObject<Libro>(requestBody);

                if (libro == null)
                {
                    throw new ArgumentException("Se necesita un objeto para la deserialización");
                }

                // Validar campos requeridos
                if (string.IsNullOrWhiteSpace(libro.Nombre) || libro.IdCategoria == Guid.Empty || libro.IdAutor == Guid.Empty)
                {
                    throw new ArgumentException("Campos obligatorios faltantes o inválidos");
                }

                await _libroRepository.Create(libro);

                return new Result<string>
                {
                    Success = true,
                    Data = "Libro creado"
                };
            }
            catch (Exception ex)
            {
                // Incluir información de la excepción para diagnóstico
                return new Result<string>
                {
                    Success = false,
                    Message = $"Error al crear el libro: {ex.Message}"
                };
            }
        }

        public async Task<Result<string>> Update(HttpRequest req)
        {
            try
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                var libro = JsonConvert.DeserializeObject<Libro>(requestBody);

                if (libro == null)
                {
                    throw new ArgumentException("Se necesita un objeto para la deserialización");
                }

                // Validar campos requeridos
                if (string.IsNullOrWhiteSpace(libro.Nombre) || libro.IdCategoria == Guid.Empty || libro.IdAutor == Guid.Empty)
                {
                    throw new ArgumentException("Campos obligatorios faltantes o inválidos");
                }

                await _libroRepository.Update(libro);

                return new Result<string>
                {
                    Success = true,
                    Data = "Libro Actualizado"
                };
            }
            catch (Exception ex)
            {
                // Incluir información de la excepción para diagnóstico
                return new Result<string>
                {
                    Success = false,
                    Message = $"Error al actualizr el libro: {ex.Message}"
                };
            }
        }

    }
}
