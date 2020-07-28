using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using TerminiDostave.DataAccess;

namespace TerminiDostave.Models
{
    public class TermModel
    {
        public int Id { get; set; }
        [Display(Name = "Referenca")]
        public int TrackingNumber { get; set; }
        [Required(ErrorMessage = "To polje je obvezno!")]
        [Range(1000, 3999, ErrorMessage = "Številka dostave mora biti med 1000 in 3999.")]
        [Display(Name = "Številka dostave")]
        public int DeliveryNumber { get; set; }
        [Display(Name = "Skladišče")]

        public int StorageId { get; set; }
        [Required(ErrorMessage = "To polje je obvezno!")]
        [Range(1,5,ErrorMessage ="Dostopna točka mora biti med 1 in 5")]
        [Display(Name = "Dostopna točka")]
        public int AcessPoint { get; set; }

        [Required(ErrorMessage = "To polje je obvezno!")]
        [Display(Name = "Podjetje")]
        public string Company { get; set; }
        [Required(ErrorMessage = "To polje je obvezno!")]
        [Display(Name = "Ime")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "To polje je obvezno!")]
        [Display(Name = "Priimek")]
        public string Lastname { get; set; }
        [Required(ErrorMessage = "To polje je obvezno!")]
        [Display(Name = "Telefonska številka")]
        public string Telephone { get; set; }
        [Required(ErrorMessage = "To polje je obvezno!")]
        [Display(Name = "Datum dostave")]
        [DataType(DataType.Date)]
        public DateTime DeliveryTime { get; set; }
        public string Status { get; set; }
        [Display(Name = "Opombe dostavljalca")]

        public string OpombeDostavljalca { get; set; }
        [Display(Name = "Opombe zaposlenega")]
        public string OpombeZaposlenega { get; set; }

        public int InsertIntoDatabase()
        {
            Status = "V teku";
            TrackingNumber = new Random().Next(1000000,10000000);
            if (DeliveryNumber <= 1999) StorageId = 1;
            else if (DeliveryNumber <= 2999) StorageId = 2;
            else StorageId = 3;
            if (OpombeDostavljalca is null) OpombeDostavljalca = "Brez";
            if (OpombeZaposlenega is null) OpombeZaposlenega = "Brez";

            string sql = @"insert into dbo.TermModels (Company, FirstName, LastName, Telephone, Status, TrackingNumber, DeliveryNumber, StorageId, AcessPoint, DeliveryTime, OpombeDostavljalca, OpombeZaposlenega)
                            values (@Company, @FirstName, @LastName, @Telephone, @Status, @TrackingNumber, @DeliveryNumber, @StorageId, @AcessPoint, @DeliveryTime, @OpombeDostavljalca, @OpombeZaposlenega);";
            return SqlDataAccess.SaveData(sql, this);
        }

        public int UpdateDatabase()
        {
            if (DeliveryNumber <= 1999) StorageId = 1;
            else if (DeliveryNumber <= 2999) StorageId = 2;
            else StorageId = 3;
            if (OpombeDostavljalca == "") OpombeDostavljalca = "N/A";
            if (OpombeZaposlenega == "") OpombeZaposlenega = "N/A";

            string sql = @"update dbo.TermModels 
                            set Company=@Company, FirstName=@FirstName, LastName=@LastName, Telephone=@Telephone, Status=@Status, DeliveryNumber=@DeliveryNumber, StorageId=@StorageId, AcessPoint=@AcessPoint, DeliveryTime=@DeliveryTime, OpombeDostavljalca=@OpombeDostavljalca, OpombeZaposlenega=@OpombeZaposlenega
                            where Id = " + Id.ToString() +";";
            return SqlDataAccess.SaveData(sql, this);

        }

        //za skladiscnika
        public int UpdateDatabaseSklad()
        {
            string sql = @"update dbo.TermModels set OpombeZaposlenega=@OpombeZaposlenega where Id = " + Id.ToString() + ";";
            return SqlDataAccess.SaveData(sql, new { OpombeZaposlenega = OpombeZaposlenega });
        }

        public static int UpdateDatabaseStatus(string status, int trackNum)
        {
            string sql = @"update dbo.TermModels set Status=@status where TrackingNumber = " + trackNum.ToString() + ";";
            return SqlDataAccess.SaveData(sql, new { Status = status });
        }

        internal static int GetTrackFromId(int ident)
        {
            string sql = "select TrackingNumber from dbo.TermModels where Id = " + ident.ToString() + ";";
            return SqlDataAccess.LoadData<TermModel>(sql)[0].TrackingNumber;
        }

        public static List<TermModel> LoadFromDatabase()
        {
            string sql = @"select Id, Company, FirstName, LastName, Telephone, Status, TrackingNumber, DeliveryNumber, StorageId, AcessPoint, DeliveryTime, OpombeDostavljalca, OpombeZaposlenega
                            from dbo.TermModels;";
            return SqlDataAccess.LoadData<TermModel>(sql);
        }

        public static TermModel LoadFromDatabaseByTrack(int ident)
        {
            string sql = @"select Id, Company, FirstName, LastName, Telephone, Status, TrackingNumber, DeliveryNumber, StorageId, AcessPoint, DeliveryTime, OpombeDostavljalca, OpombeZaposlenega
                            from dbo.TermModels
                            where TrackingNumber = " + ident.ToString() + ";";
            return SqlDataAccess.LoadData<TermModel>(sql)[0];
        }

        public static void DeleteFromDatabase(int ident)
        {
            string sql = @"delete from dbo.TermModels 
                         where TrackingNumber = " + ident.ToString() + ";";

            SqlDataAccess.LoadData<TermModel>(sql);

        }
        public static int LoadFromDatabaseLast()
        {
            string sql = @"select Id from dbo.TermModels 
                           order by Id desc;";
            return SqlDataAccess.LoadData<TermModel>(sql)[0].Id;
        }
    }

}