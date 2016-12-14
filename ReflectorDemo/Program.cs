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
                }
            };


            Type type = model.Params.GetType();
            //var ps = type.GetProperties();

            var ps = type.GetProperties().Where(u=>u.PropertyType.FullName =="System.String").ToList();
            var cs = type.GetProperties();

            foreach (var p in ps)
            {
                Console.WriteLine("PropertyName:{0},Value:{1}",p.Name,p.GetValue(model.Params,null).ToString());
                p.SetValue(model.Params, "1001",null);
                Console.WriteLine("PropertyName:{0},Value:{1}", p.Name, p.GetValue(model.Params, null).ToString());
            }

            Console.ReadLine();
        }
    }

    public class UserSearchRequest
    {
        public string Name { set; get; }
        public int Age { set; get; }

        public BaseParam Params { set; get; }
    }

    public class BaseParam
    {
        public string Keywords { set; get; }
    }
}
