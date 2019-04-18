using GamerMarket.Core.Core.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamerMarket.Core.Core.Entity
{
    public class CoreEntity
    {
        //Burası tüm entitylerin orta özelliklerinin belirtileceği yerdir.
        public Guid ID { get; set; }
        public Status Status{ get; set; }

        //Ekleme Anı Özellikleri
        public string CreatedComputerName { get; set; }
        public string CreatedIP { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedADUserName { get; set; }


        //Güncelleme Anı Özellikleri
        public string ModifiedComputerName { get; set; }
        public string ModifiedIP { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedADUserName { get; set; }

    }
}
