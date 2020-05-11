using System;
using System.Collections.Generic;

namespace KazanNeftSession1.Models
{
    public class GlobalVariables
    {

        public class assetListItem
        {
            public int ID { get; set; }
            public string AssetName { get; set; }
            public string DepartmentName { get; set; }
            public string AssetSN { get; set; }
            public string AssetGroup { get; set; }
        }

        public class Employee
        {
            public int ID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Phone { get; set; }
        }

        public class Locations
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }
        public class DepartmentLocations
        {
            public int ID { get; set; }
            public int DepartmentID { get; set; }
            public int LocationID { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }

        }
        public class AssetTransferLogs
        {
            public int ID { get; set; }
            public int AssetID { get; set; }
            public DateTime TransferDate { get; set; }
            public string FromAssetSN { get; set; }
            public string ToAssetSN { get; set; }
            public int FromDepartmentLocationID { get; set; }
            public int ToDepartmentLocationID { get; set; }
        }
        public class Asset
        {
            public int ID { get; set; }
            public string AssetSN { get; set; }
            public string AssetName { get; set; }
            public int DepartmentLocationID { get; set; }
            public int EmployeeID { get; set; }
            public int AssetGroupID { get; set; }
            public string Description { get; set; }
            public DateTime WarrantyDate { get; set; }
        }
    }
}
