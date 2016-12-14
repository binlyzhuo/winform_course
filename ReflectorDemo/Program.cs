using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace ReflectorDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            UserSearchRequest model = new UserSearchRequest()
            {
                Name = "'1'=0",
                Age = 10,
                Params = new BaseParam()
                {
                    Keywords = "kk"
                },
                Ids = new List<string>()
                {
                    "123"
                },
                Ids2 = new List<string>()
                {
                    "456"
                },
                Param = new BaseParam()
            };


            Type interfaceType = typeof(IBaseParam);
            bool isIF = interfaceType.IsInterface;

            Type type = model.GetType();
            bool isPrimitive = type.IsPrimitive;

            bool isFromInterface = typeof(IBaseParam).IsAssignableFrom(typeof(BaseParam));


            //var ps = type.GetProperties();

            var ps = type.GetProperties();
            var cs = type.GetProperty("list");

            foreach (var p in ps)
            {
                Console.WriteLine("PropertyName:{0},Value:{1}", p.Name, p.GetValue(model, null).ToString());
                bool pt = p.GetType().IsClass;
                bool isIntetface = p.GetType().IsInterface;
                //p.SetValue(model.Params, "1001",null);
                //Console.WriteLine("PropertyName:{0},Value:{1}", p.Name, p.GetValue(model.Params, null).ToString());
            }


            List<Guid> guidIds = new List<Guid>()
            {
                Guid.NewGuid(),Guid.NewGuid()
            };

            List<string> strList = guidIds.Select(g => g.ToString()).ToList();

            Console.ReadLine();
        }
    }

    public class UserSearchRequest
    {
        public string Name { set; get; }
        public int Age { set; get; }

        public BaseParam Params { set; get; }

        public List<string> Ids { set; get; }
        public List<string> Ids2 { set; get; }

        public IBaseParam Param { set; get; }
    }

    public class BaseParam : IBaseParam
    {
        public string Keywords { set; get; }
    }

    public interface IBaseParam
    { }
}
