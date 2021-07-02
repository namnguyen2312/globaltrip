﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBT.Core.Domain.Catalog.Dto
{
    public class TourAttributeValueDto
    {
        public long Id { set; get; }
        public string AttrName { set; get; }
        public int TourAttributeId { set; get; }
        public long TourId { set; get; }
        [MaxLength(128)]
        public string Value { set; get; }
    }
}
