using Core.Entities;
using Core.Repositories;
using Dapper;
using System.Data;

namespace Infrastructure.Persistence.Repositories
{
    public class OfficeRepository : IOfficeRepository
    {
        private readonly DapperContext _context;
        public OfficeRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Office>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            using var connection = _context.CreateConnection();
            var offices = await connection.QueryAsync<Office>("dbo.SelectAllOffices", commandType: CommandType.StoredProcedure);
            return offices.ToList();
        }

        public async Task<Office> GetByIdAsync(Guid officeId, CancellationToken cancellationToken = default)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Id", officeId, DbType.Guid);

            using var connection = _context.CreateConnection();
            var office = await connection.QuerySingleOrDefaultAsync<Office>("dbo.SelectOffice", parameters, commandType: CommandType.StoredProcedure);
            return office;
        }

        public async Task<Office> AddAsync(Office office, CancellationToken cancellationToken)
        {
            var parameters = new DynamicParameters();
            parameters.Add("City", office.City, DbType.String);
            parameters.Add("Street", office.Street, DbType.String);
            parameters.Add("HouseNumber", office.HouseNumber, DbType.Int32);
            parameters.Add("OfficeNumber", office.OfficeNumber, DbType.Int32);
            parameters.Add("RegistryPhoneNumber", office.RegistryPhoneNumber, DbType.String);
            parameters.Add("IsActive", office.IsActive, DbType.Boolean);
            parameters.Add("PhotoId", office.PhotoId, DbType.Guid);

            using var connection = _context.CreateConnection();
            return await connection.QuerySingleAsync<Office>("dbo.InsertOffice", parameters, commandType: CommandType.StoredProcedure);
        }
        public void Update(Office office)
        {
            var parameters = new DynamicParameters();
            parameters.Add("City", office.City, DbType.String);
            parameters.Add("Street", office.Street, DbType.String);
            parameters.Add("HouseNumber", office.HouseNumber, DbType.Int32);
            parameters.Add("OfficeNumber", office.OfficeNumber, DbType.Int32);
            parameters.Add("RegistryPhoneNumber", office.RegistryPhoneNumber, DbType.String);
            parameters.Add("IsActive", office.IsActive, DbType.Boolean);
            parameters.Add("PhotoId", office.PhotoId, DbType.Guid);
            parameters.Add("Original_Id", office.Id, DbType.Guid);

            using var connection = _context.CreateConnection();
            connection.Execute("dbo.UpdateOffice", parameters, commandType: CommandType.StoredProcedure);
        }

        public void Remove(Office office)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Original_Id", office.Id, DbType.Guid);

            using var connection = _context.CreateConnection();
            connection.Execute("dbo.DeleteOffice", parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
