using DepositoHelados.Domain.Entities.CompanyAggregate;
using DepositoHelados.Domain.Entities.MasterAggregate;

namespace DepositoHelados.Infraestructure.Context.Seed;

internal class SeedDatabase
{
    public static void Init(ModelBuilder modelBuilder)
    {
        //var company = new Company(Guid.NewGuid(), "Krovelsa", "Krovelsa SAC", "102020302012", "");

        //var tablesMaster = new List<Master>()
        //{
        //    new Master(Guid.NewGuid(), "UBI", "Ubigeous", "Tabla para guardar los ubigeos"),
        //    new Master(Guid.NewGuid(), "UM", "Unit Measurement", "Tabla para guardar las unidades de medida"),
        //    new Master(Guid.NewGuid(), "BRAND", "Brand", "Tabla para guardar las marcas"),
        //    new Master(Guid.NewGuid(), "DOCIDENT", "Type Document Identity", "Tabla para guardar los tipos de documento de identidad"),
        //    new Master(Guid.NewGuid(), "FILE", "Type File", "Tabla para guardar los tipos de archivos")
        //    //new Master(Guid.NewGuid(), "FLAVOR", "Flavor", "Tabla para guardar los sabores"),
        //};

        //var tablesMasterDetails = new List<MasterDetail>()
        //{
        //    /*UBIGEOS*/
        //    new MasterDetail(1,"15", "Lima",                       "","UBI","",1),
        //    new MasterDetail(2,"1501", "Lima",                     "","UBI","",1),
        //    new MasterDetail(3,"150101", "Lima",                   "","UBI","",1),
        //    new MasterDetail(4,"150102", "Ancón",                  "","UBI","",1),
        //    new MasterDetail(5,"150103", "Ate",                    "","UBI","",1),
        //    new MasterDetail(6,"150104", "Barranco",               "","UBI","",1),
        //    new MasterDetail(7,"150105", "Breña",                  "","UBI","",1),
        //    new MasterDetail(8,"150106", "Carabayllo",             "","UBI","",1),
        //    new MasterDetail(9,"150107", "Chaclacayo",             "","UBI","",1),
        //    new MasterDetail(10,"150108", "Chorrillos",             "","UBI","",1),
        //    new MasterDetail(11,"150109", "Cieneguilla",            "","UBI","",1),
        //    new MasterDetail(12,"150110", "Comas",                  "","UBI","",1),
        //    new MasterDetail(13,"150111", "El Agustino",            "","UBI","",1),
        //    new MasterDetail(14,"150112", "Independencia",          "","UBI","",1),
        //    new MasterDetail(15,"150113", "Jesús María",            "","UBI","",1),
        //    new MasterDetail(16,"150114", "La Molina",              "","UBI","",1),
        //    new MasterDetail(17,"150115", "La Victoria",            "","UBI","",1),
        //    new MasterDetail(18,"150116", "Lince",                  "","UBI","",1),
        //    new MasterDetail(19,"150117", "Los Olivos",             "","UBI","",1),
        //    new MasterDetail(20,"150118", "Lurigancho",             "","UBI","",1),
        //    new MasterDetail(21,"150119", "Lurin",                  "","UBI","",1),
        //    new MasterDetail(22,"150120", "Magdalena del Mar",      "","UBI","",1),
        //    new MasterDetail(23,"150121", "Pueblo Libre",           "","UBI","",1),
        //    new MasterDetail(24,"150122", "Miraflores",             "","UBI","",1),
        //    new MasterDetail(25,"150123", "Pachacamac",             "","UBI","",1),
        //    new MasterDetail(26,"150124", "Pucusana",               "","UBI","",1),
        //    new MasterDetail(27,"150125", "Puente Piedra",          "","UBI","",1),
        //    new MasterDetail(28,"150126", "Punta Hermosa",          "","UBI","",1),
        //    new MasterDetail(29,"150127", "Punta Negra",            "","UBI","",1),
        //    new MasterDetail(30,"150128", "Rímac",                  "","UBI","",1),
        //    new MasterDetail(31,"150129", "San Bartolo",            "","UBI","",1),
        //    new MasterDetail(32,"150130", "San Borja",              "","UBI","",1),
        //    new MasterDetail(33,"150131", "San Isidro",             "","UBI","",1),
        //    new MasterDetail(34,"150132", "San Juan de Lurigancho", "","UBI","",1),
        //    new MasterDetail(35,"150133", "San Juan de Miraflores", "","UBI","",1),
        //    new MasterDetail(36,"150134", "San Luis",               "","UBI","",1),
        //    new MasterDetail(37,"150135", "San Martín de Porres",   "","UBI","",1),
        //    new MasterDetail(38,"150136", "San Miguel",             "","UBI","",1),
        //    new MasterDetail(39,"150137", "Santa Anita",            "","UBI","",1),
        //    new MasterDetail(40,"150138", "Santa María del Mar",    "","UBI","",1),
        //    new MasterDetail(41,"150139", "Santa Rosa",             "","UBI","",1),
        //    new MasterDetail(42,"150140", "Santiago de Surco",      "","UBI","",1),
        //    new MasterDetail(43,"150141", "Surquillo",              "","UBI","",1),
        //    new MasterDetail(44,"150142", "Villa El Salvador",      "","UBI","",1),
        //    new MasterDetail(45,"150143", "Villa María del Triunfo","","UBI","",1),

        //    /*UNIDADES DE MEDIDA*/
        //    new MasterDetail(46,"UM01", "Unidad","","UM","",1),
        //    new MasterDetail(47,"UM02", "Caja","","UM","",1),
        //    new MasterDetail(48,"UM03", "Cubeta","","UM","",1),
        //    new MasterDetail(49,"UM04", "Media Cubeta 1/2","","UM","",1),

        //    /*MARCAS*/
        //    new MasterDetail(50,"BRAND01", "Donofrio","","BRAND","",1),
        //    new MasterDetail(51,"BRAND02", "Yamboly","","BRAND","",1),

        //    /*DOCUMENTO DE IDENTIDAD*/
        //    new MasterDetail(52,"DOCIDENT01", "DNI","Documento de Identidad","DOCIDENT","",1),
        //    new MasterDetail(53,"DOCIDENT02", "PASS","Pasaporte","DOCIDENT","",1),
        //    new MasterDetail(54,"DOCIDENT03", "CEX","Carnet de Extranjeria","DOCIDENT","",1),

        //    /*FILES*/
        //    new MasterDetail(55,"FILE01", "Imagen","","FILE","",1),
        //    new MasterDetail(56,"FILE01", "Documento Word","","FILE","",1),
        //    new MasterDetail(57,"FILE01", "Documento Excel","","FILE","",1),
        //    new MasterDetail(58,"FILE01", "Documento Pdf","","FILE","",1)

        //};

        //var masterDetailId = 0;

        //tablesMaster.ForEach(master =>
        //{
        //    master.SetCompanyId(company.Id);
        //    var details = tablesMasterDetails.Where(d => d.AdditionalOne.Equals(master.Code)).ToList();

        //    details.ForEach(d =>
        //    {
        //        masterDetailId++;

        //        d.SetSort(details.IndexOf(d) + 1);
        //        d.SetMasterId(master.Id);
        //    });
        //});


        //modelBuilder.Entity<Company>().HasData(company);
        //modelBuilder.Entity<Master>().HasData(tablesMaster);
        //modelBuilder.Entity<MasterDetail>().HasData(tablesMasterDetails);

    }
}
