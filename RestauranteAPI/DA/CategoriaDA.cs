using Abstracciones.Interfaces.DA;
using Abstracciones.Modelos;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DA
{
    public class CategoriaDA : ICategoriaDA
    {

        private IRepositorioDapper _repositorioDapper;
        private SqlConnection _sqlConnection;

        public CategoriaDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
            _sqlConnection = repositorioDapper.ObtenerRepositorio();

        }
        #region Operaciones
        public async Task<Guid> Agregar(Categoria categoria)
        {
            string query = @"AgregarCategoria";
            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                Id = Guid.NewGuid()
            ,
                Nombre = categoria.Nombre
            });
            return resultadoConsulta;
        }

        public async Task<Guid> Editar(Guid Id, Categoria categoria)
        {

            await VerificarCategoriaExiste(Id);
            string query = @"EditarCategoria";

            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {

                Nombre = categoria.Nombre
            });
            return resultadoConsulta;
        }

        public async Task<Guid> Eliminar(Guid Id)
        {
            await VerificarCategoriaExiste(Id);
            string query = @"EliminarCategoria";
            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                Id = Id

            });
            return resultadoConsulta;
        }

        public async Task<IEnumerable<CategoriaResponse>> Obtener()
        {
            string query = @"ObtenerCategorias";
            var resultadoConsulta = await _sqlConnection.QueryAsync<CategoriaResponse>(query);
            return resultadoConsulta;
        }


        public async Task<CategoriaResponse> Obtener(Guid Id)
        {
            string query = @"ObtenerCategoria";
            var resultadoConsulta = await _sqlConnection.QueryAsync<CategoriaResponse>(query, new { Id = Id });
            return resultadoConsulta.FirstOrDefault();
        }

#endregion
        private async Task VerificarCategoriaExiste(Guid Id)
        {
            CategoriaResponse? resultadoConsultaCategoria = await Obtener(Id);
            if (resultadoConsultaCategoria == null)
                throw new Exception("No se encontró la Categoria");
        }

    }
}
