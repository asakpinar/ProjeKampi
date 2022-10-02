using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class HeadingManager : IHeadingService
    {
        IHeadingDal _headingdal;

        public HeadingManager(IHeadingDal headingdal)
        {
            _headingdal = headingdal;
        }

        public Heading GetByID(int id)
        {
            return _headingdal.Get(x => x.HeadingID == id);
        }

        public List<Heading> GetList()
        {
            return _headingdal.List();
        }

        public List<Heading> GetListByWriter(int id)
        {
            return _headingdal.List(x => x.WriterID == id);
        }

        public void HeadingAddBL(Heading heading)
        {
            _headingdal.Insert(heading);
        }

        public void HeadingDelete(Heading heading)
        {
            _headingdal.Delete(heading);
        }

        public void HeadingUpdate(Heading heading)
        {
            _headingdal.Update(heading);
        }
    }
}
