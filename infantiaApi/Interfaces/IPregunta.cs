﻿using infantiaApi.Models;

namespace infantiaApi.Interfaces
{
    public interface IPregunta
    {
        Task<IEnumerable<dynamic>> GetAll();
        Task<IEnumerable<dynamic>> GetPreguntasNotInFormulario(int idFormulario);
        Task<Pregunta> GetPregunta(int idPregunta);
        Task<bool> InsertPregunta(Pregunta pregunta);
        Task<bool> UpdatePregunta(Pregunta pregunta);
        Task<bool> DeletePregunta(Pregunta pregunta);
    }
}
