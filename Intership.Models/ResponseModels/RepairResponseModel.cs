﻿using System;
using System.Collections.Generic;

namespace Intership.Models.ResponseModels
{
    public class RepairResponseModel
    {
        #region Taked from Repair
        public Guid Id { get; set; }
        public string Name { get; set; }
        #endregion

        #region Taked from RepairInfo
        public DateTime Date { get; set; }
        public string AdvancedInfo { get; set; }
        #endregion

        #region Taked from Status
        public string StatusInfo { get; set; }
        #endregion

        public Guid RepairInfoId { get; set; }
    }
}