using Abstracciones.Interfaces.DA;
using Abstracciones.Modelos;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DA
{
    public class SubCategoriaDA : ISubCategoriaDA
    {
        private IRepositorioDapper _repositorioDapper;
        private SqlConnection _sqlConnection;

        public SubCategoriaDA(IRepositorioDapper repositorioDapper)
        {
            _repositorioDapper = repositorioDapper;
            _sqlConnection = repositorioDapper.ObtenerRepositorio();

        }

        #region Operacion
        public async Task<Guid> Agregar(SubCategoriaRequest subCategoria)
        {
            string query = @"AgregarSubCategoria";
            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                Id = Guid.NewGuid()
             ,
                IdCategoria = subCategoria.IdCategoria
            ,
                Nombre = subCategoria.Nombre
            });
            return resultadoConsulta;
        } 

        public async Task<Guid> Editar(Guid Id, SubCategoriaRequest subCategoria)
        {

            await VerificarSubCategoriaExiste(Id);
            string query = @"EditarSubCategoria";
          
            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {

                IdCategoria = subCategoria.IdCategoria
            ,
                Nombre = subCategoria.Nombre
            });
            return resultadoConsulta;
        }

     
        public async Task<Guid> Eliminar(Guid Id)
        {
            await VerificarSubCategoriaExiste(Id);
            string query = @"EliminarSubCategoria";
            var resultadoConsulta = await _sqlConnection.ExecuteScalarAsync<Guid>(query, new
            {
                Id = Id
            
            });
            return resultadoConsulta;
        }
    

        public async Task<IEnumerable<SubCategoriaResponse>> Obtener()
        {
            string query = @"ObtenerSubCategorias";
            var resultadoConsulta = await _sqlConnection.QueryAsync<SubCategoriaResponse>(query);
            return resultadoConsulta;
        }

        public async Task<SubCategoriaResponse> Obtener(Guid Id)
        {
            string query = @"ObtenerSubCategoria";
            var resultadoConsulta = await _sqlConnection.QueryAsync<SubCategoriaResponse>(query, new { Id = Id });
            return resultadoConsulta.FirstOrDefault();
        }

        #endregion

        private async Task VerificarSubCategoriaExiste(Guid Id)
        {
            SubCategoriaResponse? resultadoConsultaSubCategoria = await Obtener(Id);
            if (resultadoConsultaSubCategoria == null)
                throw new Exception("No se encontró la Sub Categoria");
        }

    }
}
