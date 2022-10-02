﻿using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Abstract
{
    public interface IHeadingService
    {
        List<Heading> GetList();
        List<Heading> GetListByWriter(int id);
        void HeadingAddBL(Heading heading);
        Heading GetByID(int id);
        void HeadingDelete(Heading heading);

        void HeadingUpdate(Heading Heading);
    }
}
