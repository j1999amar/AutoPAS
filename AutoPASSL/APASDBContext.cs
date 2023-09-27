using Microsoft.EntityFrameworkCore;
using AutoPASDML;

namespace AutoPASSL
{
    public class APASDBContext : DbContext
    {
        public APASDBContext()
        {
        }

        public APASDBContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<test> test { get; set; }
        //DbSet
        public DbSet<policy> policy { get; set; }
        public DbSet<PolicyInsured> PolicyInsured { get; set; }
        public DbSet<PolicyVehicle> PolicyVehicle { get; set; }
        public DbSet<insured> insured { get; set; }

        public DbSet<contact> contact { get; set; }

        public DbSet<insuredContact> insuredcontact { get; set; }

        public DbSet<RTO> rto { get; set; }

        public DbSet<vehicle> vehicle { get; set; }

        public DbSet<vehicleType> vehicleType { get; set; }

        public DbSet<variant> variant { get; set; }

        public DbSet<bodyType> bodyType { get; set; }
        public DbSet<model> model { get; set; }
        public DbSet<coverages> coverages { get; set; }
        public DbSet<policycoverage> policycoverage { get; set; }

        public DbSet<Brands> brand { get; set; }

        public DbSet<transmissiontype> transmissiontype { get; set; }
        public DbSet<fueltype> fueltype { get; set; }
        
        public DbSet<modelfueltype> modelfueltype { get; set; }
        public DbSet<modelfueltypevariant> modelfueltypevariant { get; set; }

        public DbSet<RT_NCBFactor> RT_NCBFactor { get; set; }

        public DbSet<RT_NCB> rt_ncb { get; set; }
        public DbSet<RT_ODP> rt_odp { get; set; }
        public DbSet<RT_TPC> rt_tpc { get; set; }
        public DbSet<RT_LLP> rt_llp { get; set; }
        public DbSet<RT_THEFT> rt_theft { get; set; }
        public DbSet<RT_GST> rt_gst { get; set; }

        public DbSet<RT_OwnDamageFactor> RT_OwnDamageFactor { get; set; }
        public DbSet<RT_LegalLiabilityPremium> RT_LegalLiabilityPremium { get; set; }
        public DbSet<RT_ThirdPartyCoverPremium> RT_ThirdPartyCoverPremium { get; set; }
        public DbSet<RT_GSTFactor> RT_GSTFactor { get; set; }
        public DbSet<RT_TheftFactor> RT_TheftFactor { get; set; }
        public DbSet<metadatatables> metadatatables { get; set; }
        public DbSet<supportingdocument> supportingdocuments { get; set; }

        public DbSet<Master> Masters { get; set; }

        public void CallCreateTableStoredProcedure(string tableName, string column)
        {
            Database.ExecuteSqlRaw("call sp_CreateTableWithParams (@p0, @p1)", tableName, column);
        }

        public void CallDropTableStoredProcedure(string tableName)
        {
            Database.ExecuteSqlRaw("call sp_DropTableWithParams (@p0)", tableName);
        }

        public bool CallCheckTableObjectExists(string tableName)
        {
            var sql_test = "CALL sp_CheckTableObjectExists(@p0)";
            var TableObjDataReader = Database.SqlQueryRaw<int>(sql_test, tableName).ToList();
            int table_exist = TableObjDataReader.FirstOrDefault();
            if (table_exist == -1 || table_exist == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool CallCheckTableObjectExistswithColumn(string tableName, string columnname)
        {
            var sql_test = "CALL sp_CheckTableObjectExistswithColumn(@p0, @p1)";
            var TableObjDataReader = Database.SqlQueryRaw<int>(sql_test, tableName, columnname).ToList();
            int table_exist = TableObjDataReader.FirstOrDefault();
            if (table_exist == -1 || table_exist == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void CallDynamicTableInsertStoredProcedure(string tableName, string columnName, string valueList)
        {
            Database.ExecuteSqlRaw("call sp_InsertTableValues (@p0, @p1, @p2)", tableName, columnName, valueList);
        }

        public void CallAlterTableAddNewColumnStoredProcedure(string tableName, string columnName)
        {
            Database.ExecuteSqlRaw("call sp_AlterTableAddNewColumn (@p0, @p1)", tableName, columnName);
        }

        public void CallAlterTableDropColumnStoredProcedure(string tableName, string columnName)
        {
            Database.ExecuteSqlRaw("call sp_AlterTableDropColumn (@p0, @p1)", tableName, columnName);
        }

        public void CallDeleteTableStoredProcedure(string tableName)
        {
            Database.ExecuteSqlRaw("call sp_DeleteTableEnties (@p0)", tableName);
        }
    }
}
